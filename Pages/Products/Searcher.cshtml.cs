using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using M05_UF3_P2_Template.App_Code.Model;

namespace M05_UF3_P2_Template.Pages.Products
{
    public class SearcherModel : PageModel
    {
        public List<Product> products = new List<Product>();

        public void OnGet()
        {
            DataTable dt = DatabaseManager.Select("Product", new string[] { "*" }, "");
            foreach (DataRow dataRow in dt.Rows)
            {
                Product product = new Product(dataRow);

                if (product.Type == Product.TYPE.GAME)
                {
                    product = new Game(DatabaseManager.Select("Game", null, "Product_Id = " + product.Id + " ").Rows[0]);
                }

                products.Add(product);
            }
        }

        public void OnPostDelete(int id)
        {
            Product.Remove(id);
            OnGet();
        }
    }
}