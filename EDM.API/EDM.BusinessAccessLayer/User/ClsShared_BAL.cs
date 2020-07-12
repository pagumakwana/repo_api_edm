﻿using EDM.DataAccessLayer.User;
using EDM.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDM.BusinessAccessLayer.User
{
    public class ClsShared_BAL : IDisposable
    {
        public List<ClsGlobalSearch> GlobalSearch()
        {
            using (ClsShared_DAL obj = new ClsShared_DAL())
            {
                return obj.GlobalSearch();
            }
        }

        public void Dispose()
        {

        }
    }
}
