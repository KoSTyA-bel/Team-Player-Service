using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using TeamService.BusinessLogic.Entities;
using TeamService.BusinessLogic.Interfaces;
using TeamService.BusinessLogic.Services;


namespace TeamService.Tests.BusinessLogic.Tests;

[TestFixture]
internal class TeamServiceTest
{
    private static IEnumerable<Team> correctTeams = TeamTest.Teams();

    [TestCaseSource(nameof(correctTeams))]
    public void CreateSuccesTest(Team team)
    {
        var dataContextMock = IDataContextTest.GetMock();
        var repositoryMock = IRepositoryTest.GetTeamMock();
        var service = new TeamService.BusinessLogic.Services.TeamService(repositoryMock.Object, dataContextMock.Object);

        var result = service.Create(team).GetAwaiter().GetResult();

        dataContextMock.Verify(x => x.SaveChangesAsync(CancellationToken.None));
        repositoryMock.Verify(x => x.Create(It.IsAny<Team>()));

        Assert.AreEqual(team, result);
    }

    [TestCaseSource(nameof(correctTeams))]
    public void UpdateSuccesTest(Team team)
    {
        var dataContextMock = IDataContextTest.GetMock();
        var repositoryMock = IRepositoryTest.GetTeamMock();
        var service = new TeamService.BusinessLogic.Services.TeamService(repositoryMock.Object, dataContextMock.Object);

        var result = service.Update(team).GetAwaiter().GetResult();

        dataContextMock.Verify(x => x.SaveChangesAsync(CancellationToken.None));
        repositoryMock.Verify(x => x.Update(It.IsAny<Team>()));

        Assert.AreEqual(team, result);
    }

    [TestCaseSource(nameof(correctTeams))]
    public void DeleteSuccesTest(Team team)
    {
        var dataContextMock = IDataContextTest.GetMock();
        var repositoryMock = IRepositoryTest.GetTeamMock();
        var service = new TeamService.BusinessLogic.Services.TeamService(repositoryMock.Object, dataContextMock.Object);

        var result = service.Delete(team.Id).GetAwaiter().GetResult();

        dataContextMock.Verify(x => x.SaveChangesAsync(CancellationToken.None));
        repositoryMock.Verify(x => x.Delete(It.IsAny<Guid>()));

        Assert.IsTrue(result);
    }

    [Test]
    public void TryGetByIdSuccesTest()
    {
        var dataContextMock = IDataContextTest.GetMock();
        var repositoryMock = IRepositoryTest.GetTeamMock();
        var service = new TeamService.BusinessLogic.Services.TeamService(repositoryMock.Object, dataContextMock.Object);

        var result = service.TryGetById(Guid.Empty, out Team team);

        repositoryMock.Verify(x => x.GetById(It.IsAny<Guid>()));

        Assert.IsTrue(result);
    }

    [Test]
    public void GetRangeSuccesTest()
    {
        var dataContextMock = IDataContextTest.GetMock();
        var repositoryMock = IRepositoryTest.GetTeamMock();
        var service = new TeamService.BusinessLogic.Services.TeamService(repositoryMock.Object, dataContextMock.Object);

        var result = service.GetRange(int.MinValue, int.MaxValue).GetAwaiter().GetResult();

        repositoryMock.Verify(x => x.GetRange(It.IsAny<int>(), It.IsAny<int>()));

        Assert.NotNull(result);
    }
}
