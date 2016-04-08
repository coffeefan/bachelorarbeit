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
        public static void EMailSecurityStepControllerTestnitialize(TestContext testContext) {
            
        }




        EMailSecurityStepValidation GetEMailSecurityStepValidation(int projectId, string providerId,string email,int statusId)
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
            ViewResult result = controller.Index();
            // Assert
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void Generate_Code_IsNummeric()
        {
            string code=EMailSecurityStepController.RandomString(6);
            int n;            
            Assert.IsTrue(int.TryParse(code,out n));
        }

        [TestMethod]
        public void Generate_Code_6CharactersLong()
        {
            string code = EMailSecurityStepController.RandomString(6);
            Assert.AreEqual(code.Length,6);
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
        public void Step2_SaveValidationIntoRepository()
        {
            HttpContext.Current = MockHelpers.FakeHttpContext();
            HttpContext.Current.Session["ProviderId"] = providerId;
            HttpContext.Current.Session["ProjectId"] = projectId;

            string email = "c.bachmann@inaffect.net";
            // Arrange
            InMemory_EMailSecurityStepValidationRepository repository = new InMemory_EMailSecurityStepValidationRepository();
            EMailSecurityStepController controller = GetEMailSecurityStepController(repository);

            


            // Act
            controller.Step2(email);

            // Assert
            IEnumerable<EMailSecurityStepValidation> eMailSecurityStepValidations = repository.GetAllEMailSecurityStepValidations();
            EMailSecurityStepValidation eMailSecurityStepValidation = 
                eMailSecurityStepValidations.FirstOrDefault(essv => essv.EMail == email);
            Assert.IsNotNull(eMailSecurityStepValidation);
            Assert.AreEqual(eMailSecurityStepValidation.ProjectId,projectId);
        }
    }
}
