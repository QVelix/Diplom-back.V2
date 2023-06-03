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
    public class BankRequisiteController : ControllerBase
    {
        private readonly Diplom_backContext _context;

        public BankRequisiteController(Diplom_backContext context)
        {
            _context = context;
        }

        // GET: api/BankRequisiteContoller
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BankRequisite>>> GetBankRequisites()
        {
          if (_context.BankRequisites == null)
          {
              return NotFound();
          }
            return await _context.BankRequisites.ToListAsync();
        }

        // GET: api/BankRequisiteContoller/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BankRequisite>> GetBankRequisite(int id)
        {
          if (_context.BankRequisites == null)
          {
              return NotFound();
          }
            var bankRequisite = await _context.BankRequisites.FindAsync(id);

            if (bankRequisite == null)
            {
                return NotFound();
            }

            return bankRequisite;
        }

        // PUT: api/BankRequisiteContoller/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBankRequisite(int id, BankRequisite bankRequisite)
        {
            if (id != bankRequisite.Id)
            {
                return BadRequest();
            }

            _context.Entry(bankRequisite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankRequisiteExists(id))
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

        // POST: api/BankRequisiteContoller
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BankRequisite>> PostBankRequisite(BankRequisite bankRequisite)
        {
          if (_context.BankRequisites == null)
          {
              return Problem("Entity set 'Diplom_backContext.BankRequisites'  is null.");
          }
            _context.BankRequisites.Add(bankRequisite);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBankRequisite", new { id = bankRequisite.Id }, bankRequisite);
        }

        // DELETE: api/BankRequisiteContoller/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBankRequisite(int id)
        {
            if (_context.BankRequisites == null)
            {
                return NotFound();
            }
            var bankRequisite = await _context.BankRequisites.FindAsync(id);
            if (bankRequisite == null)
            {
                return NotFound();
            }

            _context.BankRequisites.Remove(bankRequisite);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BankRequisiteExists(int id)
        {
            return (_context.BankRequisites?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
