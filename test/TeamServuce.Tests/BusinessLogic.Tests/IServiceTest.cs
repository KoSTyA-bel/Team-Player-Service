using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using TeamService.BusinessLogic.Entities;
using TeamService.BusinessLogic.Interfaces;

namespace TeamService.Tests.BusinessLogic.Tests;

[TestFixture]
internal class IServiceTest
{
    public static Mock<IPlayerService> GetPlayerMock()
    {
        var mock = new Mock<IPlayerService>();
        var player = new Player();

        mock.Setup(repository => repository.Create(It.IsAny<Player>()))
            .Returns(Task.FromResult(new Player()));
        mock.Setup(repository => repository.Update(It.IsAny<Player>()))
            .Returns(Task.FromResult(new Player()));
        mock.Setup(repository => repository.Delete(It.IsAny<Guid>()))
            .Returns(Task.FromResult(true));
        mock.Setup(repository => repository.TryGetById(It.IsAny<Guid>(), out player))
            .Returns(true);
        mock.Setup(repository => repository.GetRange(It.IsAny<int>(), It.IsAny<int>()))
            .Returns(Task<IEnumerable<Player>>.FromResult((new Player[] { new Player(), new Player() }).AsEnumerable()));

        return mock;
    }

    public static Mock<ITeamService> GetTeamMock()
    {
        var mock = new Mock<ITeamService>();
        var team = new Team();

        mock.Setup(repository => repository.Create(It.IsAny<Team>()))
            .Returns(Task.FromResult(new Team()));
        mock.Setup(repository => repository.Update(It.IsAny<Team>()))
            .Returns(Task.FromResult(new Team()));
        mock.Setup(repository => repository.Delete(It.IsAny<Guid>()))
            .Returns(Task.FromResult(true));
        mock.Setup(repository => repository.TryGetById(It.IsAny<Guid>(), out team))
            .Returns(true);
        mock.Setup(repository => repository.GetRange(It.IsAny<int>(), It.IsAny<int>()))
            .Returns(Task<IEnumerable<Team>>.FromResult((new Team[] { new Team(), new Team() }).AsEnumerable()));

        return mock;
    }

    public static IPlayerService GetPlayerIService() => GetPlayerMock().Object;

    public static ITeamService GetTeamIService() => GetTeamMock().Object;

    [TestCase("TryGetById")]
    [TestCase("Create")]
    [TestCase("Update")]
    [TestCase("Delete")]
    [TestCase("GetRange")]
    public void CheckingForMethods(string methodName)
    {
        var methodInfo = typeof(IPlayerService).GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public);

        Check(typeof(Player));

        methodInfo = typeof(ITeamService).GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public);

        Check(typeof(Team));

        void Check(Type type)
        {
            switch (methodName)
            {
                case "TryGetById":
                    Assert.AreEqual($"{type.Name}&", methodInfo.GetParameters()[1].ParameterType.Name);                    
                    Assert.AreEqual(typeof(bool), methodInfo.ReturnType);
                    Assert.AreEqual(typeof(Guid), methodInfo.GetParameters()[0].ParameterType);
                    break;
                case "Create":
                    if (type == typeof(Player))
                    {
                        Assert.AreEqual(typeof(Task<Player>), methodInfo.ReturnType);
                    }
                    else if (type == typeof(Team))
                    {
                        Assert.AreEqual(typeof(Task<Team>), methodInfo.ReturnType);
                    }

                    Assert.AreEqual(type, methodInfo.GetParameters()[0].ParameterType);
                    break;
                case "Delete":
                    Assert.AreEqual(typeof(Guid), methodInfo.GetParameters()[0].ParameterType);
                    Assert.AreEqual(typeof(Task<bool>), methodInfo.ReturnType);
                    break;
                case "Update":
                    if (type == typeof(Player))
                    {
                        Assert.AreEqual(typeof(Task<Player>), methodInfo.ReturnType);
                    }
                    else if (type == typeof(Team))
                    {
                        Assert.AreEqual(typeof(Task<Team>), methodInfo.ReturnType);
                    }

                    Assert.AreEqual(type, methodInfo.GetParameters()[0].ParameterType);
                    break;
                case "GetRange":
                    if (type == typeof(Player))
                    {
                        Assert.AreEqual(typeof(Task<IEnumerable<Player>>), methodInfo.ReturnType);
                    }
                    else if (type == typeof(Team))
                    {
                        Assert.AreEqual(typeof(Task<IEnumerable<Team>>), methodInfo.ReturnType);
                    }
                    Assert.AreEqual(typeof(int), methodInfo.GetParameters()[0].ParameterType);
                    Assert.AreEqual(typeof(int), methodInfo.GetParameters()[1].ParameterType);
                    break;
                default:
                    break;
            }
        }
    }
}
