using System;
using Xunit;

namespace DesignPatterns.Creational
{
    public class SingletonDatabase
    {
        private string connectionString;
        private SingletonDatabase()
        {
            connectionString = "asasdfsdf";
        }

        private static Lazy<SingletonDatabase> instance = new Lazy<SingletonDatabase>(() => new SingletonDatabase());
        public static SingletonDatabase Instance => instance.Value;
    }

    public class SingletonTester
    {
        [Fact]
        private void ShouldBeSingleton()
        {
            Assert.True(IsSingleton(() => SingletonDatabase.Instance));
        }

        private static bool IsSingleton(Func<object> func)
        {
            var obj1 = func();
            var obj2 = func();

            return obj1 == obj2;
        }

    }
}
