using Npgsql;
using System;
using Xunit;

namespace NpgSampleAppVeyorTests
{
    public class MainTest
    {
        [Fact]
        public void Test1()
        {
            string postgresConnEnv = Environment.GetEnvironmentVariable("Pg_Connection");
            // if (string.IsNullOrEmpty(postgresConnEnv))
            // {
            //     postgresConnEnv = $"Server=localhost;Port=5432;Database=postgres;Integrated Security=true;Username=postgres";
            // }

            var conn = new NpgsqlConnection(postgresConnEnv);

            conn.Open();

            Assert.NotNull(conn);
        }
    }
}
