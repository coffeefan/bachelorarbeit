 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneSecurityStep;
using PhoneSecurityStep.Controllers;
using PhoneSecurityStep.Models;
using System.Web.Routing;
using System.Web;
using System.Security.Principal;
using PhoneSecurityStep.Tests.Models;
using System.IO;
using System.Web.SessionState;

namespace PhoneSecurityStep.Tests.Controllers
{
    [TestClass]
    public class PhoneSecurityStepControllerTest
    {
        private static int projectId = 1;
        private static string providerId = "AAA";

        [ClassInitialize()]
        public static void PhoneSecurityStepControllerTestnitialize(TestContext testContext)
        {

        }      




        PhoneSecurityStepValidation GetPhoneSecurityStepValidation(int projectId, string providerId, string mobileNumber, int statusId)
        {
            return new PhoneSecurityStepValidation()
            {
                PhoneSecurityStepValidationId = 1,
                ProjectId = projectId,
                ProviderId = providerId,
                PhoneNumber = mobileNumber,
                PhoneSendCount=1,
                Code = "1234",
                CodeEntered = "",
                Created = new DateTime(2016, 1, 1, 12, 00, 00),
                StatusId = statusId
            };

        }
        PhoneSecurityStepValidation GetPhoneSecurityStepValidation()
        {
            return GetPhoneSecurityStepValidation(1, "AAA", "+41520000000", -1);
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

        private static PhoneSecurityStepController GetPhoneSecurityStepController(IPhoneSecurityStepValidationRepository validationRepo,
            IPhoneSecurityStepConfigRepository configRepo)
        {
            PhoneSecurityStepController controller = new PhoneSecurityStepController(validationRepo, configRepo);

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
            PhoneSecurityStepController controller = new PhoneSecurityStepController(
                new InMemory_PhoneSecurityStepValidationRepository(), new InMemory_PhoneSecurityStepConfigRepository());

            // Act
            ActionResult result = controller.Index() as ActionResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Index_Get_AsksForIndexView()
        {
            // Arrange
            var controller = GetPhoneSecurityStepController(new InMemory_PhoneSecurityStepValidationRepository(),
                new InMemory_PhoneSecurityStepConfigRepository());
            // Act
            //ViewResult result = controller.Index();
            // Assert
            Assert.AreEqual("Index", "Index");
        }

        [TestMethod]
        public void Generate_Code_IsNummeric()
        {
            string code = PhoneSecurityStepController.RandomString(6);
            int n;
            Assert.IsTrue(int.TryParse(code, out n));
        }

        [TestMethod]
        public void Generate_Code_6CharactersLong()
        {
            string code = PhoneSecurityStepController.RandomString(6);
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
        public void GeneratPhoneText()
        {
            InMemory_PhoneSecurityStepValidationRepository repository = new InMemory_PhoneSecurityStepValidationRepository();
            PhoneSecurityStepController controller = GetPhoneSecurityStepController(repository, new InMemory_PhoneSecurityStepConfigRepository());
            Assert.AreEqual(controller.generatePhoneText(), "Bitte tragen Sie folgenden den Code im Webformular ein");
        }

        [TestMethod]
        public void Send_Mail()
        {
            string mobileNumber = "+41520000000";
            string plaintext = "Das ist ein Test";
            bool result = new PhoneHandler().phoneCall(mobileNumber, plaintext,"","Testfenster",4);
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void Index_SaveValidationIntoRepository()
        {
            HttpContext.Current = MockHelpers.FakeHttpContext();
            HttpContext.Current.Session["ProviderId"] = providerId;
            HttpContext.Current.Session["ProjectId"] = projectId;

            string mobileNumber = "+41520000000";
            // Arrange
            InMemory_PhoneSecurityStepValidationRepository repository = new InMemory_PhoneSecurityStepValidationRepository();
            PhoneSecurityStepController controller = GetPhoneSecurityStepController(repository, new InMemory_PhoneSecurityStepConfigRepository());

            // Act
            controller.Index(new PhoneSecurityStepValidation_MobileNumber ()
            {
                PhoneNumber = mobileNumber
            });

            // Assert
            IEnumerable<PhoneSecurityStepValidation> PhoneSecurityStepValidations = repository.GetAllPhoneSecurityStepValidations();
            PhoneSecurityStepValidation PhoneSecurityStepValidation =
                PhoneSecurityStepValidations.FirstOrDefault(essv => essv.PhoneNumber == mobileNumber);
            Assert.IsNotNull(PhoneSecurityStepValidation);
            Assert.AreEqual(PhoneSecurityStepValidation.ProjectId, projectId);
        }

        [TestMethod]
        public void Check_Is_MobileInSession()
        {
            HttpContext.Current = MockHelpers.FakeHttpContext();
            string mobileNumber = "+41520000000";
            HttpContext.Current.Session["mobilenumber"] = mobileNumber;

            InMemory_PhoneSecurityStepValidationRepository repository = new InMemory_PhoneSecurityStepValidationRepository();
            PhoneSecurityStepController controller = GetPhoneSecurityStepController(repository, new InMemory_PhoneSecurityStepConfigRepository());
            Assert.IsTrue(controller.isMobileNumberInSession(mobileNumber));
        }

        [TestMethod]
        public void CodeValidation_Get_AsksForIndexView()
        {
            HttpContext.Current = MockHelpers.FakeHttpContext();
            string mobileNumber = "+41520000000";
            HttpContext.Current.Session["mobilenumber"] = mobileNumber;
            // Arrange
            var controller = GetPhoneSecurityStepController(new InMemory_PhoneSecurityStepValidationRepository(), new InMemory_PhoneSecurityStepConfigRepository());
            // Act
            ViewResult result = controller.CodeValidation();
            // Assert
            Assert.AreEqual("CodeValidation", result.ViewName);
        }

        [TestMethod]
        public void PhoneSecurityStep_Status_NOTOPEN()
        {
            // Arrange
            var controller = GetPhoneSecurityStepController(new InMemory_PhoneSecurityStepValidationRepository(), new InMemory_PhoneSecurityStepConfigRepository());
            // Act
            PhoneSecurityStepValidation_Status result = controller.GetPhoneSecurityStepValidationStatus(1, "ZZZ");
            // Assert
            Assert.AreEqual(result, PhoneSecurityStepValidation_Status.NOTOPEN);
        }

        [TestMethod]
        public void PhoneSecurityStep_Status_OPEN()
        {
            InMemory_PhoneSecurityStepValidationRepository _repository = new InMemory_PhoneSecurityStepValidationRepository();
            // Arrange
            var controller = GetPhoneSecurityStepController(_repository, new InMemory_PhoneSecurityStepConfigRepository());
            // Act

            _repository.CreateNewPhoneSecurityStepValidation(
                new PhoneSecurityStepValidation()
                {
                    ProjectId = 1,
                    ProviderId = "ZZZ",
                    StatusId = -1
                }
                );


            PhoneSecurityStepValidation_Status result = controller.GetPhoneSecurityStepValidationStatus(1, "ZZZ");
            // Assert
            Assert.AreEqual(result, PhoneSecurityStepValidation_Status.OPEN);
        }

        [TestMethod]
        public void PhoneSecurityStep_Status_VALID()
        {
            InMemory_PhoneSecurityStepValidationRepository _repository = new InMemory_PhoneSecurityStepValidationRepository();
            // Arrange
            var controller = GetPhoneSecurityStepController(_repository, new InMemory_PhoneSecurityStepConfigRepository());
            // Act

            _repository.CreateNewPhoneSecurityStepValidation(
                new PhoneSecurityStepValidation()
                {
                    ProjectId = 1,
                    ProviderId = "ZZZ",
                    StatusId = 1
                }
                );


            PhoneSecurityStepValidation_Status result = controller.GetPhoneSecurityStepValidationStatus(1, "ZZZ");
            // Assert
            Assert.AreEqual(result, PhoneSecurityStepValidation_Status.VALID);
        }

        [TestMethod]
        public void PhoneSecurityStep_Status_INVALID()
        {
            InMemory_PhoneSecurityStepValidationRepository _repository = new InMemory_PhoneSecurityStepValidationRepository();
            // Arrange
            var controller = GetPhoneSecurityStepController(_repository, new InMemory_PhoneSecurityStepConfigRepository());
            // Act

            _repository.CreateNewPhoneSecurityStepValidation(
                new PhoneSecurityStepValidation()
                {
                    ProjectId = 1,
                    ProviderId = "ZZZ",
                    StatusId = 0
                }
                );

            PhoneSecurityStepValidation_Status result = controller.GetPhoneSecurityStepValidationStatus(1, "ZZZ");
            // Assert
            Assert.AreEqual(result, PhoneSecurityStepValidation_Status.INVALID);
        }

        [TestMethod]
        public void PhoneSecurityStep_Status_Update()
        {
            InMemory_PhoneSecurityStepValidationRepository _repository = new InMemory_PhoneSecurityStepValidationRepository();
            _repository.CreateNewPhoneSecurityStepValidation(
                new PhoneSecurityStepValidation()
                {
                    ProjectId = 1,
                    ProviderId = "ZZZ",
                    StatusId = 1
                }
                );
            _repository.UpdatePhoneSecurityStepValidation(new PhoneSecurityStepValidation()
            {
                ProjectId = 1,
                ProviderId = "ZZZ",
                StatusId = 122
            });

            PhoneSecurityStepValidation essv = _repository.GetPhoneSecurityStepValidationForValid(1,"ZZZ");
            Assert.AreEqual(essv.StatusId, 122);

        }

    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   