using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using TestApp1.Code;
using SQLite;
using Mono.Data.Sqlite;
using System.Data;

namespace TestApp1
{
    [Activity(Label = "Welcome to Shimlar", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it

            EditText userName = FindViewById<EditText>(Resource.Id.userName);
            EditText password = FindViewById<EditText>(Resource.Id.userPass);
            Button login = FindViewById<Button>(Resource.Id.login);

            login.Click += delegate {
                using (var conn = new SqliteConnection((thisUser.dbConnection)))
                {
                    conn.Open();
                    using (var command = conn.CreateCommand())
                    {
                        command.CommandText = "CREATE TABLE User (user_id INTEGER PRIMARY KEY AUTOINCREMENT, userName ntext, characterName ntext, password ntext, weapon ntext, armour ntext, ring ntext)";
                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();
                        command.CommandText = "INSERT INTO  User VALUES (@userName, @characterName, @password)";
                        command.Parameters.AddWithValue("@userName", thisUser.UserName);
                        command.Parameters.AddWithValue("@characterName", thisUser.CharacterName);
                        command.Parameters.AddWithValue("@password", thisUser.Password);
                        command.ExecuteNonQuery();
                    }
                }
                SetContentView(Resource.Layout.Game);

            };

            Button newUser = FindViewById<Button>(Resource.Id.newUser);

            newUser.Click += delegate {
                SetContentView(Resource.Layout.Register);

                EditText characterName = FindViewById<EditText>(Resource.Id.charName);
                EditText newUserName = FindViewById<EditText>(Resource.Id.userName);
                EditText newUserPassword = FindViewById<EditText>(Resource.Id.mainPass);
                EditText compareNewPassword = FindViewById<EditText>(Resource.Id.checkPass);
                Button createUser = FindViewById<Button>(Resource.Id.createUser);

                createUser.Click += delegate {
                    var pathToDb =  User.CreateDatabase();
                    var thisUser = new User();
                    
                    thisUser.CharacterName = characterName.ToString(); ;
                    thisUser.UserName = newUserName.ToString();
                    if (newUserPassword == compareNewPassword)
                    {
                        thisUser.Password = newUserPassword.ToString();

                    }
                    thisUser.dbConnection = new SqliteConnection(string.Format("DataSource={0};Version=3;", pathToDb));


                    using (var conn = new SqliteConnection((thisUser.dbConnection)))
                    {
                        conn.Open();
                        using (var command = conn.CreateCommand())
                        {
                            command.CommandText = "CREATE TABLE User (user_id INTEGER PRIMARY KEY AUTOINCREMENT, userName ntext, characterName ntext, password ntext, weapon ntext, armour ntext, ring ntext)";
                            command.CommandType = CommandType.Text;
                            command.ExecuteNonQuery();
                            command.CommandText = "INSERT INTO  User VALUES (@userName, @characterName, @password)";
                            command.Parameters.AddWithValue("@userName", thisUser.UserName);
                            command.Parameters.AddWithValue("@characterName", thisUser.CharacterName);
                            command.Parameters.AddWithValue("@password", thisUser.Password);
                            command.ExecuteNonQuery();
                        }
                    }

                    SetContentView(Resource.Layout.Game);
                };
            };

            
        }
    }
}

