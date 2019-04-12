using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarFactoryService.Business_Logic;
using CarFactoryService.Service;
using System.Data.SqlTypes;
using System.Collections;
using System.Data;

namespace CarFactory
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            GetAllProduct();
           
        }

        public static List<Product> GetAllProduct()
        {
            List<Product> productList = new List<Product>();
            GetDataLogic product = new GetDataLogic();
            productList = product.GetAllProducts();
            return productList;
        }
    }
}
