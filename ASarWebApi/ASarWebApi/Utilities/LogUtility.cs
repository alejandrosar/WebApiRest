using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


namespace ASarWebApi.Utilities
{
    public class LogUtility
    {
        public string GetPath()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            //string path = AppContext.BaseDirectory; in =< 4.6 .Net Framework
            if (File.Exists(path + "Log.txt"))
            {
            }
            else
            {
                File.CreateText(path + "Log.txt");
            }
            return path;
        }
        public void WriteLog(string text)
        {
            string path = GetPath() + "Log.txt";

            using (StreamWriter SW = File.AppendText(path))
            {

                SW.WriteAsync(text + Environment.NewLine + "--------------------------------------------------------------------------------------------------------"
                + Environment.NewLine);
                //SW.Close();

            }

        }




        
    }
}