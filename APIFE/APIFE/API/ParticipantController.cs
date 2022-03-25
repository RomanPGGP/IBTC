using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIFE.Models;
using APIFE.Data;

namespace APIFE.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public ParticipantController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/Participant
        [HttpPost]
        public IActionResult Post([FromBody] Participant pt)
        {
            if (string.IsNullOrEmpty(pt.FirstName))
                return new JsonResult("FirstName is needed");

            if (string.IsNullOrEmpty(pt.LastName))
                return new JsonResult("LastName is needed");

            if (pt.Gender == '\0')
                return new JsonResult("Gender is needed");

            if (string.IsNullOrEmpty(pt.EmailAddress))
                return new JsonResult("Email Address is needed");

            if (pt.BirthDate == null)
                return new JsonResult("Birth Date is needed");

            Participant pr = new Participant
            {
                FirstName = pt.FirstName,
                LastName = pt.LastName,
                Gender = pt.Gender,
                EmailAddress = pt.EmailAddress,
                BirthDate = pt.BirthDate
            };


            _context.Add(pr);
            _context.SaveChanges();

            return new JsonResult("Success");
            
        }

        [HttpPut("{Id}")]
        public IActionResult ModifyParticipant(int Id, [FromBody] Participant pt)
        {
            if (Id != pt.Id)
            {
                return BadRequest();
            }

            _context.Entry(pt).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

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
        public IActionResult DeleteParticipant(int id)
        {
            var product = _context.participants.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            _context.participants.Remove(product);

            _context.SaveChanges();

            return new JsonResult("Success");
        }


        [Route("FindLastName/{lastname}")]
        public IActionResult SearchLastName(string lastname)
        {
            var lnlist = _context.participants.Where(p => p.LastName == lastname).ToList();

            return new JsonResult(lnlist);
        }

        [Route("FindEmail/{email}")]
        public IActionResult SearchEmail(string email)
        {
            var elist = _context.participants.Where(p => p.EmailAddress == email).ToList();

            return new JsonResult(elist);
        }

        [Route("FindBirthdate/{birthdate}")]
        public IActionResult SearchBirthDate(string birthdate)
        {
            DateTime.TryParse(birthdate, out DateTime res);
            var bdlist = _context.participants.Where(p => p.BirthDate == res).ToList();

            return new JsonResult(bdlist);
        }

        [Route("ReportBD")]
        public IActionResult ReportBirthDate()
        {
            var bdls = _context.participants.OrderBy(p => p.BirthDate).ToList();

            return new JsonResult(bdls);
        }

        [Route("ReportGen")]
        public IActionResult ReportGen()
        {
            var glst = _context.participants.OrderBy(p => p.Gender).ToList();

            return new JsonResult(glst);
        }
        //// GET: api/Participant
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Participant/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}


        //// PUT: api/Participant/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
