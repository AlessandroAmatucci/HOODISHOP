using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using MySql.Data.MySqlClient;
using Dapper;
using HoodiShop.Models.Entities;
using HoodiShop.Models;

namespace HoodiShop.Helpers
{
    public class DatabaseHelper
    {
        private static string ConnectionString =
               ConfigurationManager.ConnectionStrings["Database"].ConnectionString; //personalizzare la set per gestire l'eccezione

        public static List<Beat> GetAllBeats()
        {
            var beats = new List<Beat>();
            using(var connection=new MySqlConnection(ConnectionString))
            {
                var sql = "select * from beat";
                beats = connection.Query<Beat>(sql).ToList();
            }
            return beats;
        }

        public static User Login(string username, string password)
        {
            var user = new User();
            using (var connection = new MySqlConnection(ConnectionString))
            {
                var sql = "select * from utente where username=@username and password=@password";
                user = connection.Query<User>(sql, new { username, password }).FirstOrDefault();
            }
            return user;
        }

        public static void Purchase(PurchaseModel model)
        {
            using(var connection=new MySqlConnection(ConnectionString))
            {
                var sql = "update beat set owner=@username where ID=@idBeat";
                int updatedRows = connection.Execute(sql,model);
            }
        }

        public static List<Beat> GetBeatPosseduti(string username)
        {
            var beatPosseduti = new List<Beat>();
            using (var connection=new MySqlConnection(ConnectionString))
            {
                var sql = "select * from beat where owner=@username";
                beatPosseduti = connection.Query<Beat>(sql, new { username }).ToList();
            }
            return beatPosseduti;
        }
    }
}