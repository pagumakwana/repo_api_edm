using EDM.Models.Admin.TrackManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDM.DataAccessLayer.Admin.TrackManagement
{
    public class ClsTrackManagement_DAL : IDisposable
    {
        public string AddModifyTrackDetails(ClsTrackDetails ObjTrackDetails)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@Ref_Track_ID", ObjTrackDetails.Ref_Track_ID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Ref_Category_ID", ObjTrackDetails.Ref_Category_ID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@TrackType", ObjTrackDetails.TrackType, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@TrackName", ObjTrackDetails.TrackName, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Bio", ObjTrackDetails.Bio, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Mood", ObjTrackDetails.Mood, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Key", ObjTrackDetails.Key, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Tag", ObjTrackDetails.Tag, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@BigImageUrl", ObjTrackDetails.BigImageUrl, DbType.Boolean);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@ThumbnailImageUrl", ObjTrackDetails.ThumbnailImageUrl, DbType.Boolean);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@BMP", ObjTrackDetails.BMP, DbType.Int16);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@DAW", ObjTrackDetails.DAW, DbType.Int16);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Duration", ObjTrackDetails.Duration, DbType.Int16);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Price", ObjTrackDetails.Price, DbType.Decimal);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@PriceWithProjectFiles", ObjTrackDetails.PriceWithProjectFiles, DbType.Decimal);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@ProjectFilesUrl", ObjTrackDetails.ProjectFilesUrl, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@StemsUrl", ObjTrackDetails.StemsUrl, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@MasterFileUrl", ObjTrackDetails.MasterFileUrl, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@UnmasteredFileUrl", ObjTrackDetails.UnmasteredFileUrl, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@MixdowFileUrl", ObjTrackDetails.MixdowFileUrl, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@IsActive", ObjTrackDetails.IsActive, DbType.Boolean);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@IsVocals", ObjTrackDetails.IsVocals, DbType.Boolean);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@IsTrack", ObjTrackDetails.IsTrack, DbType.Boolean);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@CreatedBy", ObjTrackDetails.CreatedBy, DbType.String);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                return Convert.ToString(objDbHelper.ExecuteScalar("[dbo].[AddModifyTrackDetails]", ObJParameterCOl, CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ClsTrackDetails> GetTrackDetails(Int64 TrackID)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@TrackID", TrackID, DbType.Int64);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                DataSet ds = objDbHelper.ExecuteDataSet("[dbo].[GetTrackDetails]", ObJParameterCOl, CommandType.StoredProcedure);
                List<ClsTrackDetails> objUserMasterData = new List<ClsTrackDetails>();

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        IList<ClsTrackDetails> List = ds.Tables[0].AsEnumerable().Select(Row =>
                            new ClsTrackDetails
                            {
                                Ref_Track_ID = Row.Field<Int64>("Ref_Track_ID"),
                                Ref_Category_ID = Row.Field<Int64>("Ref_Category_ID"),
                                TrackName = Row.Field<string>("TrackName"),
                                TrackType = Row.Field<string>("TrackType"),
                                Bio = Row.Field<string>("Bio"),
                                Mood = Row.Field<string>("Mood"),
                                Key = Row.Field<string>("Key"),
                                Tag = Row.Field<string>("Tag"),
                                ThumbnailImageUrl = Row.Field<string>("ThumbnailImageUrl"),
                                BigImageUrl = Row.Field<string>("BigImageUrl"),
                                Duration = Row.Field<int>("Duration"),
                                Price = Row.Field<decimal>("Price"),
                                PriceWithProjectFiles = Row.Field<decimal>("PriceWithProjectFiles"),
                                BMP = Row.Field<int>("BMP"),
                                DAW = Row.Field<int>("DAW"),
                                ProjectFilesUrl = Row.Field<string>("ProjectFilesUrl"),
                                StemsUrl = Row.Field<string>("StemsUrl"),
                                MasterFileUrl = Row.Field<string>("MasterFileUrl"),
                                UnmasteredFileUrl = Row.Field<string>("UnmasteredFileUrl"),
                                MixdowFileUrl = Row.Field<string>("MixdowFileUrl"),
                                IsVocals = Row.Field<Boolean>("IsVocals"),
                                IsTrack = Row.Field<Boolean>("IsTrack"),
                                IsActive = Row.Field<Boolean>("IsActive"),
                            }).ToList();
                        objUserMasterData.AddRange(List);
                    }
                }
                return objUserMasterData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {

        }
    }
}
