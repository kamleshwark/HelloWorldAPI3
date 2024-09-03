using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldAPI.DTOs
{
    public class CUpdateStudentDTO
    {
        public int Id { get; set; }
        public string NewName { get; set; }

        public CUpdateStudentDTO()
        {
            NewName = "";
        }
    }
}