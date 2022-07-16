namespace TeamService.BusinessLogic.Entities;

/// <summary>
/// Entity for db.
/// </summary>
public class Player
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Player"/> class.
    /// </summary>
    public Player()
    {
        Id = Guid.Empty;
        Name = string.Empty;
        TeamId = Guid.Empty;
        Team = null;
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
    /// Gets or sets the team identifier.
    /// </summary>
    /// <value>
    /// The team identifier.
    /// </value>
    public Guid TeamId { get; set; }

    /// <summary>
    /// Gets or sets the team.
    /// </summary>
    /// <value>
    /// The team.
    /// </value>
    public Team Team { get; set; }
}
