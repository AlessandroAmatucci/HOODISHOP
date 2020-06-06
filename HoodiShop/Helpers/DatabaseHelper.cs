using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using MySql.Data.MySqlClient;
using Dapper;
using HoodiShop.Models.Entities;

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
    }
}