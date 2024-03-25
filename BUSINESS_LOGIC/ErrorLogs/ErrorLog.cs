using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS_LOGIC.ErrorLogs
{
    public static class ErrorLog
    {
        public static void ErrorLogs(Exception ex, string Repo)
        {
            string message = "Repository Name  : " + Repo.ToString();
            message += Environment.NewLine;
            message += Environment.NewLine;
            message += string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
            message += Environment.NewLine;
            message += Environment.NewLine;
            message += string.Format("Message: {0}", ex.Message);
            message += Environment.NewLine;
            message += Environment.NewLine;
            message += string.Format("Procedure: {0}", ((System.Data.SqlClient.SqlException)ex).Procedure);
            message += Environment.NewLine;
            message += Environment.NewLine;
            message += string.Format("StackTrace: {0}", ex.StackTrace);
            message += Environment.NewLine;
            message += Environment.NewLine;
            message += string.Format("Source: {0}", ex.Source);
            message += Environment.NewLine;
            message += Environment.NewLine;
            message += Environment.NewLine;
            message += "----------------------------------------------------------------------------------------------------------------------";
            message += Environment.NewLine;

            string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "FileUpload/logs.txt"));
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }
    }
}
