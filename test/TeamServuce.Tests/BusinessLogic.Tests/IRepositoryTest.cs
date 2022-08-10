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

internal class IRepositoryTest
{
    public static Mock<IRepository<Player>> GetPlayerMock()
    {
        var mock = new Mock<IRepository<Player>>();

        mock.Setup(repository => repository.Create(It.IsAny<Player>()))
            .Returns(Task.CompletedTask);
        mock.Setup(repository => repository.Update(It.IsAny<Player>()))
            .Returns(Task.CompletedTask);
        mock.Setup(repository => repository.Delete(It.IsAny<Guid>()))
            .Returns(Task.CompletedTask);
        mock.Setup(repository => repository.GetById(It.IsAny<Guid>()))
            .Returns(Task<Player>.FromResult(new Player()));
        mock.Setup(repository => repository.GetRange(It.IsAny<int>(), It.IsAny<int>()))
            .Returns(Task<IEnumerable<Player>>.FromResult((new Player[] { new Player(), new Player() }).AsEnumerable()));

        return mock;
    }

    public static Mock<IRepository<Team>> GetTeamMock()
    {
        var mock = new Mock<IRepository<Team>>();

        mock.Setup(repository => repository.Create(It.IsAny<Team>()))
            .Returns(Task.CompletedTask);
        mock.Setup(repository => repository.Update(It.IsAny<Team>()))
            .Returns(Task.CompletedTask);
        mock.Setup(repository => repository.Delete(It.IsAny<Guid>()))
            .Returns(Task.CompletedTask);
        mock.Setup(repository => repository.GetById(It.IsAny<Guid>()))
            .Returns(Task<Team>.FromResult(new Team()));
        mock.Setup(repository => repository.GetRange(It.IsAny<int>(), It.IsAny<int>()))
            .Returns(Task<IEnumerable<Team>>.FromResult((new Team[] { new Team(), new Team() }).AsEnumerable()));

        return mock;
    }

    public static IRepository<Player> GetPlayerIRepository() => GetPlayerMock().Object;

    public static IRepository<Team> GetTeamIRepository() => GetTeamMock().Object;

    [TestCase("GetById")]
    [TestCase("Create")]
    [TestCase("Update")]
    [TestCase("Delete")]
    [TestCase("GetRange")]
    public void CheckingForMethods(string methodName)
    {
        var methodInfo = typeof(IRepository<Player>).GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public);

        Check(typeof(Player));

        methodInfo = typeof(IRepository<Team>).GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public);

        Check(typeof(Team));

        void Check(Type type)
        {
            switch (methodName)
            {
                case "GetById":
                    if (type == typeof(Player))
                    {
                        Assert.AreEqual(typeof(Task<Player>), methodInfo.ReturnType);
                    }
                    else if (type == typeof(Team))
                    {
                        Assert.AreEqual(typeof(Task<Team>), methodInfo.ReturnType);
                    }

                    Assert.AreEqual(typeof(Guid), methodInfo.GetParameters()[0].ParameterType);
                    
                    break;
                case "Create":
                    Assert.AreEqual(type, methodInfo.GetParameters()[0].ParameterType);
                    Assert.AreEqual(typeof(Task), methodInfo.ReturnType);
                    break;
                case "Delete":
                    Assert.AreEqual(typeof(Guid), methodInfo.GetParameters()[0].ParameterType);
                    Assert.AreEqual(typeof(Task), methodInfo.ReturnType);
                    break;
                case "Update":
                    Assert.AreEqual(type, methodInfo.GetParameters()[0].ParameterType);
                    Assert.AreEqual(typeof(Task), methodInfo.ReturnType);
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
            }   
        }
    }
}
