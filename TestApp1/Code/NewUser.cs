using SQLite;
using Mono.Data.Sqlite;
using Android.Renderscripts;

namespace TestApp1.Code
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string CharacterName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set;}
        public SqliteConnection dbConnection { get; set; }


        public static string CreateDatabase()
        {
            var docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var pathToDatabase = System.IO.Path.Combine(docsFolder, "db_adonet.db");
            SqliteConnection.CreateFile(pathToDatabase);

            return pathToDatabase;
        }
    }

    
}