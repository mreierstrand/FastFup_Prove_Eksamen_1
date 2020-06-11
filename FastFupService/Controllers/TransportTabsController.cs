using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FastFupService.Data;
using FastFupService.Model;

namespace FastFupService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportTabsController : ControllerBase
    {
        private readonly FastFupServiceContext _context;

        public TransportTabsController(FastFupServiceContext context)
        {
            _context = context;

            if (_context.TransportTab.Count() == 0)
            {
                _context.TransportTab.Add(new TransportTab(1, "A", "MarkJet", "20-20-2020", 1500, 7.05));
                _context.TransportTab.Add(new TransportTab(2, "B", "MikeWolf", "21-20-2020", 1050, 8.15));
                _context.TransportTab.Add(new TransportTab(3, "C", "AndyRap", "22-20-2020", 976, 7.92));
                _context.TransportTab.Add(new TransportTab(47, "A", "AndyRap", "23-20-2020", 700, 7.11));
                _context.TransportTab.Add(new TransportTab(48, "B", "Jammer", "24-20-2020", 1104, 8.34));
                _context.TransportTab.Add(new TransportTab(1178, "C", "PeteBlack", "25-20-2020", 550, 7.96));
                _context.SaveChanges();
            }
        }

        // GET: api/TransportTabs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransportTab>>> GetTransportTab()
        {
            return await _context.TransportTab.ToListAsync();
        }

        // GET: api/TransportTabs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransportTab>> GetTransportTab(int id)
        {
            var transportTab = await _context.TransportTab.FindAsync(id);

            if (transportTab == null)
            {
                return NotFound();
            }

            return transportTab;
        }

        // PUT: api/TransportTabs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransportTab(int id, TransportTab transportTab)
        {
            if (id != transportTab.Id)
            {
                return BadRequest();
            }

            _context.Entry(transportTab).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransportTabExists(id))
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

        // POST: api/TransportTabs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TransportTab>> PostTransportTab(TransportTab transportTab)
        {
            _context.TransportTab.Add(transportTab);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransportTab", new { id = transportTab.Id }, transportTab);
        }

        // DELETE: api/TransportTabs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TransportTab>> DeleteTransportTab(int id)
        {
            var transportTab = await _context.TransportTab.FindAsync(id);
            if (transportTab == null)
            {
                return NotFound();
            }

            _context.TransportTab.Remove(transportTab);
            await _context.SaveChangesAsync();

            return transportTab;
        }

        private bool TransportTabExists(int id)
        {
            return _context.TransportTab.Any(e => e.Id == id);
        }
    }
}
