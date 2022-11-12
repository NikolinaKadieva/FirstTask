namespace FirstTask.API.Controllers
{
    using FirstTask.Shared.DTOs;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private FirstTask.BLL.UserBLL _BLL;
        public UserController()
        {
            _BLL = new BLL.UserBLL();
        }


        [HttpGet]
        public List<UserDTO> Get()
        {
            return _BLL.Get();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _BLL.GetById(id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(UserDTO user)
        {
            await _BLL.Create(user);

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        [ProducesResponseTypeAttribute(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, UserDTO user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            await _BLL.Update(id, user);

            return NoContent();
        }


        [HttpDelete("{id}")]
        [ProducesResponseTypeAttribute(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
           await _BLL.Delete(id);

            return NoContent();
        }
    }
}
