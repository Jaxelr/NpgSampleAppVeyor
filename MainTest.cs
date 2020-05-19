using Npgsql;
using System;
using Xunit;
using Dapper;
using System.Collections.Generic;

namespace NpgSampleAppVeyorTests
{
    public class MainTest
    {
        public static IEnumerable<object[]> GetData()
        {
            //We do this to pass the connection from Appveyor or locally
            string postgresConnEnv = Environment.GetEnvironmentVariable("Postgres_Connection");
            if(string.IsNullOrEmpty(postgresConnEnv))
            {
                postgresConnEnv = $"Server=localhost;Port=5432;Database=postgres;Integrated Security=true;Username=postgres;Password=postgres;";
            }

            return new List<object[]>
            {
                new object[] { postgresConnEnv }
            };
        }

        [Theory]
        [MemberData(nameof(GetData))]
        public void Test1(string connectionString)
        {
            var conn = new NpgsqlConnection(connectionString);

            conn.Open();

            Assert.NotNull(conn);
            Assert.Equal(1, conn.QueryFirst<int>("SELECT 1"));
        }

        [Theory]
        [MemberData(nameof(GetData))]
        public void Test2(string connectionString)
        {
            var conn = new NpgsqlConnection(connectionString);

            conn.Open();

            Assert.NotNull(conn);
            Assert.Equal(2, conn.QueryFirst<int>("SELECT 2"));
        }
    }
}
