using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClientDataHarvester.WebApi.Data;
using ClientDataHarvester.WebApi.Models;

namespace ClientDataHarvester.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientDataController : ControllerBase
    {
        private readonly ClientDataContext _context;

        public ClientDataController(ClientDataContext context)
        {
            _context = context;
        }

        // GET: api/ClientData
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientData>>> GetClientData()
        {
            return await _context.ClientData.ToListAsync();
        }

        // GET: api/ClientData/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientData>> GetClientData(int id)
        {
            var clientData = await _context.ClientData.FindAsync(id);

            if (clientData == null)
            {
                return NotFound();
            }

            return clientData;
        }

        // PUT: api/ClientData/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientData(int id, ClientData clientData)
        {
            if (id != clientData.ID)
            {
                return BadRequest();
            }

            _context.Entry(clientData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientDataExists(id))
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

        // POST: api/ClientData
        [HttpPost]
        public async Task<ActionResult<ClientData>> PostClientData(ClientData clientData)
        {
            _context.ClientData.Add(clientData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClientData", new { id = clientData.ID }, clientData);
        }

        // GET: api/ClientData/LatestForAllClients
[HttpGet("LatestForAllClients")]
public async Task<ActionResult<IEnumerable<ClientData?>>> GetLatestClientDataForAllClients()
{
    var latestClientData = await _context.ClientData
        .GroupBy(d => new { d.ClientName, d.DataType })
        .Select(g => g.OrderByDescending(d => d.TimeAdded).FirstOrDefault())
        .ToListAsync();

    if (latestClientData == null)
    {
        return NotFound();
    }

    return latestClientData;
}



        // DELETE: api/ClientData/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClientData>> DeleteClientData(int id)
        {
            var clientData = await _context.ClientData.FindAsync(id);
            if (clientData == null)
            {
                return NotFound();
            }

            _context.ClientData.Remove(clientData);
            await _context.SaveChangesAsync();

            return clientData;
        }

        private bool ClientDataExists(int id)
        {
            return _context.ClientData.Any(e => e.ID == id);
        }
    }
}
