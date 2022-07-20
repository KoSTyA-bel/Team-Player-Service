namespace TeamService.BusinessLogic.Entities;

/// <summary>
/// Entity for db.
/// </summary>
public class Player : IEquatable<Player>
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

    public static bool operator ==(Player left, Player right)
    {
        return left != null ? left.Equals(right) : right == null;
    }

    public static bool operator !=(Player left, Player right) => !(left == right);

    public override int GetHashCode()
    {
        return this.Id.GetHashCode() ^ this.TeamId.GetHashCode() ^ this.Name.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        if (obj == null)
        {
            return false;
        }

        var player = obj as Player;

        return this.Equals(player);
    }

    public bool Equals(Player? other)
    {
        if (other == null)
        {
            return false;
        }

        return this.Id.Equals(other.Id)
            && this.TeamId.Equals(other.TeamId)
            && this.Name.Equals(other.Name, StringComparison.InvariantCulture);
    }

    public override string ToString()
    {
        return $"Player name: {this.Name}";
    }
}
