using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.NasyrovaVR.Sprint5.TaskReview.V3.Lib
{
    public class DataService : ISprint5Task7V3
    {
        public string LoadDataAndSave(string path)
        {
            string pathSaveFile = $@"{Directory.GetCurrentDirectory()}\OutPutDataFileTask7V3.txt"; ;
            FileInfo fileinfo = new FileInfo(pathSaveFile);
            bool fileexists = fileinfo.Exists;

            if (fileexists)
            {
                File.Delete(pathSaveFile);
            }
            string strLine = "";
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    for (int i = 0; i < line.Length; i++)
                    {
                        char c = line[i];
                        if (((c >= 'А') && (c <= 'Я') || ((c >= 'а') && (c <= 'я'))) == false)
                        {
                            strLine = strLine + line[i];
                        }

                    }

                    File.AppendAllText(pathSaveFile, strLine + Environment.NewLine);
                    strLine = "";
                }

                return pathSaveFile;
            }
        }
    }
}
