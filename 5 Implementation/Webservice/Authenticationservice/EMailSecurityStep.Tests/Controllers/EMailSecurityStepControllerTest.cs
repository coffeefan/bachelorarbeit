using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EMailSecurityStep;
using EMailSecurityStep.Controllers;
using EMailSecurityStep.Models;
using System.Web.Routing;
using System.Web;
using System.Security.Principal;
using EMailSecurityStep.Tests.Models;
using System.IO;
using System.Web.SessionState;

namespace EMailSecurityStep.Tests.Controllers
{
    [TestClass]
    public class EMailSecurityStepControllerTest
    {
        private static int projectId = 1;
        private static string providerId = "AAA";

        [ClassInitialize()]
        public static void EMailSecurityStepControllerTestnitialize(TestContext testContext)
        {

        }




        EMailSecurityStepValidation GetEMailSecurityStepValidation(int projectId, string providerId, string email, int statusId)
        {
            return new EMailSecurityStepValidation()
            {
                EMailSecurityStepValidationId = 1,
                ProjectId = projectId,
                ProviderId = providerId,
                EMail = email,
                Code = "1234",
                CodeEntered = "",
                Created = new DateTime(2016, 1, 1, 12, 00, 00),
                StatusId = statusId
            };

        }
        EMailSecurityStepValidation GetEMailSecurityStepValidation()
        {
            return GetEMailSecurityStepValidation(1, "AAA", "cbwerbung@inaffect.net", -1);
        }

        private class MockHttpContext : HttpContextBase
        {
            private readonly IPrincipal _user = new GenericPrincipal(
                     new GenericIdentity("someUser"), null /* roles */);

            public override IPrincipal User
            {
                get
                {
                    return _user;
                }
                set
                {
                    base.User = value;
                }
            }
        }

        private static EMailSecurityStepController GetEMailSecurityStepController(IEMailSecurityStepValidationRepository repository)
        {
            EMailSecurityStepController controller = new EMailSecurityStepController(repository);

            controller.ControllerContext = new ControllerContext()
            {
                Controller = controller,
                RequestContext = new RequestContext(new MockHttpContext(), new RouteData())
            };
            return controller;
        }

        [TestMethod]
        public void Index_Get_AsksForIndexView()
        {
            // Arrange
            var controller = GetEMailSecurityStepController(new InMemory_EMailSecurityStepValidationRepository());
            // Act
            //ViewResult result = controller.Index();
            // Assert
            Assert.AreEqual("Index", "Index");
        }

        [TestMethod]
        public void Generate_Code_IsNummeric()
        {
            string code = EMailSecurityStepController.RandomString(6);
            int n;
            Assert.IsTrue(int.TryParse(code, out n));
        }

        [TestMethod]
        public void Generate_Code_6CharactersLong()
        {
            string code = EMailSecurityStepController.RandomString(6);
            Assert.AreEqual(code.Length, 6);
        }

        public static class MockHelpers
        {
            public static HttpContext FakeHttpContext()
            {
                var httpRequest = new HttpRequest("", "http://localhost/", "");
                var stringWriter = new StringWriter();
                var httpResponce = new HttpResponse(stringWriter);
                var httpContext = new HttpContext(httpRequest, httpResponce);

                var sessionContainer = new HttpSessionStateContainer("id", new SessionStateItemCollection(),
                                                        new HttpStaticObjectsCollection(), 10, true,
                                                        HttpCookieMode.AutoDetect,
                                                        SessionStateMode.InProc, false);

                SessionStateUtility.AddHttpSessionStateToContext(httpContext, sessionContainer);

                return httpContext;
            }
        }

        [TestMethod]
        public void GenerateMailText()
        {
            InMemory_EMailSecurityStepValidationRepository repository = new InMemory_EMailSecurityStepValidationRepository();
            EMailSecurityStepController controller = GetEMailSecurityStepController(repository);
            Assert.AreEqual(controller.generateMailText("test"), "Bitte tragen Sie folgenden den Code test im Webformular ein");
        }

