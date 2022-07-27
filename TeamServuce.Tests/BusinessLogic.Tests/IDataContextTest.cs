using Moq;
using NUnit.Framework;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using TeamService.BusinessLogic.Interfaces;

namespace TeamService.Tests.BusinessLogic.Tests;

[TestFixture]
internal class IDataContextTest
{
    public static Mock<IDataContext> GetMock()
    {
        var mock = new Mock<IDataContext>();

        mock.Setup(context => context.SaveChangesAsync(CancellationToken.None)).Returns(Task.CompletedTask);

        return mock;
    }

    public static IDataContext GetIDataContext() => GetMock().Object;

    [TestCase("SaveChangesAsync", typeof(CancellationToken), typeof(Task))]
    public void CheckingForMethods(string methodName, Type paramType, Type returnType)
    {
        var methodInfo = typeof(IDataContext).GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public);
        Assert.AreEqual(1, methodInfo.GetParameters().Length);
        Assert.AreEqual(paramType, methodInfo.GetParameters()[0].ParameterType);
        Assert.AreEqual(returnType, methodInfo.ReturnType);
    }
}
