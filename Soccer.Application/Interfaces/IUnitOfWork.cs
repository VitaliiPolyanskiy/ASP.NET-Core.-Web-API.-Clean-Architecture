using Soccer.Domain.Entities;

namespace Soccer.Application.Interfaces;

public interface IUnitOfWork
{
    IRepository<Team> Teams { get; }
    IRepository<Player> Players { get; }
    Task Save();
}