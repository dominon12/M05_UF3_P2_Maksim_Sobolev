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
        public float Price { get; set; }
        public DateTime Publishing { get; set; }
        public float Size { get; set; }
        public long Developer { get; set; }
        public long Editor { get; set; }

        public Product()
        {
            
        }

        public Product(DataRow row)
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
                Type = (TYPE)(int)row[1];
            }
            catch
            {
                Type = TYPE.GAME;
            }
            Summary = row[2].ToString();
            Icon = row[3].ToString();
            Banner = row[4].ToString();
            Trailer = row[5].ToString();
            try
            {
                Price = (float)row[6];
            }
            catch
            {
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
                Size = (float)row[8];
            }
            catch
            {
                Size = 0;
            }
            try
            {
                Developer = (long)row[9];
            }
            catch
            {
                Developer = 0;
            }
            try
            {
                Editor = (long)row[10];
            }
            catch
            {
                Editor = 0;
            }
        }
    }
}
