using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DTO
{
    public class GpaDTO
    {
        public string Name { get; set; }
        public string RollNo { get; set; }
        public string Subject { get; set; }
        public string Grade { get; set; }
        [JsonIgnore] public int Marks { get; set; }
        [JsonIgnore] public double Gpa { get; set; }
    }
}
