using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemPalV1
{
    internal class SQL_Information
    {
        internal static string ConnectionString = GetConnectionString();
        internal static string GetConnectionString()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string databasePath = Path.Combine(baseDirectory, "Database1.mdf");
            string connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={databasePath};Integrated Security=True";

            return connectionString;
        }
    }
}
