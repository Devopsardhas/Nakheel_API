using BUSINESS_LOGIC.ErrorLogs;
using IBUSINESS_LOGIC.IBusinessLogic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BUSINESS_LOGIC.BusinessLogic
{
    public class CommonMediaUploadRepo : ICommonMediaUploadRepo
    {
        private IHostingEnvironment Environment;

        private readonly IConfiguration configuration;
        public CommonMediaUploadRepo(IConfiguration configuration, IHostingEnvironment _environment)
        {
            this.configuration = configuration;
            Environment = _environment;
        }

        #region [Media Upload]
        public List<string> UploadImage(List<IFormFile> file, string Module_Name)
        {
            try
            {
                var connection = "";

                if (Module_Name == "Incident")
                {
                    connection = configuration.GetConnectionString("Path_Inc_Images");
                }
                else if (Module_Name == "Observation")
                {
                    connection = configuration.GetConnectionString("Path_Observation_Images");
                }
                else if (Module_Name == "Internal_Audit")
                {
                    connection = configuration.GetConnectionString("Path_Internal_Audit_Images");
                }
                else if (Module_Name == "CSP_Staff_Comp")
                {
                    connection = configuration.GetConnectionString("Staff_Com_Certificate");
                }
                else if (Module_Name == "Service_Provider_Audit")
                {
                    connection = configuration.GetConnectionString("Path_Service_Provider_Audit_Images");
                }
                else if (Module_Name == "CSP_Sp_Evidence")
                {
                    connection = configuration.GetConnectionString("Sp_Evidence_Files");
                }
                else if (Module_Name == "Training_FilePath")
                {
                    connection = configuration.GetConnectionString("Training_FilePath");
                }
                else if (Module_Name == "Training_LegalFilePath")
                {
                    connection = configuration.GetConnectionString("Training_LegalFilePath");
                }
                else if (Module_Name == "Training_OtherFilePath")
                {
                    connection = configuration.GetConnectionString("Training_OtherFilePath");
                }
                else if (Module_Name == "Hse_Bulletin_FilePath")
                {
                    connection = configuration.GetConnectionString("HSE_Bulletin");
                }
                else if (Module_Name == "Env_Audit_Cls_File")
                {
                    connection = configuration.GetConnectionString("Env_Audit_Closure_File");
                }
                string path = "";
                string wwwPath = this.Environment.WebRootPath;
                string contentPath = this.Environment.ContentRootPath;
                if (Module_Name == "Incident")
                {
                    path = Path.GetFullPath(Path.Combine(contentPath, "FileUpload/Incident/Incident_Images"));
                }
                else if (Module_Name == "Observation")
                {
                    path = Path.GetFullPath(Path.Combine(contentPath, "FileUpload/Observation/Observation_Images"));
                }
                else if (Module_Name == "Internal_Audit")
                {
                    path = Path.GetFullPath(Path.Combine(contentPath, "FileUpload/Internal_Audit/Internal_Audit_Images"));
                }
                else if (Module_Name == "CSP_Staff_Comp")
                {
                    path = Path.GetFullPath(Path.Combine(contentPath, "FileUpload/Csp_Staff/Csp_Staff_Files"));
                }
                else if (Module_Name == "Service_Provider_Audit")
                {
                    path = Path.GetFullPath(Path.Combine(contentPath, "FileUpload/Service_Provider_Audit/Service_Provider_Audit_Images"));
                }
                else if (Module_Name == "CSP_Sp_Evidence")
                {
                    path = Path.GetFullPath(Path.Combine(contentPath, "FileUpload/Csp_Sp_Evidence/Csp_Sp_Evidence_Files"));
                }
                else if (Module_Name == "Training_FilePath")
                {
                    path = Path.GetFullPath(Path.Combine(contentPath, "FileUpload/Training_Files/Training_Evidence_Files"));
                }
                else if (Module_Name == "Training_LegalFilePath")
                {
                    path = Path.GetFullPath(Path.Combine(contentPath, "FileUpload/Training_Legal_Files/Training_LegalEvidence_Files"));
                }
                else if (Module_Name == "Training_OtherFilePath")
                {
                    path = Path.GetFullPath(Path.Combine(contentPath, "FileUpload/Training_Other_Files/Training_OtherEvidence_Files"));
                }
                else if (Module_Name == "Hse_Bulletin_FilePath")
                {
                    path = Path.GetFullPath(Path.Combine(contentPath, "FileUpload/Hse_Bulletin/Hse_Bulletin_Images"));
                }
                else if (Module_Name == "Env_Audit_Cls_File")
                {
                    path = Path.GetFullPath(Path.Combine(contentPath, "FileUpload/Env_Audit/Env_Audit_Evidence_Files"));
                }
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                List<string> uploadedFiles = new List<string>();

                // Allowed File Count = '5'
                if (file.Count < 6)
                {
                    foreach (IFormFile postedFile in file)
                    {
                        // Allowed File Format = '.jpeg', '.jpg', '.png'
                        if (postedFile.ContentType == "image/jpeg" || postedFile.ContentType == "image/jpg" || postedFile.ContentType == "image/png" || postedFile.ContentType == "application/pdf" || postedFile.ContentType == "docx" || postedFile.ContentType == "doc")
                        {
                            // Allowed File Size = '50 MB'
                            if (postedFile.Length < 52428800)
                            {
                                Guid FileName = Guid.NewGuid();
                                var extension = Path.GetExtension(postedFile.FileName);
                                string fileupload = FileName.ToString() + extension;

                                //string fileName = Path.GetFileName(postedFile.FileName);
                                using (FileStream stream = new FileStream(Path.Combine(path, fileupload), FileMode.Create))
                                {
                                    postedFile.CopyTo(stream);
                                }
                                uploadedFiles.Add(connection + fileupload);
                            }
                            else
                            {
                                uploadedFiles.Add("File to large");
                            }
                        }
                        else
                        {
                            uploadedFiles.Add("Invalid Format");
                        }
                    }
                }
                else
                {
                    uploadedFiles.Add("Maximum Allowed 5 Images");
                }

                return uploadedFiles;
            }
            catch (Exception ex)
            {
                string Repo = "UploadImage";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }

        }
        public List<string> UploadFile(List<IFormFile> file, string Module_Name)
        {
            try
            {
                var connection = "";

                if (Module_Name == "Incident")
                {
                    connection = configuration.GetConnectionString("Path_Inc_Files");
                }
                else if (Module_Name == "Observation")
                {
                    connection = configuration.GetConnectionString("Path_Observation_Videos");
                }

                else if (Module_Name == "ServiceProvider")
                {
                    connection = configuration.GetConnectionString("Path_ServiceProvider_Files");
                }

                string path = "";
                string wwwPath = this.Environment.WebRootPath;
                string contentPath = this.Environment.ContentRootPath;
                if (Module_Name == "Incident")
                {
                    path = Path.GetFullPath(Path.Combine(contentPath, "FileUpload/Incident/Incident_Files"));
                }
                else if (Module_Name == "Observation")
                {
                    path = Path.GetFullPath(Path.Combine(contentPath, "FileUpload/Observation/Observation_Files"));
                }
                else if (Module_Name == "ServiceProvider")
                {
                    path = Path.GetFullPath(Path.Combine(contentPath, "FileUpload/ServiceProvider/ServiceProvider_Files"));
                }

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                List<string> uploadedFiles = new List<string>();

                // Allowed File Count = '5'
                if (file.Count < 6)
                {
                    foreach (IFormFile postedFile in file)
                    {
                        // Allowed File Format = '.docx', 'doc', 'pdf'
                        if (postedFile.ContentType == "application/msword" || postedFile.ContentType == "application/pdf" || postedFile.ContentType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document" || postedFile.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                        {
                            // Allowed File Size = '50 MB'
                            if (postedFile.Length < 52428800)
                            {
                                Guid FileName = Guid.NewGuid();
                                var extension = Path.GetExtension(postedFile.FileName);
                                string fileupload = FileName.ToString() + extension;

                                //string fileName = Path.GetFileName(postedFile.FileName);
                                using (FileStream stream = new FileStream(Path.Combine(path, fileupload), FileMode.Create))
                                {

                                    postedFile.CopyTo(stream);
                                }
                                uploadedFiles.Add(connection + fileupload);

                            }
                            else
                            {
                                uploadedFiles.Add("File to large");
                            }
                        }
                        else
                        {
                            uploadedFiles.Add("Invalid Format");
                        }
                    }
                }
                else
                {
                    uploadedFiles.Add("Maximum Allowed 5 Files");
                }

                return uploadedFiles;
            }
            catch (Exception ex)
            {
                string Repo = "UploadFile";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public List<string> UploadVideo(List<IFormFile> file, string Module_Name)
        {
            try
            {
                var connection = "";

                if (Module_Name == "Incident")
                {
                    connection = configuration.GetConnectionString("Path_Inc_Videos");
                }
                else if (Module_Name == "Observation")
                {
                    connection = configuration.GetConnectionString("Path_Observation_Videos");
                }
                else if (Module_Name == "SecurityIncident")
                {
                    connection = configuration.GetConnectionString("Path_SecurityIncident_Video");
                }
                string path = "";
                string wwwPath = this.Environment.WebRootPath;
                string contentPath = this.Environment.ContentRootPath;
                if (Module_Name == "Incident")
                {
                    path = Path.GetFullPath(Path.Combine(contentPath, "FileUpload/Incident/Incident_Videos"));
                }
                else if (Module_Name == "Observation")
                {
                    path = Path.GetFullPath(Path.Combine(contentPath, "FileUpload/Observation/Observation_Videos"));
                }
                else if (Module_Name == "SecurityIncident")
                {
                    path = Path.GetFullPath(Path.Combine(contentPath, "FileUpload/SecurityIncReport/Security_Videos"));
                }
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                List<string> uploadedFiles = new List<string>();

                // Allowed File Count = '5'
                if (file.Count < 6)
                {
                    foreach (IFormFile postedFile in file)
                    {
                        // Allowed File Format = '.jpeg', '.jpg', '.png'
                        if (postedFile.ContentType == "video/mp4" || postedFile.ContentType == "video/avi")
                        {
                            // Allowed File Size = '50 MB'
                            if (postedFile.Length < 52428800)
                            {
                                Guid FileName = Guid.NewGuid();
                                var extension = Path.GetExtension(postedFile.FileName);
                                string fileupload = FileName.ToString() + extension;

                                //string fileName = Path.GetFileName(postedFile.FileName);
                                using (FileStream stream = new FileStream(Path.Combine(path, fileupload), FileMode.Create))
                                {

                                    postedFile.CopyTo(stream);
                                }
                                uploadedFiles.Add(connection + fileupload);

                            }
                            else
                            {
                                uploadedFiles.Add("File to large");
                            }
                        }
                        else
                        {
                            uploadedFiles.Add("Invalid Format");
                        }
                    }
                }
                else
                {
                    uploadedFiles.Add("Maximum Allowed 5 Videos");
                }

                return uploadedFiles;
            }
            catch (Exception ex)
            {
                string Repo = "UploadVideo";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public List<string> UploadImageFile(List<IFormFile> file, string Module_Name)
        {
            try
            {
                var connection = "";

                if (Module_Name == "Incident")
                {
                    connection = configuration.GetConnectionString("Path_Inc_All");
                }
                else if (Module_Name == "ServiceProvider")
                {
                    connection = configuration.GetConnectionString("Path_ServiceProvider_Files");
                }
                else if (Module_Name == "SecurityIncident")
                {
                    connection = configuration.GetConnectionString("Path_SecurityIncident_Image");
                }

                string path = "";
                string wwwPath = this.Environment.WebRootPath;
                string contentPath = this.Environment.ContentRootPath;
                if (Module_Name == "Incident")
                {
                    path = Path.GetFullPath(Path.Combine(contentPath, "FileUpload/Incident/Incident_All"));
                }
                else if (Module_Name == "ServiceProvider")
                {
                    path = Path.GetFullPath(Path.Combine(contentPath, "FileUpload/ServiceProvider/ServiceProvider_Files"));
                }
                else if (Module_Name == "SecurityIncident")
                {
                    path = Path.GetFullPath(Path.Combine(contentPath, "FileUpload/SecurityIncReport/Security_Images"));
                }
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                List<string> uploadedFiles = new List<string>();

                // Allowed File Count = '5'
                if (file.Count < 6)
                {
                    foreach (IFormFile postedFile in file)
                    {
                        // Allowed File Format = '.jpeg', '.jpg', '.png', '.docx', 'doc', 'pdf'
                        if (postedFile.ContentType == "image/jpeg" || postedFile.ContentType == "image/jpg" || postedFile.ContentType == "image/png" || postedFile.ContentType == "application/msword" || postedFile.ContentType == "application/pdf" || postedFile.ContentType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document" || postedFile.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                        {
                            // Allowed File Size = '50 MB'
                            if (postedFile.Length < 52428800)
                            {
                                Guid FileName = Guid.NewGuid();
                                var extension = Path.GetExtension(postedFile.FileName);
                                string fileupload = FileName.ToString() + extension;

                                //string fileName = Path.GetFileName(postedFile.FileName);
                                using (FileStream stream = new FileStream(Path.Combine(path, fileupload), FileMode.Create))
                                {

                                    postedFile.CopyTo(stream);
                                }
                                uploadedFiles.Add(connection + fileupload);

                            }
                            else
                            {
                                uploadedFiles.Add("File to large");
                            }
                        }
                        else
                        {
                            uploadedFiles.Add("Invalid Format");
                        }
                    }
                }
                else
                {
                    uploadedFiles.Add("Maximum Allowed 5 Files");
                }

                return uploadedFiles;
            }
            catch (Exception ex)
            {
                string Repo = "UploadImageFile";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public List<string> UploadImageVideos(List<IFormFile> file, string Module_Name)
        {
            try
            {
                var connection = "";

                if (Module_Name == "Incident")
                {
                    connection = configuration.GetConnectionString("Path_Inc_All");
                }
                string path = "";
                string wwwPath = this.Environment.WebRootPath;
                string contentPath = this.Environment.ContentRootPath;
                if (Module_Name == "Incident")
                {
                    path = Path.GetFullPath(Path.Combine(contentPath, "FileUpload/Incident/Incident_All"));
                }
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                List<string> uploadedFiles = new List<string>();

                // Allowed File Count = '5'
                if (file.Count < 6)
                {
                    foreach (IFormFile postedFile in file)
                    {
                        // Allowed File Format = '.jpeg', '.jpg', '.png', '.mp4', '.avi'
                        if (postedFile.ContentType == "image/jpeg" || postedFile.ContentType == "image/jpg" || postedFile.ContentType == "image/png" || postedFile.ContentType == "video/mp4" || postedFile.ContentType == "video/avi")
                        {
                            // Allowed File Size = '50 MB'
                            if (postedFile.Length < 52428800)
                            {
                                Guid FileName = Guid.NewGuid();
                                var extension = Path.GetExtension(postedFile.FileName);
                                string fileupload = FileName.ToString() + extension;

                                //string fileName = Path.GetFileName(postedFile.FileName);
                                using (FileStream stream = new FileStream(Path.Combine(path, fileupload), FileMode.Create))
                                {
                                    postedFile.CopyTo(stream);
                                }
                                uploadedFiles.Add(connection + fileupload);
                            }
                            else
                            {
                                uploadedFiles.Add("File to large");
                            }
                        }
                        else
                        {
                            uploadedFiles.Add("Invalid Format");
                        }
                    }
                }
                else
                {
                    uploadedFiles.Add("Maximum Allowed 5 Files");
                }

                return uploadedFiles;
            }
            catch (Exception ex)
            {
                string Repo = "UploadImageVideos";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public List<string> UploadImageFileVideos(List<IFormFile> file, string Module_Name)
        {
            try
            {
                var connection = "";

                if (Module_Name == "Incident")
                {
                    connection = configuration.GetConnectionString("Path_Inc_All");
                }
                string path = "";
                string wwwPath = this.Environment.WebRootPath;
                string contentPath = this.Environment.ContentRootPath;
                if (Module_Name == "Incident")
                {
                    path = Path.GetFullPath(Path.Combine(contentPath, "FileUpload/Incident/Incident_All"));
                }
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                List<string> uploadedFiles = new List<string>();

                // Allowed File Count = '5'
                if (file.Count < 6)
                {
                    foreach (IFormFile postedFile in file)
                    {
                        // Allowed File Format = '.jpeg', '.jpg', '.png', '.mp4', '.avi', '.docx', 'doc', 'pdf'
                        if (postedFile.ContentType == "image/jpeg" || postedFile.ContentType == "image/jpg" || postedFile.ContentType == "image/png" || postedFile.ContentType == "video/mp4" || postedFile.ContentType == "video/avi" || postedFile.ContentType == "application/msword" || postedFile.ContentType == "application/pdf" || postedFile.ContentType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document" || postedFile.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                        {
                            // Allowed File Size = '50 MB'
                            if (postedFile.Length < 52428800)
                            {
                                Guid FileName = Guid.NewGuid();
                                var extension = Path.GetExtension(postedFile.FileName);
                                string fileupload = FileName.ToString() + extension;

                                //string fileName = Path.GetFileName(postedFile.FileName);
                                using (FileStream stream = new FileStream(Path.Combine(path, fileupload), FileMode.Create))
                                {
                                    postedFile.CopyTo(stream);
                                }
                                uploadedFiles.Add(connection + fileupload);
                            }
                            else
                            {
                                uploadedFiles.Add("File to large");
                            }
                        }
                        else
                        {
                            uploadedFiles.Add("Invalid Format");
                        }
                    }
                }
                else
                {
                    uploadedFiles.Add("Maximum Allowed 5 Files");
                }

                return uploadedFiles;
            }
            catch (Exception ex)
            {
                string Repo = "UploadImageFileVideos";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        #endregion

        #region Drill

        public List<string> Drill_UploadPhoto(List<IFormFile> file, string ID)
        {
            try
            {
                var connection = "";
                string path = "";
                string wwwPath = this.Environment.WebRootPath;
                string contentPath = this.Environment.ContentRootPath;

                switch (ID)
                {
                    case "1":
                        connection = configuration.GetConnectionString("DrillPhoto");
                        path = Path.GetFullPath(Path.Combine(contentPath, "FileUpload/DrillPhotos"));
                        break;
                    case "2":
                        connection = configuration.GetConnectionString("MitigationAct");
                        path = Path.GetFullPath(Path.Combine(contentPath, "FileUpload/MitigationAct"));
                        break;  
                    default:
                        break;
                }

               

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                List<string> uploadedFiles = new List<string>();

                // Allowed File Count = '5'
                if (file.Count < 6)
                {
                    foreach (IFormFile postedFile in file)
                    {
                        // Allowed File Format = '.docx', 'doc', 'pdf'
                        if (postedFile.ContentType == "image/jpeg" || postedFile.ContentType == "image/jpg"|| postedFile.ContentType == "image/jpeg" || postedFile.ContentType == "image/png")
                        {
                            // Allowed File Size = '50 MB'
                            if (postedFile.Length < 52428800)
                            {
                                Guid FileName = Guid.NewGuid();
                                var extension = Path.GetExtension(postedFile.FileName);
                                string fileupload = FileName.ToString() + extension;

                                //string fileName = Path.GetFileName(postedFile.FileName);
                                using (FileStream stream = new FileStream(Path.Combine(path, fileupload), FileMode.Create))
                                {

                                    postedFile.CopyTo(stream);
                                }
                                uploadedFiles.Add(connection + fileupload);

                            }
                            else
                            {
                                uploadedFiles.Add("File to large");
                            }
                        }
                        else
                        {
                            uploadedFiles.Add("Invalid Format");
                        }
                    }
                }
                else
                {
                    uploadedFiles.Add("Maximum Allowed 5 Files");
                }

                return uploadedFiles;
            }
            catch (Exception ex)
            {
                string Repo = "Drill_UploadPhoto/Drill_UploadPhoto";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public List<string> Drill_UploadVideo(List<IFormFile> file, string ID)
        {
            try
            {
                var connection = "";
                connection = configuration.GetConnectionString("DrillVideo");
                string path = "";
                string wwwPath = this.Environment.WebRootPath;
                string contentPath = this.Environment.ContentRootPath;

                path = Path.GetFullPath(Path.Combine(contentPath, "FileUpload/DrillVideos"));

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                List<string> uploadedFiles = new List<string>();

                // Allowed File Count = '5'
                if (file.Count < 6)
                {
                    foreach (IFormFile postedFile in file)
                    {
                        // Allowed File Format = '.docx', 'doc', 'pdf'
                        if (postedFile.ContentType == "video/mp4" || postedFile.ContentType == "video/avi")
                        {
                            // Allowed File Size = '50 MB'
                            if (postedFile.Length < 52428800)
                            {
                                Guid FileName = Guid.NewGuid();
                                var extension = Path.GetExtension(postedFile.FileName);
                                string fileupload = FileName.ToString() + extension;

                                //string fileName = Path.GetFileName(postedFile.FileName);
                                using (FileStream stream = new FileStream(Path.Combine(path, fileupload), FileMode.Create))
                                {

                                    postedFile.CopyTo(stream);
                                }
                                uploadedFiles.Add(connection + fileupload);

                            }
                            else
                            {
                                uploadedFiles.Add("File to large");
                            }
                        }
                        else
                        {
                            uploadedFiles.Add("Invalid Format");
                        }
                    }
                }
                else
                {
                    uploadedFiles.Add("Maximum Allowed 5 Files");
                }

                return uploadedFiles;
            }
            catch (Exception ex)
            {
                string Repo = "Drill_UploadPhoto/Drill_UploadVideo";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion
    }
}
