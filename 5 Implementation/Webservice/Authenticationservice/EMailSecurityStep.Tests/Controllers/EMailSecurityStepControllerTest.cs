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

namespace EMailSecurityStep.Tests.Controllers
{
    [TestClass]
    public class EMailSecurityStepControllerTest
    {
        EMailSecurityStepValidation GetEMailSecurityStepValidation(int projectId, string providerId,string email,int statusId)
        {
            return new EMailSecurityStepValidation()
            {
                EMailSecurityStepId = 1,
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

        private static EMailSecurityStepController GetHomeController(IEMailSecurityStepValidationRepository repository)
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
            var controller = GetHomeController(new InMemory_EMailSecurityStepValidationRepository());
            // Act
            ViewResult result = controller.Index();
            // Assert
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}
