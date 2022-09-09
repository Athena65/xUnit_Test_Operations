using Microsoft.AspNetCore.Mvc;
using XUnit_NetCore6_WebApi.Models;
using XUnit_NetCore6_WebApi.Services;

namespace XUnit_NetCore6_WebApi.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class ShoppingController:ControllerBase
    {
        private readonly IShoppingService _service;

        public ShoppingController(IShoppingService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var items =  await _service.GetAllItems();
                return Ok(items);
            }
            catch (Exception ex)
            {
                var response = new ServiceResponse();
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>  GetById(Guid id)
        {
            try
            {
                var item = await _service.GetById(id);
                if (item == null)
                    return NotFound();

                return Ok(item);

            }
            catch (Exception ex)
            {
                var response = new ServiceResponse();
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ShoppingItem value)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var item = await _service.Add(value);
                return CreatedAtAction("Get",new {id= item.Id}, item);

            }
            catch (Exception ex)
            {
                var response = new ServiceResponse();
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(Guid id)
        {
            try
            {
                var existingItem = _service.GetById(id);
                if (existingItem == null)
                    return NotFound();

                await _service.Remove(id);
                return Ok("Deleted");

            }
            catch (Exception ex)
            {
                var response = new ServiceResponse();
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

    }
}
