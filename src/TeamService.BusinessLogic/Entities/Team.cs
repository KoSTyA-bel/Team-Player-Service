namespace TeamService.BusinessLogic.Entities;

public class Team
{
    public Team()
    {
        Id = Guid.NewGuid();
        Name = Id.ToString();
        Players = new List<Player>();
    }

    public Guid Id { get; set; }

    public string Name { get; set; }

    public IEnumerable<Player> Players { get; set; }

    public override string ToString() => $"Team name: {Name}. Count of players: {Players.Count()}";
}
