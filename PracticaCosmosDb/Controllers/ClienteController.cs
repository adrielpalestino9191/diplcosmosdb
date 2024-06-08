using Microsoft.AspNetCore.Mvc;
using PracticaCosmosDb.Data;
using PracticaCosmosDb.Model;
using System.Data.Entity;

namespace PracticaCosmosDb.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly AppDbContexts _context;

        public ClienteController(AppDbContexts context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> ListarClientes()
        {
            return await _context.Cliente.ToListAsync();
        } 
    }
}
