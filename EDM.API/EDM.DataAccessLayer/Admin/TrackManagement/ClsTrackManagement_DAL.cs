using EDM.Models.Admin.TrackManagement;
using EDM.Models.Common;
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
                objDBParameter = new DBParameter("@BMP", ObjTrackDetails.BMP, DbType.Int16);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@DAW", ObjTrackDetails.DAW, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Duration", ObjTrackDetails.Duration, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Price", ObjTrackDetails.Price, DbType.Decimal);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@PriceWithProjectFiles", ObjTrackDetails.PriceWithProjectFiles, DbType.Decimal);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@IsActive", ObjTrackDetails.IsActive, DbType.Boolean);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@IsVocals", ObjTrackDetails.IsVocals, DbType.Boolean);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@IsTrack", ObjTrackDetails.IsTrack, DbType.Boolean);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@TrackStatus", ObjTrackDetails.TrackStatus, DbType.Boolean);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@CreatedBy", ObjTrackDetails.CreatedBy, DbType.String);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                Int64 Ref_Track_ID = Convert.ToInt64(objDbHelper.ExecuteScalar(Constant.AddModifyTrackDetails, ObJParameterCOl, CommandType.StoredProcedure));

                if (Ref_Track_ID > 0)
                {
                    ObjTrackDetails.FileManager.ForEach(File =>
                    {
                        DBParameterCollection ObJParameterCOl1 = new DBParameterCollection();
                        DBParameter objDBParameter1 = new DBParameter("@FileManagerID", File.FileManagerID, DbType.Int64);
                        ObJParameterCOl1.Add(objDBParameter1);
                        objDBParameter1 = new DBParameter("@ModuleID", Ref_Track_ID, DbType.Int64);
                        ObJParameterCOl1.Add(objDBParameter1);
                        objDBParameter1 = new DBParameter("@ModuleType", File.ModuleType, DbType.String);
                        ObJParameterCOl1.Add(objDBParameter1);
                        objDBParameter1 = new DBParameter("@FileIdentifier", File.FileIdentifier, DbType.String);
                        ObJParameterCOl1.Add(objDBParameter1);
                        objDBParameter1 = new DBParameter("@FileName", File.FileName, DbType.String);
                        ObJParameterCOl1.Add(objDBParameter1);
                        objDBParameter1 = new DBParameter("@FilePath", File.FilePath, DbType.String);
                        ObJParameterCOl1.Add(objDBParameter1);
                        objDBParameter1 = new DBParameter("@FileExtension", File.FileExtension, DbType.String);
                        ObJParameterCOl1.Add(objDBParameter1);
                        objDBParameter1 = new DBParameter("@FileType", File.FileType, DbType.String);
                        ObJParameterCOl1.Add(objDBParameter1);
                        objDBParameter1 = new DBParameter("@FileSize", File.FileSize, DbType.Int64);
                        ObJParameterCOl1.Add(objDBParameter1);
                        objDBParameter1 = new DBParameter("@FileSequence", File.Sequence, DbType.Int32);
                        ObJParameterCOl1.Add(objDBParameter1);

                        objDbHelper.ExecuteScalar(Constant.SaveModuleFile, ObJParameterCOl1, CommandType.StoredProcedure).ToString();
                    });
                }

                if (Ref_Track_ID > 0 && ObjTrackDetails.Ref_Track_ID == 0)
                {
                    return "TRACKADDED";
                }
                else if (Ref_Track_ID > 0 && ObjTrackDetails.Ref_Track_ID > 0)
                {
                    return "TRACKUPDATED";
                }
                else
                {
                    return "TRACKEXISTS";
                }
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
                DataSet ds = objDbHelper.ExecuteDataSet(Constant.GetTrackDetails, ObJParameterCOl, CommandType.StoredProcedure);
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
                                Key = Row.Field<string>("TrackKey"),
                                Tag = Row.Field<string>("Tag"),
                                Duration = Row.Field<string>("Duration"),
                                Price = Row.Field<decimal>("Price"),
                                PriceWithProjectFiles = Row.Field<decimal>("PriceWithProjectFiles"),
                                BMP = Row.Field<int>("BMP"),
                                DAW = Row.Field<string>("DAW"),
                                TrackStatus = Row.Field<string>("TrackStatus"),
                                Reason = Row.Field<string>("Reason"),
                                IsVocals = Row.Field<Boolean>("IsVocals"),
                                IsTrack = Row.Field<Boolean>("IsTrack"),
                                IsActive = Row.Field<Boolean>("IsActive"),
                                CreatedBy = Row.Field<String>("CreatedBy"),
                                FileManager = ds.Tables[1].AsEnumerable().Where(x => x.Field<Int64>("ModuleID") == Row.Field<Int64>("Ref_Track_ID")).Select(Row1 =>
                                     new ClsFileManager
                                     {
                                         FileManagerID = Row1.Field<Int64>("Ref_FileManager_ID"),
                                         FileIdentifier = Row1.Field<string>("FileIdentifier"),
                                         FileName = Row1.Field<string>("FileName"),
                                         FilePath = Row1.Field<string>("FilePath"),
                                         FileExtension = Row1.Field<string>("FileExtension"),
                                         FileSize = Row1.Field<Int64>("FileSize"),
                                         FileType = Row1.Field<string>("FileType"),
                                         Sequence = Row1.Field<int>("Sequence"),
                                     }).ToList(),
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

        public string ManageTrack(string TrackIDs, string Action)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@TrackIDs", TrackIDs, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Action", Action, DbType.String);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                return Convert.ToString(objDbHelper.ExecuteScalar(Constant.ManageTrack, ObJParameterCOl, CommandType.StoredProcedure));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string TrackApproveAndRejact(ClsApproveAndRejact ObjApproveAndRejact)
        {
            try
            {
                DBParameterCollection ObJParameterCOl = new DBParameterCollection();
                DBParameter objDBParameter = new DBParameter("@TrackIDs", ObjApproveAndRejact.TrackIDs, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Action", ObjApproveAndRejact.Action, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@Reason", ObjApproveAndRejact.Reason, DbType.String);
                ObJParameterCOl.Add(objDBParameter);
                objDBParameter = new DBParameter("@ActionBy", ObjApproveAndRejact.ActionBy, DbType.String);
                ObJParameterCOl.Add(objDBParameter);

                DBHelper objDbHelper = new DBHelper();
                return Convert.ToString(objDbHelper.ExecuteScalar(Constant.TrackApproveAndRejact, ObJParameterCOl, CommandType.StoredProcedure));
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
