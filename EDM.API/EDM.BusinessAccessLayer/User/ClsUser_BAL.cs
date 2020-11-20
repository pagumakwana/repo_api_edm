using EDM.DataAccessLayer.User;
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
        public List<ClsTicketType> GetTicketTypeList()
        {
            using (ClsUser_DAL obj = new ClsUser_DAL())
            {
                return obj.GetTicketTypeList();
            }
        }
        public string AddModifyUserTicket(ClsTicketDetails ObjTicket)
        {
            using (ClsUser_DAL obj = new ClsUser_DAL())
            {
                return AddModifyUserTicket(ObjTicket);
            }
        }

        public List<ClsTicketDetails> GetUsereTicketList(Int64 UserID = 0, int StartCount = 0, int EndCount = 0)
        {
            using (ClsUser_DAL obj = new ClsUser_DAL())
            {
                return obj.GetUsereTicketList(UserID, StartCount, EndCount);
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

        public List<ClsUserDetails> GetAvailableProducersForServices(Int64 UserID, Int64 ServiceID, int StartCount, int EndCount)
        {
            using (ClsUser_DAL obj = new ClsUser_DAL())
            {
                return obj.GetAvailableProducersForServices(UserID, ServiceID, StartCount, EndCount);
            }
        }

        public void Dispose()
        {

        }
    }
}
