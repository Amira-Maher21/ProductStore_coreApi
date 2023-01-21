using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
using ProductStore.Data;
using ProductStore.Models;
using System;
using System.Data.Entity;
using static System.Net.Mime.MediaTypeNames;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public ProductsController(ApplicationDBContext context)
        {
                _context = context; 
        }     
        // GET: api/<ProductsController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_context.Products.Include(x => x.Catagory).OrderBy(x => x.Name).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var Result = _context.Products.Include(x => x.Catagory).FirstOrDefault(x => x.Id == id);
                return Ok(Result);
                    
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] Product model)
        {
            try
            {
                if (model != null )
                {
                    _context.Products.Add(model);
                    _context.SaveChanges();
                    return Ok();

                }
                return BadRequest();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product model)
        {
            try
            {
                if (model != null ) 
                {
                    var result =_context.Products.FirstOrDefault(x => x.Id == id);
                    if (result != null)
                    {
                        result.Id = model.Id; 
                        result.Name= model.Name;
                       result.Price =model.Price;
                        result.Quantity = model.Quantity;
                        result.Total = model.Total;
                        _context.Products.Update(result);
                        _context.SaveChanges();
                        return Ok(result);

                    }
                }
                return BadRequest();        
            }
            
            catch (Exception ex)
            {
                                    
                return BadRequest(ex.Message);

            }
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var Result = _context.Products.FirstOrDefault(x => x.Id == id);
                if (Result != null)
                {
                    _context.Products.Remove(Result);
                    _context.SaveChanges();
                    return Ok();
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
