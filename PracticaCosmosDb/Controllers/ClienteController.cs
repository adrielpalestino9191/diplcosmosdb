using Microsoft.AspNetCore.Mvc;
using PracticaCosmosDb.Data;
using PracticaCosmosDb.Model;
using Microsoft.EntityFrameworkCore;

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

        [HttpPost]
        public async Task<ActionResult<Cliente>> NuevoCliente(Cliente cliente)
        {
            _context.Cliente.Add(cliente);
            await _context.SaveChangesAsync();
            return Ok("Cliente agregado");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Cliente>> EliminarCliente(string id)
        {
           var cliente = await _context.Cliente.FindAsync(id);
 
            if(cliente == null)
            {
                return NotFound();
            }

       
            _context.Cliente.Remove(cliente);        
            return Ok("Cliente eliminado");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Cliente>> ModificarCliente(string id,Cliente cli)
        {
            var cliente = await _context.Cliente.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }


            _context.Entry(cli).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok("Cliente modificado");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> BuscarPorId(string id)
        {
            var cliente = await _context.Cliente.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }
        [HttpGet("{correo}")]
        public async Task<ActionResult<Cliente>> BuscarPorCorreo(string correo)
        {
            //LINQ
            var cliente = await _context.Cliente.Where(cli => cli.Correo == correo).ToListAsync();

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

    }
}
