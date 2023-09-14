using Practice_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Practice_DAL
{
    public class Practice_DAL_Class
    {
        public void SendForWriting(List<Practice_DTO_Class> newList)
        {
            FileStream fwrite = new FileStream("Practice.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fwrite);
            foreach (Practice_DTO_Class x in newList)
            {
                string ser = JsonSerializer.Serialize(x);
                Console.WriteLine(ser);
                sw.WriteLine(ser);
            }
            sw.Flush();
            sw.Close();
        }
    }
}
