using Microsoft.AspNetCore.Http;
using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBUSINESS_LOGIC.IBusinessLogic
{
    public interface ICommonMediaUploadRepo
    {
        List<string> UploadImage(List<IFormFile> file, string Module_Name);
        List<string> UploadFile(List<IFormFile> file, string Module_Name);
        List<string> UploadVideo(List<IFormFile> file, string Module_Name);
        List<string> UploadImageFile(List<IFormFile> file, string Module_Name);
        List<string> UploadImageVideos(List<IFormFile> file, string Module_Name);
        List<string> UploadImageFileVideos(List<IFormFile> file, string Module_Name);

        #region Drill FileUpload
        List<string> Drill_UploadPhoto(List<IFormFile> file, string ID);
        List<string> Drill_UploadVideo(List<IFormFile> file, string ID);
        #endregion
    }
}
