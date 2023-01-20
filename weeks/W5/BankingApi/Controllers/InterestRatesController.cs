using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankingApi.Models;

namespace BankingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestRatesController : ControllerBase
    {
        private readonly BankingContext _context;

        public InterestRatesController(BankingContext context)
        {
            _context = context;
        }

        // GET: api/CompoundInterest
        [HttpGet("CompoundInterest")]
        public async Task<ActionResult<Object>> GetCompoundInterest([FromQuery] int amount, [FromQuery] int years)
        {
            if (_context.InterestRates == null)
            {
                return Problem("Entity set 'BankingContext.InterestRates'  is null.");
            }
            var interestRates = await _context.InterestRates.ToListAsync();
            var interestRate = interestRates.Where(x => x.MinAmount <= amount && x.MaxAmount >= amount).FirstOrDefault();
            if (interestRate == null)
            {
                return Problem("Interest rate not found.");
            }

            var finalAmount = amount * (decimal)Math.Pow((double)(interestRate.InterestAmount), years);
            // Return final amount and interest rate
            return Ok(new { FinalAmount = finalAmount, Rate = interestRate.InterestAmount });
        }

        // GET: api/InterestRates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InterestRate>>> GetInterestRates()
        {
            if (_context.InterestRates == null)
            {
                return NotFound();
            }
            return await _context.InterestRates.ToListAsync();
        }

        // GET: api/InterestRates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InterestRate>> GetInterestRate(long id)
        {
            if (_context.InterestRates == null)
            {
                return NotFound();
            }
            var interestRate = await _context.InterestRates.FindAsync(id);

            if (interestRate == null)
            {
                return NotFound();
            }

            return interestRate;
        }

        // PUT: api/InterestRates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInterestRate(long id, InterestRate interestRate)
        {
            if (id != interestRate.Id)
            {
                return BadRequest();
            }

            _context.Entry(interestRate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterestRateExists(id))
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

        // POST: api/InterestRates
        [HttpPost]
        public async Task<ActionResult<InterestRate>> PostInterestRate(InterestRate interestRate)
        {
            if (_context.InterestRates == null)
            {
                return Problem("Entity set 'BankingContext.InterestRates'  is null.");
            }
            _context.InterestRates.Add(interestRate);
            await _context.SaveChangesAsync();

            // return CreatedAtAction("GetInterestRate", new { id = interestRate.Id }, interestRate);
            return CreatedAtAction(nameof(GetInterestRate), new { id = interestRate.Id }, interestRate);
        }

        // DELETE: api/InterestRates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInterestRate(long id)
        {
            if (_context.InterestRates == null)
            {
                return NotFound();
            }
            var interestRate = await _context.InterestRates.FindAsync(id);
            if (interestRate == null)
            {
                return NotFound();
            }

            _context.InterestRates.Remove(interestRate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InterestRateExists(long id)
        {
            return (_context.InterestRates?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
