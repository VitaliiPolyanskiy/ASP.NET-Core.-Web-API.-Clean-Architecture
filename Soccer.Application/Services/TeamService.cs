using Soccer.Application.DTO;
using Soccer.Domain.Entities;
using Soccer.Application.Exceptions;
using Soccer.Application.Interfaces;
using AutoMapper;

namespace Soccer.Application.Services;

public class TeamService(IUnitOfWork database, IMapper mapper) : ITeamService
{
    public async Task CreateTeam(TeamDTO teamDto)
    {
        var team = new Team { Id = teamDto.Id, Name = teamDto.Name, Coach = teamDto.Coach };
        await database.Teams.Create(team);
        await database.Save();
    }

    public async Task UpdateTeam(TeamDTO teamDto)
    {
        var team = new Team { Id = teamDto.Id, Name = teamDto.Name, Coach = teamDto.Coach };
        database.Teams.Update(team);
        await database.Save();
    }

    public async Task DeleteTeam(int id)
    {
        await database.Teams.Delete(id);
        await database.Save();
    }

    public async Task<TeamDTO> GetTeam(int id)
    {
        var team = await database.Teams.Get(id);
        if (team == null)
            throw new ValidationException("Дані відсутні!", nameof(id));

        return mapper.Map<TeamDTO>(team);
    }

    public async Task<IEnumerable<TeamDTO>> GetTeams()
    {
        var teams = await database.Teams.GetAll();
        return mapper.Map<IEnumerable<TeamDTO>>(teams);
    }
}