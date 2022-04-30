using System;
using System.Data;

namespace M05_UF3_P2_Template.App_Code.Model
{
    public class Game : Product
    {
        public long Id { get; set; }
        public long Product_Id { get; set; }
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
                Fill(DatabaseManager.Select("Product", null, "Id = " + Product_Id + " ").Rows[0]);
            }
        }

        public Game(long Id) : this(DatabaseManager.Select("Game", null, "Id = " + Id + " ").Rows[0]) { }
    }
}
