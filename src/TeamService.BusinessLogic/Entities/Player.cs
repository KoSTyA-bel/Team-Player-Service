namespace TeamService.BusinessLogic.Entities;

public class Player
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public Guid TeamId { get; set; }

    public Team Team { get; set; }
}
