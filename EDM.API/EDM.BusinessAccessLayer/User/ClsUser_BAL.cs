﻿using EDM.DataAccessLayer.User;
using EDM.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDM.BusinessAccessLayer.User
{
    public class ClsUser_BAL : IDisposable
    {
        public string SignUp(ClsUserDetails ObjUser)
        {
            using (ClsUser_DAL obj = new ClsUser_DAL())
            {
                return obj.SignUp(ObjUser);
            }
        }

        public List<ClsUserDetails> SignIn(ClsUserSignIn ObjUser)
        {
            using (ClsUser_DAL obj = new ClsUser_DAL())
            {
                return obj.SignIn(ObjUser);
            }
        }

        public List<ClsUserDetails> GetProducersList(Int64 UserID, int StartCount, int EndCount)
        {
            using (ClsUser_DAL obj = new ClsUser_DAL())
            {
                return obj.GetProducersList(UserID, StartCount, EndCount);
            }
        }

        public List<ClsProducerTrackAndBeatList> GetProducerTrackAndBeatList(Int64 ProducersID, Int64 UserID)
        {
            using (ClsUser_DAL obj = new ClsUser_DAL())
            {
                return obj.GetProducerTrackAndBeatList(ProducersID, UserID);
            }
        }

        public List<ClsProducersServiceList> GetProducersCustomServicesList(Int64 ProducersID)
        {
            using (ClsUser_DAL obj = new ClsUser_DAL())
            {
                return obj.GetProducersCustomServicesList(ProducersID);
            }
        }

        public void Dispose()
        {

        }
    }
}
