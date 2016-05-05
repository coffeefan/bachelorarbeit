 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PassportSecurityStep;
using PassportSecurityStep.Controllers;
using PassportSecurityStep.Models;
using System.Web.Routing;
using System.Web;
using System.Security.Principal;
using PassportSecurityStep.Tests.Models;
using System.IO;
using System.Web.SessionState;

namespace PassportSecurityStep.Tests.Controllers
{
    [TestClass]
    public class PassportSecurityStepControllerTest
    {
        private static int projectId = 1;
        private static string providerId = "AAA";

        [ClassInitialize()]
        public static void PassportSecurityStepControllerTestnitialize(TestContext testContext)
        {

        }      




        PassportSecurityStepValidation GetPassportSecurityStepValidation(int projectId, string providerId, string passportNumber, int statusId)
        {
            return new PassportSecurityStepValidation()
            {
                PassportSecurityStepValidationId = 1,
                ProjectId = projectId,
                ProviderId = providerId,
                PassportNumber = passportNumber,
                PassportSendCount=1,                
                CodeEntered = "",
                Created = new DateTime(2016, 1, 1, 12, 00, 00),
                StatusId = statusId
            };

        }
        PassportSecurityStepValidation GetPassportSecurityStepValidation()
        {
            return GetPassportSecurityStepValidation(1, "AAA", "C1234567", -1);
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

        private static PassportSecurityStepController GetPassportSecurityStepController(IPassportSecurityStepValidationRepository validationRepo,
            IPassportSecurityStepConfigRepository configRepo)
        {
            PassportSecurityStepController controller = new PassportSecurityStepController(validationRepo, configRepo);

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
            PassportSecurityStepController controller = new PassportSecurityStepController(
                new InMemory_PassportSecurityStepValidationRepository(), new InMemory_PassportSecurityStepConfigRepository());

            // Act
            ActionResult result = controller.Index() as ActionResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Index_Get_AsksForIndexView()
        {
            // Arrange
            var controller = GetPassportSecurityStepController(new InMemory_PassportSecurityStepValidationRepository(),
                new InMemory_PassportSecurityStepConfigRepository());
            // Act
            //ViewResult result = controller.Index();
            // Assert
            Assert.AreEqual("Index", "Index");
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
        public void passportCodeinNumbersA()
        {
            char test = 'A';
            string result = new PassportHandler().characterToNumber(test);
            Assert.AreEqual(result, "0");
        }

        [TestMethod]
        public void passportCodeinNumbersD()
        {
            char test = 'D';
            string result = new PassportHandler().characterToNumber(test);
            Assert.AreEqual(result, "3");
        }

        [TestMethod]
        public void passportCodeinNumbersC()
        {
            char test = 'C';
            string result = new PassportHandler().characterToNumber(test);
            Assert.AreEqual(result, "2");
        }

        [TestMethod]
        public void passportCodeinNumbersSpecial()
        {
            char test = '<';
            string result = new PassportHandler().characterToNumber(test);
            Assert.AreEqual(result, "0");
        }

        [TestMethod]
        public void StringCodeToNumber()
        {
            string passportCode="C1234567<";
            string result = new PassportHandler().stringCodeToNumber(passportCode);
            Assert.AreEqual(result, "212345670");
        }

        [TestMethod]
        public void makeCheckCode()
        {
            string passportCode = "C1234567<";
            char result = new PassportHandler().makeCheckCode(passportCode);
            Assert.AreEqual(result, '0');
        }

        [TestMethod]
        public void checkCheckCode_VALID()
        {
            string passportCode = "C1234567<";
            char checkcode = '0';
            bool result = new PassportHandler().checkCheckCode(passportCode,checkcode);
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void checkCheckCode_INVALID()
        {
            string passportCode = "C5234567<";
            char checkcode = '0';
            bool result = new PassportHandler().checkCheckCode(passportCode, checkcode);
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void CheckTextWithCheckCode_VALID()
        {
            string passportCode = "C1234567<0";
            bool result = new PassportHandler().checkTextWithCheckCode(passportCode);
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void CheckTextWithCheckCode_INVALID()
        {
            string passportCode = "C1434567<0";
            bool result = new PassportHandler().checkTextWithCheckCode(passportCode);
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void checkCheckPassport_INVALID()
        {
            string passportNumber = "C1234567<0";
            string birthday = "6012317";
            string expiryDate = "0109110";
            char endCheckcode = '6';
            bool result = new PassportHandler().checkPassport(passportNumber, birthday, expiryDate, endCheckcode);
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void checkCheckPassport_VALID()
        {
            string passportNumber = "c7735326<3";
            string birthday = "8609052";
            string expiryDate = "2502162";
            char endCheckcode = '8';
            bool result = new PassportHandler().checkPassport(passportNumber, birthday, expiryDate, endCheckcode);
            Assert.AreEqual(result, true);
        }






        [TestMethod]
        public void PassportSecurityStep_Status_VALID()
        {
            InMemory_PassportSecurityStepValidationRepository _repository = new InMemory_PassportSecurityStepValidationRepository();
            // Arrange
            var controller = GetPassportSecurityStepController(_repository, new InMemory_PassportSecurityStepConfigRepository());
            // Act

            _repository.CreateNewPassportSecurityStepValidation(
                new PassportSecurityStepValidation()
                {
                    ProjectId = 1,
                    ProviderId = "ZZZ",
                    StatusId = 1
                }
                );


            PassportSecurityStepValidation_Status result = controller.GetPassportSecurityStepValidationStatus(1, "ZZZ");
            // Assert
            Assert.AreEqual(result, PassportSecurityStepValidation_Status.VALID);
        }

        [TestMethod]
        public void PassportSecurityStep_Status_INVALID()
        {
            InMemory_PassportSecurityStepValidationRepository _repository = new InMemory_PassportSecurityStepValidationRepository();
            // Arrange
            var controller = GetPassportSecurityStepController(_repository, new InMemory_PassportSecurityStepConfigRepository());
            // Act

            _repository.CreateNewPassportSecurityStepValidation(
                new PassportSecurityStepValidation()
                {
                    ProjectId = 1,
                    ProviderId = "ZZZ",
                    StatusId = 0
                }
                );

            PassportSecurityStepValidation_Status result = controller.GetPassportSecurityStepValidationStatus(1, "ZZZ");
            // Assert
            Assert.AreEqual(result, PassportSecurityStepValidation_Status.INVALID);
        }

        [TestMethod]
        public void PassportSecurityStep_Status_Update()
        {
            InMemory_PassportSecurityStepValidationRepository _repository = new InMemory_PassportSecurityStepValidationRepository();
            _repository.CreateNewPassportSecurityStepValidation(
                new PassportSecurityStepValidation()
                {
                    ProjectId = 1,
                    ProviderId = "ZZZ",
                    StatusId = 1
                }
                );
            _repository.UpdatePassportSecurityStepValidation(new PassportSecurityStepValidation()
            {
                ProjectId = 1,
                ProviderId = "ZZZ",
                StatusId = 122
            });

            PassportSecurityStepValidation essv = _repository.GetPassportSecurityStepValidationForValid(1,"ZZZ");
            Assert.AreEqual(essv.StatusId, 122);

        }

    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   