using Microsoft.AspNetCore.Mvc;
using ProductStore.Data;
using ProductStore.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatagoriesController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public CatagoriesController(ApplicationDBContext context)
        {
            _context= context;  
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_context.Catagories.OrderBy(a=> a.Name).ToList());
            }
            catch (Exception ex)
            {
              return BadRequest(ex.Message);
            }
        }

       
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_context.Catagories.FirstOrDefault(a => a.Id == id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpPost("save")]
        public IActionResult save([FromBody] Catagory modul)
        {
            try
            {

                _context.Catagories.Add(modul);
                _context.SaveChanges();


                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Edit/{id}")]
        public IActionResult Edit(int id, [FromBody] Catagory model)
        {
            try
            {
                var rsult = _context.Catagories.FirstOrDefault(a => a.Id == id);
                if (rsult != null)
                {
                    rsult.Name = model.Name;
                     _context.Catagories.Update(rsult);
                    _context.SaveChanges();
                    return Ok(rsult);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var rsult = _context.Catagories.FirstOrDefault(a => a.Id == id);
                if (rsult != null)
                {
                    _context.Catagories.Remove(rsult);
                    _context.SaveChanges();
                    return Ok(rsult);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
