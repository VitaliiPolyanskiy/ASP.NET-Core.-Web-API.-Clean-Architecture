using Microsoft.AspNetCore.Mvc;
using Soccer.Application.DTO;
using Soccer.Application.Interfaces;
using Soccer.Application.Exceptions;

namespace Soccer.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlayersController(IPlayerService playerService) : ControllerBase
{
    // GET: api/players
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PlayerDTO>>> GetPlayers()
    {
        var players = await playerService.GetPlayers();
        return Ok(players);
    }

    // GET: api/players/5
    [HttpGet("{id}")]
    public async Task<ActionResult<PlayerDTO>> GetPlayer(int id)
    {
        try
        {
            var player = await playerService.GetPlayer(id);
            return Ok(player);
        }
        catch (ValidationException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    // POST: api/players
    [HttpPost]
    public async Task<ActionResult> CreatePlayer([FromBody] PlayerDTO playerDto)
    {
        await playerService.CreatePlayer(playerDto);
        return CreatedAtAction(nameof(GetPlayer), new { id = playerDto.Id }, playerDto);
    }

    // PUT: api/players/5
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdatePlayer(int id, [FromBody] PlayerDTO playerDto)
    {
        if (id != playerDto.Id)
        {
            return BadRequest(new { message = "ID у маршруті не співпадає з ID у тілі запиту." });
        }

        await playerService.UpdatePlayer(playerDto);
        return NoContent();
    }

    // DELETE: api/players/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePlayer(int id)
    {
        await playerService.DeletePlayer(id);
        return NoContent();
    }
}