using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;
using TeamService.BusinessLogic.Entities;

namespace TeamService.Tests.BusinessLogic.Tests;

[TestFixture]
internal class PlayerTest
{
    public static IEnumerable<Player> Players()
    {
        yield return new Player { Name = "First" };
        yield return new Player { Name = "Second" };
        yield return new Player { Name = "Third" };
        yield return new Player { Name = "Four" };
        yield return new Player { Name = "Five" };
        yield return new Player { Name = "ASJ>Hflaksdjghj" };
        yield return new Player { Name = "aslj;dghlaskdjgsjkdl;fjn;dpsfbie;lkjewo'rsadfsadgfdh" };
    }
    
    [TestCaseSource(nameof(Players))]
    public void ToStringTest(Player player)
    {
        Assert.AreEqual($"Player name: {player.Name}", player.ToString());
    }

    [TestCaseSource(nameof(Players))]
    public void EqualsTrueTest(Player first)
    {
        var second = new Player
        {
            Name = first.Name,
            Id = first.Id,
            Team = first.Team,
            TeamId = first.TeamId,
        };

        Assert.AreEqual(first, second);
        Assert.IsTrue(first.Equals(second));
        Assert.IsTrue(second.Equals(first));
        Assert.IsTrue(first == second);
        Assert.IsTrue(second == first);
        Assert.IsTrue(second == first);
        Assert.IsTrue(!(second != first));
        Assert.IsTrue(!(first != second));
    }

    [TestCaseSource(nameof(Players))]
    public void EqualsFalseTest(Player first)
    {
        var second = new Player
        {
            Id = Guid.NewGuid(),
        };

        Assert.AreNotEqual(first, second);
        Assert.IsFalse(first.Equals(second));
        Assert.IsFalse(second.Equals(first));
        Assert.IsFalse(first == second);
        Assert.IsFalse(second == first);
        Assert.IsFalse(second == first);
        Assert.IsFalse(!(second != first));
        Assert.IsFalse(!(first != second));
    }

    [TestCaseSource(nameof(Players))]
    public void HashCodeIsConstantTest(Player player)
    {
        Assert.AreEqual(player.GetHashCode(), player.GetHashCode());
    }

    [TestCase("Id", typeof(Guid))]
    [TestCase("TeamId", typeof(Guid))]
    [TestCase("Name", typeof(string))]
    [TestCase("Team", typeof(Team))]
    public void CheckingForProperties(string properyName, Type propertyType)
    {
        var propertyInfo = typeof(Player).GetProperty(properyName, BindingFlags.Public | BindingFlags.Instance);
        Assert.AreEqual(properyName, propertyInfo.Name);
        Assert.AreEqual(propertyType, propertyInfo.PropertyType);
    }
}
