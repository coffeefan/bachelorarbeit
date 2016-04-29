 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSSecurityStep;
using SMSSecurityStep.Controllers;
using SMSSecurityStep.Models;
using System.Web.Routing;
using System.Web;
using System.Security.Principal;
using SMSSecurityStep.Tests.Models;
using System.IO;
using System.Web.SessionState;

namespace SMSSecurityStep.Tests.Controllers
{
    [TestClass]
    public class SMSSecurityStepControllerTest
    {
        private static int projectId = 1;
        private static string providerId = "AAA";

        [ClassInitialize()]
        public static void SMSSecurityStepControllerTestnitialize(TestContext testContext)
        {

        }      




        SMSSecurityStepValidation GetSMSSecurityStepValidation(int projectId, string providerId, string mobileNumber, int statusId)
        {
            return new SMSSecurityStepValidation()
            {
                SMSSecurityStepValidationId = 1,
                ProjectId = projectId,
                ProviderId = providerId,
                MobileNumber = mobileNumber,
                SMSSendCount=1,
                Code = "1234",
                CodeEntered = "",
                Created = new DateTime(2016, 1, 1, 12, 00, 00),
                StatusId = statusId
            };

        }
        SMSSecurityStepValidation GetSMSSecurityStepValidation()
        {
            return GetSMSSecurityStepValidation(1, "AAA", "cbwerbung@inaffect.net", -1);
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

        private static SMSSecurityStepController GetSMSSecurityStepController(ISMSSecurityStepValidationRepository validationRepo,
            ISMSSecurityStepConfigRepository configRepo)
        {
            SMSSecurityStepController controller = new SMSSecurityStepController(validationRepo, configRepo);

            controller.ControllerContext = new ControllerContext()
            {
                Controller = controller,
                RequestContext = new RequestContext(new MockHttpContext(), new RouteData())
            };
            return controller;
        }

        [TestMethod]
        public void Index()
        {
            HttpContext.Current = MockHelpers.FakeHttpContext();
            HttpContext.Current.Session["ProviderId"] = providerId;
            HttpContext.Current.Session["ProjectId"] = projectId;
            // Arrange
            SMSSecurityStepController controller = new SMSSecurityStepController(
                new InMemory_SMSSecurityStepValidationRepository(), new InMemory_SMSSecurityStepConfigRepository());

            // Act
            ActionResult result = controller.Index() as ActionResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Index_Get_AsksForIndexView()
        {
            // Arrange
            var controller = GetSMSSecurityStepController(new InMemory_SMSSecurityStepValidationRepository(),
                new InMemory_SMSSecurityStepConfigRepository());
            // Act
            //ViewResult result = controller.Index();
            // Assert
            Assert.AreEqual("Index", "Index");
        }

        [TestMethod]
        public void Generate_Code_IsNummeric()
        {
            string code = SMSSecurityStepController.RandomString(6);
            int n;
            Assert.IsTrue(int.TryParse(code, out n));
        }

        [TestMethod]
        public void Generate_Code_6CharactersLong()
        {
            string code = SMSSecurityStepController.RandomString(6);
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
        public void GeneratSMSText()
        {
            InMemory_SMSSecurityStepValidationRepository repository = new InMemory_SMSSecurityStepValidationRepository();
            SMSSecurityStepController controller = GetSMSSecurityStepController(repository, new InMemory_SMSSecurityStepConfigRepository());
            Assert.AreEqual(controller.generateSMSText("test"), "Bitte tragen Sie folgenden den Code test im Webformular ein");
        }

        [TestMethod]
        public void Send_Mail()
        {
            string mobileNumber = "+41790000000";
            string plaintext = "Das ist ein Test";
            bool result = new SMSHandler().send(mobileNumber, plaintext);
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void Index_SaveValidationIntoRepository()
        {
            HttpContext.Current = MockHelpers.FakeHttpContext();
            HttpContext.Current.Session["ProviderId"] = providerId;
            HttpContext.Current.Session["ProjectId"] = projectId;

            string mobileNumber = "+41790000000";
            // Arrange
            InMemory_SMSSecurityStepValidationRepository repository = new InMemory_SMSSecurityStepValidationRepository();
            SMSSecurityStepController controller = GetSMSSecurityStepController(repository, new InMemory_SMSSecurityStepConfigRepository());

            // Act
            controller.Index(new SMSSecurityStepValidation_MobileNumber ()
            {
                MobileNumber = mobileNumber
            });

            // Assert
            IEnumerable<SMSSecurityStepValidation> SMSSecurityStepValidations = repository.GetAllSMSSecurityStepValidations();
            SMSSecurityStepValidation SMSSecurityStepValidation =
                SMSSecurityStepValidations.FirstOrDefault(essv => essv.MobileNumber == mobileNumber);
            Assert.IsNotNull(SMSSecurityStepValidation);
            Assert.AreEqual(SMSSecurityStepValidation.ProjectId, projectId);
        }

        [TestMethod]
        public void Check_Is_MobileInSession()
        {
            HttpContext.Current = MockHelpers.FakeHttpContext();
            string mobileNumber = "+41790000000";
            HttpContext.Current.Session["mobilenumber"] = mobileNumber;

            InMemory_SMSSecurityStepValidationRepository repository = new InMemory_SMSSecurityStepValidationRepository();
            SMSSecurityStepController controller = GetSMSSecurityStepController(repository, new InMemory_SMSSecurityStepConfigRepository());
            Assert.IsTrue(controller.isMobileNumberInSession(mobileNumber));
        }

        [TestMethod]
        public void CodeValidation_Get_AsksForIndexView()
        {
            HttpContext.Current = MockHelpers.FakeHttpContext();
            string mobileNumber = "+41790000000";
            HttpContext.Current.Session["mobilenumber"] = mobileNumber;
            // Arrange
            var controller = GetSMSSecurityStepController(new InMemory_SMSSecurityStepValidationRepository(), new InMemory_SMSSecurityStepConfigRepository());
            // Act
            ViewResult result = controller.CodeValidation();
            // Assert
            Assert.AreEqual("CodeValidation", result.ViewName);
        }

        [TestMethod]
        public void SMSSecurityStep_Status_NOTOPEN()
        {
            // Arrange
            var controller = GetSMSSecurityStepController(new InMemory_SMSSecurityStepValidationRepository(), new InMemory_SMSSecurityStepConfigRepository());
            // Act
            SMSSecurityStepValidation_Status result = controller.GetSMSSecurityStepValidationStatus(1, "ZZZ");
            // Assert
            Assert.AreEqual(result, SMSSecurityStepValidation_Status.NOTOPEN);
        }

        [TestMethod]
        public void SMSSecurityStep_Status_OPEN()
        {
            InMemory_SMSSecurityStepValidationRepository _repository = new InMemory_SMSSecurityStepValidationRepository();
            // Arrange
            var controller = GetSMSSecurityStepController(_repository, new InMemory_SMSSecurityStepConfigRepository());
            // Act

            _repository.CreateNewSMSSecurityStepValidation(
                new SMSSecurityStepValidation()
                {
                    ProjectId = 1,
                    ProviderId = "ZZZ",
                    StatusId = -1
                }
                );


            SMSSecurityStepValidation_Status result = controller.GetSMSSecurityStepValidationStatus(1, "ZZZ");
            // Assert
            Assert.AreEqual(result, SMSSecurityStepValidation_Status.OPEN);
        }

        [TestMethod]
        public void SMSSecurityStep_Status_VALID()
        {
            InMemory_SMSSecurityStepValidationRepository _repository = new InMemory_SMSSecurityStepValidationRepository();
            // Arrange
            var controller = GetSMSSecurityStepController(_repository, new InMemory_SMSSecurityStepConfigRepository());
            // Act

            _repository.CreateNewSMSSecurityStepValidation(
                new SMSSecurityStepValidation()
                {
                    ProjectId = 1,
                    ProviderId = "ZZZ",
                    StatusId = 1
                }
                );


            SMSSecurityStepValidation_Status result = controller.GetSMSSecurityStepValidationStatus(1, "ZZZ");
            // Assert
            Assert.AreEqual(result, SMSSecurityStepValidation_Status.VALID);
        }

        [TestMethod]
        public void SMSSecurityStep_Status_INVALID()
        {
            InMemory_SMSSecurityStepValidationRepository _repository = new InMemory_SMSSecurityStepValidationRepository();
            // Arrange
            var controller = GetSMSSecurityStepController(_repository, new InMemory_SMSSecurityStepConfigRepository());
            // Act

            _repository.CreateNewSMSSecurityStepValidation(
                new SMSSecurityStepValidation()
                {
                    ProjectId = 1,
                    ProviderId = "ZZZ",
                    StatusId = 0
                }
                );

            SMSSecurityStepValidation_Status result = controller.GetSMSSecurityStepValidationStatus(1, "ZZZ");
            // Assert
            Assert.AreEqual(result, SMSSecurityStepValidation_Status.INVALID);
        }

        [TestMethod]
        public void SMSSecurityStep_Status_Update()
        {
            InMemory_SMSSecurityStepValidationRepository _repository = new InMemory_SMSSecurityStepValidationRepository();
            _repository.CreateNewSMSSecurityStepValidation(
                new SMSSecurityStepValidation()
                {
                    ProjectId = 1,
                    ProviderId = "ZZZ",
                    StatusId = 1
                }
                );
            _repository.UpdateSMSSecurityStepValidation(new SMSSecurityStepValidation()
            {
                ProjectId = 1,
                ProviderId = "ZZZ",
                StatusId = 122
            });

            SMSSecurityStepValidation essv = _repository.GetSMSSecurityStepValidationForValid(1,"ZZZ");
            Assert.AreEqual(essv.StatusId, 122);

        }

    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   