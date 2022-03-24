using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIPT.Data;
using APIPT.Models;

namespace APIPT.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult GetStudent()
        {
            var Stdns = _context.Studnts.OrderBy(s => s.FirstName).ToList();

            return new JsonResult(Stdns);
        }

        [HttpPost]
        public IActionResult PostStudent([Bind("FirstName,LastName,EmailAddress,BirthDate,Gender")] Student student)
        {
            if( string.IsNullOrEmpty(student.FirstName))
                return new JsonResult("Name cannot be empty");
            
            if(string.IsNullOrEmpty(student.LastName))
                return new JsonResult("Lastname cannot be empty");

            if(string.IsNullOrEmpty(student.EmailAddress))
                return new JsonResult("Email cannot be empty");

            if (student.Gender==0)
                return new JsonResult("Email cannot be empty");

            Student stdnt = new Student();
            stdnt.FirstName = student.FirstName;
            stdnt.LastName = student.LastName;
            stdnt.EmailAddress = student.EmailAddress;
            stdnt.BirthDate = student.BirthDate;
            stdnt.Gender = student.Gender;

            _context.Add(stdnt);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateStudent(int Id, Student student)
        {

            if (Id != student.Id)
            {
                return BadRequest();
            }

            _context.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return new JsonResult("Success");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var product = _context.Studnts.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            _context.Studnts.Remove(product);

            _context.SaveChanges();

            return new JsonResult("Success");
        }

        [Route("FindLastName/{lastname}")]
        public IActionResult FindByLastName(string lastname)
        {
            var stdn = _context.Studnts.Where(s => s.LastName == lastname).ToList();

            return new JsonResult(stdn);
        }

        [Route("FindEmail/{email}")]
        public IActionResult FindByEmail(string email)
        {
            var stdn = _context.Studnts.Where(s => s.EmailAddress == email).ToList();

            return new JsonResult(stdn);
        }

        [Route("GetGender")]
        public IActionResult GetByGender()
        {
            var stdn = _context.Studnts.OrderBy(s => s.Gender).ToList();

            return new JsonResult(stdn);
        }

        [Route("DateReport")]
        public IActionResult GetReport()
        {
            var stdn = _context.Studnts.Where(s => s.BirthDate > new DateTime(1980,01,01) && s.BirthDate < new DateTime(1990,01,01)).ToList();

            return new JsonResult(stdn);
        }


    }
}