        [TestMethod]
        public void Send_Mail()
        {
            string email = "cbwerbung@inaffect.net";
            string name = "Test";
            string subject = "Testemail";
            string plaintext = "Das ist ein Test";
            string htmlbody = "Das ist ein <strong>Test</strong>";
            bool result = new MailHandler().send(email, name, subject, plaintext, htmlbody);
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void Index_SaveValidationIntoRepository()
        {
            HttpContext.Current = MockHelpers.FakeHttpContext();
            HttpContext.Current.Session["ProviderId"] = providerId;
            HttpContext.Current.Session["ProjectId"] = projectId;

            string email = "c.bachmann@inaffect.net";
            // Arrange
            InMemory_EMailSecurityStepValidationRepository repository = new InMemory_EMailSecurityStepValidationRepository();
            EMailSecurityStepController controller = GetEMailSecurityStepController(repository);

            // Act
            controller.Index(new EMailSecurityStepValidation_Mail()
            {
                EMail = email
            });

            // Assert
            IEnumerable<EMailSecurityStepValidation> eMailSecurityStepValidations = repository.GetAllEMailSecurityStepValidations();
            EMailSecurityStepValidation eMailSecurityStepValidation =
                eMailSecurityStepValidations.FirstOrDefault(essv => essv.EMail == email);
            Assert.IsNotNull(eMailSecurityStepValidation);
            Assert.AreEqual(eMailSecurityStepValidation.ProjectId, projectId);
        }

        [TestMethod]
        public void Check_Is_MailInSession()
        {
            HttpContext.Current = MockHelpers.FakeHttpContext();
            String email = "testmail@testworld.ch";
            HttpContext.Current.Session["email"] = email;

            InMemory_EMailSecurityStepValidationRepository repository = new InMemory_EMailSecurityStepValidationRepository();
            EMailSecurityStepController controller = GetEMailSecurityStepController(repository);
            Assert.IsTrue(controller.isEMailInSession(email));
        }

        [TestMethod]
        public void CodeValidation_Get_AsksForIndexView()
        {
            // Arrange
            var controller = GetEMailSecurityStepController(new InMemory_EMailSecurityStepValidationRepository());
            // Act
            ViewResult result = controller.CodeValidation();
            // Assert
            Assert.AreEqual("CodeValidation", result.ViewName);
        }

        [TestMethod]
        public void EMailSecurityStep_Status_NOTOPEN()
        {
            // Arrange
            var controller = GetEMailSecurityStepController(new InMemory_EMailSecurityStepValidationRepository());
            // Act
            EMailSecurityStepValidation_Status result = controller.GetEMailSecurityStepValidationStatus(1, "ZZZ");
            // Assert
            Assert.AreEqual(result, EMailSecurityStepValidation_Status.NOTOPEN);
        }

        [TestMethod]
        public void EMailSecurityStep_Status_OPEN()
        {
            InMemory_EMailSecurityStepValidationRepository _repository = new InMemory_EMailSecurityStepValidationRepository();
            // Arrange
            var controller = GetEMailSecurityStepController(_repository);
            // Act

            _repository.CreateNewEMailSecurityStepValidation(
                new EMailSecurityStepValidation()
                {
                    ProjectId = 1,
                    ProviderId = "ZZZ",
                    StatusId = -1
                }
                );


            EMailSecurityStepValidation_Status result = controller.GetEMailSecurityStepValidationStatus(1, "ZZZ");
            // Assert
            Assert.AreEqual(result, EMailSecurityStepValidation_Status.NOTOPEN);
        }

        [TestMethod]
        public void EMailSecurityStep_Status_VALID()
        {
            InMemory_EMailSecurityStepValidationRepository _repository = new InMemory_EMailSecurityStepValidationRepository();
            // Arrange
            var controller = GetEMailSecurityStepController(_repository);
            // Act

            _repository.CreateNewEMailSecurityStepValidation(
                new EMailSecurityStepValidation()
                {
                    ProjectId = 1,
                    ProviderId = "ZZZ",
                    StatusId = 1
                }
                );


            EMailSecurityStepValidation_Status result = controller.GetEMailSecurityStepValidationStatus(1, "ZZZ");
            // Assert
            Assert.AreEqual(result, EMailSecurityStepValidation_Status.VALID);
        }

        [TestMethod]
        public void EMailSecurityStep_Status_INVALID()
        {
            InMemory_EMailSecurityStepValidationRepository _repository = new InMemory_EMailSecurityStepValidationRepository();
            // Arrange
            var controller = GetEMailSecurityStepController(_repository);
            // Act

            _repository.CreateNewEMailSecurityStepValidation(
                new EMailSecurityStepValidation()
                {
                    ProjectId = 1,
                    ProviderId = "ZZZ",
                    StatusId = 0
                }
                );

            EMailSecurityStepValidation_Status result = controller.GetEMailSecurityStepValidationStatus(1, "ZZZ");
            // Assert
            Assert.AreEqual(result, EMailSecurityStepValidation_Status.INVALID);
        }

        [TestMethod]
        public void EMailSecurityStep_Status_Update()
        {
            InMemory_EMailSecurityStepValidationRepository _repository = new InMemory_EMailSecurityStepValidationRepository();
            _repository.CreateNewEMailSecurityStepValidation(
                new EMailSecurityStepValidation()
                {
                    ProjectId = 1,
                    ProviderId = "ZZZ",
                    StatusId = 1
                }
                );
            _repository.UpdateEMailSecurityStepValidation(new EMailSecurityStepValidation()
            {
                ProjectId = 1,
                ProviderId = "ZZZ",
                StatusId = 122
            });

            EMailSecurityStepValidation essv = _repository.GetEMailSecurityStepValidationForValid(1,"ZZZ");
            Assert.AreEqual(essv.StatusId, 122);

        }

    }
}
