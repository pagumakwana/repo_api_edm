﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using EDM.Models.User;
using EDM.BusinessAccessLayer.User;

namespace EDM.API.Controllers.User
{
    [RoutePrefix("api/EDM/User")]
    public class UserController : ApiController
    {
        [Route("User/SignUp")]
        [HttpPost]
        public string SignUp(ClsUserSignUp ObjUser)
        {
            using (ClsUser_BAL obj = new ClsUser_BAL())
            {
                return obj.SignUp(ObjUser);
            }
        }

        [Route("User/SignIn")]
        [HttpPost]
        public List<ClsUserSignUp> SignIn(ClsUserSignIn ObjUser)
        {
            using (ClsUser_BAL obj = new ClsUser_BAL())
            {
                return obj.SignIn(ObjUser);
            }
        }
    }
}