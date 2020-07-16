﻿using EDM.DataAccessLayer.User;
using EDM.Models.User;
using System;
using System.Collections.Generic;

namespace EDM.BusinessAccessLayer.User
{
    public class ClsService_BAL : IDisposable
    {
        public List<ClsCustomServiceList> GetServiceListByCategory(int StartCount, int EndCount, string CategoryName)
        {
            using (ClsService_DAL obj = new ClsService_DAL())
            {
                return obj.GetServiceListByCategory(StartCount, EndCount, CategoryName);
            }
        }

        public List<ClsCustomServiceDetails> GetCustomServiceDetails(Int64 ServiceID)
        {
            using (ClsService_DAL obj = new ClsService_DAL())
            {
                return obj.GetCustomServiceDetails(ServiceID);
            }
        }

        public void Dispose()
        {

        }
    }
}
