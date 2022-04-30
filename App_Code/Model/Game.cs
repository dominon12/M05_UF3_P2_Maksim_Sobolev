using System;
using System.Data;

namespace M05_UF3_P2_Template.App_Code.Model
{
    public class Game
    {
        public long Id { get; set; }
        public long Product_Id { get; set; }
        public Product product { get; set; }
        public double Rating { get; set; }
        public string Version { get; set; }

        public Game()
        {

        }

        public Game(DataRow row)
        {
            try
            {
                Id = (long)row[0];
            }
            catch
            {
                Id = 0;
            }
            try
            {
                Product_Id = (long)row[1];
            }
            catch
            {
                Product_Id = 0;
            }
            try
            {
                Rating = (double)row[2];
            }
            catch
            {
                Rating = 0;
            }
            Version = row[3].ToString();

            if (Product_Id > 0)
            {
                product = new Product(DatabaseManager.Select("Product", null, "Id = " + Product_Id + " ").Rows[0]);
            }
        }

        public Game(long Id) : this(DatabaseManager.Select("Game", null, "Id = " + Id + " ").Rows[0]) { }

        public bool Update()
        {
            DatabaseManager.DB_Field[] fields = new DatabaseManager.DB_Field[]
            {
                new DatabaseManager.DB_Field("Product_Id", Product_Id),
                new DatabaseManager.DB_Field("Rating", Rating),
                new DatabaseManager.DB_Field("Version", Version),
            };
            return DatabaseManager.Update("Game", fields, "Id = " + Id + " ") > 0 ? true : false;
        }

        public bool Add()
        {
            DatabaseManager.DB_Field[] fields = new DatabaseManager.DB_Field[]
            {
                new DatabaseManager.DB_Field("Product_Id", Product_Id),
                new DatabaseManager.DB_Field("Rating", Rating),
                new DatabaseManager.DB_Field("Version", Version),
            };
            return DatabaseManager.Insert("Game", fields) > 0 ? true : false;
        }

        public bool Remove()
        {
            return Remove(Id);
        }

        public static bool Remove(long id)
        {
            return DatabaseManager.Delete("Game", id) > 0 ? true : false;
        }
    }
}
