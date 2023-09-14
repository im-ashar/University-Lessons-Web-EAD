using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace BLL
{
    public class GpaBLL
    {
        public void MarksToGrade(List<GpaDTO> studentsList)
        {
            List<GpaDTO> newList = new List<GpaDTO>();
            foreach (var x in studentsList)
            {
                if (x.Marks >= 85)
                {
                    x.Grade = "A";
                }
                else if (x.Marks >= 80 && x.Marks <= 84)
                {
                    x.Grade = "B";
                }
                else if (x.Marks >= 75 && x.Marks <= 79)
                {
                    x.Grade = "C";
                }
                else if (x.Marks >= 70 && x.Marks <= 74)
                {
                    x.Grade = "D";
                }
                
                newList.Add(x);
            }
                GpaDAL dal = new GpaDAL();
                dal.SerializeObjects(newList);


        }
        public List<GpaDTO> GradeToGpa()
        {
            GpaDAL dal = new GpaDAL();
            List<GpaDTO> newList = dal.DeSerializedObjects();
            List<GpaDTO> newList2 = new List<GpaDTO>();
            foreach (GpaDTO dto in newList)
            {
                if (dto.Grade == "A")
                {
                    dto.Gpa = 4;
                }
                else if (dto.Grade == "B")
                {
                    dto.Gpa = 3.7;
                }
                else if (dto.Grade == "C")
                {
                    dto.Gpa = 3.5;
                }
                else if (dto.Grade == "D")
                {
                    dto.Gpa = 3.3;
                }
                else if (dto.Grade == "E")
                {
                    dto.Gpa = 3.0;
                }
                else if (dto.Grade == "F")
                {
                    dto.Gpa = 2.7;
                }
                newList2.Add(dto);
            }
            return newList2;
            
        }
    }
}


