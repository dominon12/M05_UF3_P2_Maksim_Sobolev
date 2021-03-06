using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using M05_UF3_P2_Template.App_Code.Model;

namespace M05_UF3_P2_Template.Pages.Products
{
    public class ProductModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public long Id { get; set; }
        public long Game_Id { get; set; }
        public long Video_Id { get; set; }
        [BindProperty]
        public Product product { get; set; }

        public void OnGet()
        {
            if (Id > 0)
            {
                product = new Product(Id);

                if (product.Type == Product.TYPE.GAME)
                {
                    DataRowCollection dataRows = DatabaseManager.Select("Game", new string[] { "Id" }, "Product_Id = " + Id + " ").Rows;
                    if (dataRows.Count > 0)
                    {
                        Game_Id = (long)dataRows[0][0];
                    }
                }
                else if (product.Type == Product.TYPE.VIDEO)
                {
                    DataRowCollection dataRows = DatabaseManager.Select("Video", new string[] { "Id" }, "Product_Id = " + Id + " ").Rows;
                    if (dataRows.Count > 0)
                    {
                        Video_Id = (long)dataRows[0][0];
                    }
                }
            }
        }

        public void OnPost()
        {
            product.Id = Id;
            if (Id > 0)
            {
                product.Update();
            }
            else
            {
                product.Add();
                Id = (long)DatabaseManager.Scalar("Product", DatabaseManager.SCALAR_TYPE.MAX, new string[] { "Id" }, "");
                OnGet();
            }
        }
    }
}