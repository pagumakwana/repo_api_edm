﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDM.Models.Common
{
    public class Constant
    {
        public const string RegisterGuest = "[dbo].[RegisterGuest]"; 
        public const string RegisterCustomer = "[dbo].[RegisterCustomer]"; 
        public const string SignInCustomer = "[dbo].[SignInCustomer]"; 
        public const string ForgotPassword = "[dbo].[ForgotPassword]";
        public const string ValidateUser = "[dbo].[ValidateUser]";
        public const string RequestOTP = "[dbo].[RequestOTP]";
        public const string SearchKeyword = "[dbo].[SearchKeyword]";
        public const string UpdateCustomerProfile = "[dbo].[UpdateCustomerProfile]";

        //Gener AddModify
        public const string GenerAddModify = "[dbo].[GenerAddModify]";
        //Gener List
        public const string GenerList = "[dbo].[GenerList]";
        public const string AddModifyCategory = "[dbo].[AddModifyCategory]";
        public const string AddMasterFile = "[dbo].[AddMasterFile]";
        public const string GetCategoryList = "[dbo].[GetCategoryList]";
    }

}
