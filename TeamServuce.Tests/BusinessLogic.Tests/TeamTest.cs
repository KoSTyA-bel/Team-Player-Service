using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TeamService.BusinessLogic.Entities;

namespace TeamService.Tests.BusinessLogic.Tests;

[TestFixture]
internal class TeamTest
{
    public static IEnumerable<Team> Teams()
    {
        yield return new Team { Name = "First" };
        yield return new Team { Name = "Second" };
        yield return new Team { Name = "Third" };
        yield return new Team { Name = "Four" };
        yield return new Team { Name = "Five" };
        yield return new Team { Name = "ASJ>Hflaksdjghj" };
        yield return new Team { Name = "aslj;dghlaskdjgsjkdl;fjn;dpsfbie;lkjewo'rsadfsadgfdh" };
    }

    [TestCaseSource(nameof(Teams))]
    public void ToStringTest(Team team)
    {
        Assert.AreEqual($"Team name: {team.Name}. Count of players: {team.Players.Count()}", team.ToString());
    }

    [TestCaseSource(nameof(Teams))]
    public void EqualsTrueTest(Team first)
    {
        var second = new Team
        {
            Name = first.Name,
            Id = first.Id,
            Players = first.Players,
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

    [TestCaseSource(nameof(Teams))]
    public void EqualsFalseTest(Team first)
    {
        var second = new Team
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

    [TestCaseSource(nameof(Teams))]
    public void HashCodeIsConstantTest(Team team)
    {
        Assert.AreEqual(team.GetHashCode(), team.GetHashCode());
    }

    [TestCase("Id", typeof(Guid))]
    [TestCase("Name", typeof(string))]
    [TestCase("Players", typeof(IEnumerable<Player>))]
    public void CheckingForProperties(string properyName, Type propertyType)
    {
        var propertyInfo = typeof(Team).GetProperty(properyName, BindingFlags.Public | BindingFlags.Instance);
        Assert.AreEqual(properyName, propertyInfo.Name);
        Assert.AreEqual(propertyType, propertyInfo.PropertyType);
    }
}
