using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BaseDAL
    {
        public void WrtiteToFile(string fileName, List<string> serializedObjectList)
        {
            FileStream fwrite = new FileStream(fileName, FileMode.Create);
            StreamWriter sw = new StreamWriter(fwrite);
            foreach (var x in serializedObjectList)
            {
                sw.WriteLine(x);
            }
            sw.Close();
            fwrite.Close();
        }


        public List<string> ReadFromFile(string fileName)
        {
            List<string> newList = new List<string>();

            var info = new FileInfo(fileName);
            if (!info.Exists || info.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n***The File Is Empty Or Does Not Exist***\n");
                Console.ResetColor();
            }
            else
            {
                StreamReader sr = new StreamReader(fileName);
                string serializedObject = String.Empty;
                for (int i = 0; (serializedObject = sr.ReadLine()) != null; i++)
                {
                    newList.Add(serializedObject);
                }
            }
            return newList;
        }
    }
}
