using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorldAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorldAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private static List<string> _students = ["Sayali", "Vandana", "Kamleshwar"];

        [HttpGet()]
        public string SayHello()
        {
            return "Hello From Students Controller";
        }


        [HttpGet("all")]
        public List<string> GetAll()
        {
            return _students;
        }

        [HttpGet("getById/{id}")]
        public ActionResult<string> GetById(int id)
        {
            if (id <= _students.Count)
            {
                return Ok(_students[id - 1]);
            }
            else
            {
                return NotFound($"Student with id:{id} does not exist");
            }
        }

        [HttpPost("new/{name}")]
        public ActionResult<int> AddNew(string name)
        {
            _students.Add(name);
            return Ok(_students.Count);
        }

        // [HttpPut("update/{id}/{newName}")]
        // public ActionResult<string> Update(int id, string newName)
        // {
        //     _students[id-1] = newName;
        //     return "Done";
        // }

        [HttpPut("update")]
        public ActionResult<string> Update(CUpdateStudentDTO data)
        {
            _students[data.Id - 1] = data.NewName;
            return Ok("Done");
        }

        [HttpDelete("delete/{id}")]
        public ActionResult<String> Delete(int id)
        {
            _students.RemoveAt(id-1);
            return Ok("Done");
        }

    }
}