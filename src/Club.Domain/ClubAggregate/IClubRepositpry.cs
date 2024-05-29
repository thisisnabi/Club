namespace Club.Domain.ClubAggregate;
public interface IClubRepositpry
{
    Task SaveChangesAsync();
    Task CreateAsync(Club club);
}
