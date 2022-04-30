using System;
using System.Data;

namespace M05_UF3_P2_Template.App_Code.Model
{
    public class Product
    {
        public enum TYPE { GAME, VIDEO }

        public long Id { get; set; }
        public TYPE Type { get; set; }
        public string Summary { get; set; }
        public string Icon { get; set; }
        public string Banner { get; set; }
        public string Trailer { get; set; }
        public double Price { get; set; }
        public DateTime Publishing { get; set; }
        public double Size { get; set; }
        public long Developer_Id { get; set; }
        public Company Developer { get; set; }
        public long Editor_Id { get; set; }
        public Company Editor { get; set; }
        
        

        public Product()
        {
            
        }

        public Product(DataRow row)
        {
            Fill(row);
        }

        public Product(long Id) : this(DatabaseManager.Select("Product", null, "Id = " + Id + " ").Rows[0]) { }

        public bool Update()
        {
            DatabaseManager.DB_Field[] fields = new DatabaseManager.DB_Field[]
            {
                new DatabaseManager.DB_Field("Type", (long)Type),
                new DatabaseManager.DB_Field("Summary", Summary),
                new DatabaseManager.DB_Field("Icon", Icon),
                new DatabaseManager.DB_Field("Banner", Banner),
                new DatabaseManager.DB_Field("Trailer", Trailer),
                new DatabaseManager.DB_Field("Price", Price),
                //new DatabaseManager.DB_Field("Publishing", Publishing),
                new DatabaseManager.DB_Field("Size", Size),
                new DatabaseManager.DB_Field("Developer", Developer_Id),
                new DatabaseManager.DB_Field("Editor", Editor_Id),
            };
            return DatabaseManager.Update("Product", fields, "Id = " + Id + " ") > 0 ? true : false;
        }

        public bool Add()
        {
            DatabaseManager.DB_Field[] fields = new DatabaseManager.DB_Field[]
            {
                new DatabaseManager.DB_Field("Type", (long)Type),
                new DatabaseManager.DB_Field("Summary", Summary),
                new DatabaseManager.DB_Field("Icon", Icon),
                new DatabaseManager.DB_Field("Banner", Banner),
                new DatabaseManager.DB_Field("Trailer", Trailer),
                new DatabaseManager.DB_Field("Price", Price),
                //new DatabaseManager.DB_Field("Publishing", Publishing),
                new DatabaseManager.DB_Field("Size", Size),
                new DatabaseManager.DB_Field("Developer", Developer_Id),
                new DatabaseManager.DB_Field("Editor", Editor_Id),
            };
            return DatabaseManager.Insert("Product", fields) > 0 ? true : false;
        }

        public void Fill(DataRow row)
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
                Type = (TYPE)(long)row[1];
            }
            catch (Exception e)
            {
                Type = TYPE.GAME;
            }
            Summary = row[2].ToString();
            Icon = row[3].ToString();
            Banner = row[4].ToString();
            Trailer = row[5].ToString();
            try
            {
                Price = (double)row[6];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Price = 0;
            }
            try
            {
                Publishing = DateTime.Parse(row[7].ToString());
            }
            catch
            {
                Publishing = DateTime.MinValue;
            }
            try
            {
                Size = (double)row[8];
            }
            catch
            {
                Size = 0;
            }
            try
            {
                Developer_Id = (long)row[9];
            }
            catch
            {
                Developer_Id = 0;
            }

            if (Developer_Id > 0) Developer = new Company(Developer_Id);

            try
            {
                Editor_Id = (long)row[10];
            }
            catch
            {
                Editor_Id = 0;
            }

            if (Editor_Id > 0) Editor = new Company(Editor_Id);
        }

        public bool Remove()
        {
            return Remove(Id);
        }

        public static bool Remove(long id)
        {
            return DatabaseManager.Delete("Product", id) > 0 ? true : false;
        }
    }
}
