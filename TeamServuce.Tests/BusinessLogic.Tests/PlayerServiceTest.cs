using TeamService.BusinessLogic.Services;
using TeamService.BusinessLogic.Interfaces;
using TeamService.BusinessLogic.Entities;
using NUnit.Framework;
using System.Threading;
using Moq;
using System.Collections.Generic;
using System;

namespace TeamService.Tests.BusinessLogic.Tests;

[TestFixture]
internal class PlayerServiceTest
{
    private static IEnumerable<Player> correctPlayers = PlayerTest.Players();

    [TestCaseSource(nameof(correctPlayers))]
    public void CreateSuccesTest(Player player)
    {
        var dataContextMock = IDataContextTest.GetMock();
        var repositoryMock = IRepositoryTest.GetPlayerMock();
        var service = new PlayerService(repositoryMock.Object, dataContextMock.Object);

        var result = service.Create(player).GetAwaiter().GetResult();

        dataContextMock.Verify(x => x.SaveChangesAsync(CancellationToken.None));
        repositoryMock.Verify(x => x.Create(It.IsAny<Player>()));

        Assert.AreEqual(player, result);
    }

    [TestCaseSource(nameof(correctPlayers))]
    public void UpdateSuccesTest(Player player)
    {
        var dataContextMock = IDataContextTest.GetMock();
        var repositoryMock = IRepositoryTest.GetPlayerMock();
        var service = new PlayerService(repositoryMock.Object, dataContextMock.Object);

        var result = service.Update(player).GetAwaiter().GetResult();

        dataContextMock.Verify(x => x.SaveChangesAsync(CancellationToken.None));
        repositoryMock.Verify(x => x.Update(It.IsAny<Player>()));

        Assert.AreEqual(player, result);
    }

    [TestCaseSource(nameof(correctPlayers))]
    public void DeleteSuccesTest(Player player)
    {
        var dataContextMock = IDataContextTest.GetMock();
        var repositoryMock = IRepositoryTest.GetPlayerMock();
        var service = new PlayerService(repositoryMock.Object, dataContextMock.Object);

        var result = service.Delete(player.Id).GetAwaiter().GetResult();

        dataContextMock.Verify(x => x.SaveChangesAsync(CancellationToken.None));
        repositoryMock.Verify(x => x.Delete(It.IsAny<Guid>()));

        Assert.IsTrue(result);
    }

    [Test]
    public void TryGetByIdSuccesTest()
    {
        var dataContextMock = IDataContextTest.GetMock();
        var repositoryMock = IRepositoryTest.GetPlayerMock();
        var service = new PlayerService(repositoryMock.Object, dataContextMock.Object);

        var result = service.TryGetById(Guid.Empty, out Player player);

        repositoryMock.Verify(x => x.GetById(It.IsAny<Guid>()));

        Assert.IsTrue(result);
    }

    [Test]
    public void GetRangeSuccesTest()
    {
        var dataContextMock = IDataContextTest.GetMock();
        var repositoryMock = IRepositoryTest.GetPlayerMock();
        var service = new PlayerService(repositoryMock.Object, dataContextMock.Object);

        var result = service.GetRange(int.MinValue, int.MaxValue).GetAwaiter().GetResult();

        repositoryMock.Verify(x => x.GetRange(It.IsAny<int>(), It.IsAny<int>()));

        Assert.NotNull(result);
    }
}
