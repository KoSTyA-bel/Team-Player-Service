namespace TeamService.BusinessLogic.Entities;

/// <summary>
/// Entity for db.
/// </summary>
public class Team
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Team"/> class.
    /// </summary>
    public Team()
    {
        Id = Guid.NewGuid();
        Name = Id.ToString();
        Players = new List<Player>();
    }

    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>
    /// The identifier.
    /// </value>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>
    /// The name.
    /// </value>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the players.
    /// </summary>
    /// <value>
    /// The players.
    /// </value>
    public IEnumerable<Player> Players { get; set; }

    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <returns>
    /// A <see cref="System.String" /> that represents this instance.
    /// </returns>
    public override string ToString() => $"Team name: {Name}. Count of players: {Players.Count()}";
}
