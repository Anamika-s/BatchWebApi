using BatchWebApi.Context;
using BatchWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BatchWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BatchController : ControllerBase
    {
        AppDbContext _context;
        public BatchController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<Batch> batches = _context.Batches.Where(x=>x.IsActive==true).ToList();
            if (batches.Count() == 0)
                return BadRequest("No records");
            else
                return Ok(batches);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Batch batch = _context.Batches.FirstOrDefault(x => x.BatchId == id && x.IsActive == true);
            if (batch == null)
                return BadRequest("No records");
            else
                return Ok(batch);
        }


        [HttpPost]

        public IActionResult Create(Batch batch)
        {
            batch.CreatedBy = 100;
            batch.CreatedOn = DateTime.Now;
            batch.IsActive = true;
            _context.Batches.Add(batch);
            _context.SaveChanges();
            return Created("records added", batch);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Batch batch = _context.Batches.FirstOrDefault(x => x.BatchId == id
            && x.IsActive== true);
            if (batch == null)
                return BadRequest("No records");
            else
            {
                //_context.Batches.Remove(batch); // hard delete
              
               
                batch.IsActive = false;    // soft delete
                _context.SaveChanges();
                return Ok(batch);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, Batch batch)
        {
            Batch obj = _context.Batches.FirstOrDefault(x => x.BatchId == id 
            && x.IsActive == true);
            if (obj == null)
                return BadRequest("No records");
            else
            {
                obj.Seats = batch.Seats;
                obj.Name  = batch.Name;
                obj.UpdatedBy = 200;
                obj.UpdatedOn = DateTime.Now;
                _context.SaveChanges();

                return Ok(batch);
            }
        }
            // to secure service , we use AA 
          // Authentication > Proving your identity  , using forms authentication
            // we add login page 
            //   it means that you are a valid user
            // roles are there > manager hrmanager admin user  accountant


    }
}
