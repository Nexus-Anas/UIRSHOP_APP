using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UIRSHOP.BL.Models.Dtos.ClientDtos;
using UIRSHOP.BL.Models.Dtos.ProductDtos;
using UIRSHOP.BL.Services;

namespace UIRSHOP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDto>>> Get()
        {
            try
            {
                var clients = await _clientService.GetAllClients();
                return Ok(clients);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving Clients");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDto>> GetById(int id)
        {
            try
            {
                var client = await _clientService.GetClient(id);
                if (client == null)
                {
                    return NotFound();
                }
                return Ok(client);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving product");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ClientDto>> Create([FromBody] ClientDto clientDto)
        {
            if (clientDto == null)
            {
                return BadRequest("Product data is null");
            }

            try
            {
                var newClient = await _clientService.CreateClient(clientDto);
                return CreatedAtAction(nameof(GetById), new { id = newClient.Id }, newClient);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating client");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ClientDto clientDto)
        {
            if (id != clientDto.Id)
            {
                return BadRequest("Product ID mismatch");
            }

            try
            {
                await _clientService.UpdateClient(id, clientDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating product");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _clientService.DeleteClient(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting product");
            }
        }

    }
}
