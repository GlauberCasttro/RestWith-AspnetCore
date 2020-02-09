﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestWebApiAspnetCore.Business;
using RestWebApiAspnetCore.Model;
using RestWebApiAspnetCore.Repository;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace RestWebApiAspnetCore.Controllers
{
    [ApiVersion("1")]
    public class LoginController : Controller
    {
        private ILoginBusiness _loginBusiness;
        public LoginController(ILoginBusiness  business)
        {
            _loginBusiness = business;
        }

        [AllowAnonymous]
        [HttpPost]
        public Object Post([FromBody]Usuario usuario)
        {
            if (usuario == null) return BadRequest();
            return _loginBusiness.FindByLogin(usuario);
        }
    }
}