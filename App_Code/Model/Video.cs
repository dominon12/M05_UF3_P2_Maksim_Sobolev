using System;
using System.Data;

namespace M05_UF3_P2_Template.App_Code.Model
{
    public class Video
    {
        public long Id { get; set; }
        public long Product_Id { get; set; }
        public Product product { get; set; }
        public double Duration { get; set; }

        public Video()
        {

        }

        public Video(DataRow row)
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
                Duration = (double)row[2];
            }
            catch
            {
                Duration = 0;
            }

            if (Product_Id > 0)
            {
                product = new Product(DatabaseManager.Select("Product", null, "Id = " + Product_Id + " ").Rows[0]);
            }
        }

        public Video(long Id) : this(DatabaseManager.Select("Video", null, "Id = " + Id + " ").Rows[0]) { }

        public bool Update()
        {
            DatabaseManager.DB_Field[] fields = new DatabaseManager.DB_Field[]
            {
                new DatabaseManager.DB_Field("Product_Id", Product_Id),
                new DatabaseManager.DB_Field("Duration", Duration),
            };
            return DatabaseManager.Update("Video", fields, "Id = " + Id + " ") > 0 ? true : false;
        }

        public bool Add()
        {
            DatabaseManager.DB_Field[] fields = new DatabaseManager.DB_Field[]
            {
                new DatabaseManager.DB_Field("Product_Id", Product_Id),
                new DatabaseManager.DB_Field("Duration", Duration),
            };
            return DatabaseManager.Insert("Video", fields) > 0 ? true : false;
        }

        public bool Remove()
        {
            return Remove(Id);
        }

        public static bool Remove(long id)
        {
            return DatabaseManager.Delete("Video", id) > 0 ? true : false;
        }
    }
}
