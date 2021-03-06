﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SmartCity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace SmartCity.Controllers
{
    public class BaseApiController : ApiController
    {
        private ModelFactory _modelFactory;
        protected ModelFactory TheModelFactory
        {
            get
            {
                if (_modelFactory == null)
                {
                    _modelFactory = new ModelFactory(this.Request, this.UserManager);
                }
                return _modelFactory;
            }
        }
        private ApplicationUserManager userManager;

        protected ApplicationUserManager UserManager
        {
            get
            {
                return userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        public BaseApiController() : base()
        {
        }

        public BaseApiController(ApplicationUserManager userManager)
        {
            this.userManager = userManager;
        }

     

        protected IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
