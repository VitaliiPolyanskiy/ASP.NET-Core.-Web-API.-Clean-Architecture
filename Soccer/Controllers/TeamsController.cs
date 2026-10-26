using Microsoft.AspNetCore.Mvc;
using Soccer.Application.DTO;
using Soccer.Application.Interfaces;
using Soccer.Application.Exceptions;

namespace Soccer.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeamsController(ITeamService teamService) : ControllerBase
{
    // GET: api/teams
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TeamDTO>>> GetTeams()
    {
        var teams = await teamService.GetTeams();
        return Ok(teams);
    }

    // GET: api/teams/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TeamDTO>> GetTeam(int id)
    {
        try
        {
            var team = await teamService.GetTeam(id);
            return Ok(team);
        }
        catch (ValidationException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    // POST: api/teams
    [HttpPost]
    public async Task<ActionResult> CreateTeam([FromBody] TeamDTO teamDto)
    {
        await teamService.CreateTeam(teamDto);
        return CreatedAtAction(nameof(GetTeam), new { id = teamDto.Id }, teamDto);
    }

    // PUT: api/teams/5
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateTeam(int id, [FromBody] TeamDTO teamDto)
    {
        if (id != teamDto.Id)
        {
            return BadRequest(new { message = "ID у маршруті не співпадає з ID у тілі запиту." });
        }

        await teamService.UpdateTeam(teamDto);
        return NoContent();
    }

    // DELETE: api/teams/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTeam(int id)
    {
        await teamService.DeleteTeam(id);
        return NoContent();
    }
}