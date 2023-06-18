using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Diplom_back.Database;
using Diplom_back.Models;

namespace Diplom_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealsHasProductController : ControllerBase
    {
        private readonly Diplom_backContext _context;

        public DealsHasProductController(Diplom_backContext context)
        {
            _context = context;
        }

        // GET: api/DealsHasProduct
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DealsHasProduct>>> GetDealsHasProducts()
        {
          if (_context.DealsHasProducts == null)
          {
              return NotFound();
          }
            return await _context.DealsHasProducts.ToListAsync();
        }

        // GET: api/DealsHasProduct/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DealsHasProduct>> GetDealsHasProduct(int id)
        {
          if (_context.DealsHasProducts == null)
          {
              return NotFound();
          }
            var dealsHasProduct = await _context.DealsHasProducts.FindAsync(id);

            if (dealsHasProduct == null)
            {
                return NotFound();
            }

            return dealsHasProduct;
        }

        // PUT: api/DealsHasProduct/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDealsHasProduct(int id, DealsHasProduct dealsHasProduct)
        {
            if (id != dealsHasProduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(dealsHasProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DealsHasProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DealsHasProduct
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DealsHasProduct>> PostDealsHasProduct(DealsHasProduct dealsHasProduct)
        {
          if (_context.DealsHasProducts == null)
          {
              return Problem("Entity set 'Diplom_backContext.DealsHasProducts'  is null.");
          }
            _context.DealsHasProducts.Add(dealsHasProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDealsHasProduct", new { id = dealsHasProduct.Id }, dealsHasProduct);
        }

        // DELETE: api/DealsHasProduct/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDealsHasProduct(int id)
        {
            if (_context.DealsHasProducts == null)
            {
                return NotFound();
            }
            var dealsHasProduct = await _context.DealsHasProducts.FindAsync(id);
            if (dealsHasProduct == null)
            {
                return NotFound();
            }

            _context.DealsHasProducts.Remove(dealsHasProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DealsHasProductExists(int id)
        {
            return (_context.DealsHasProducts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
