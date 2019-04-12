using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarFactoryService.Business_Logic;
using CarFactoryService.Service;

namespace CarFactory
{
    public partial class Form1 : Form
    {
        GetDataLogic logic = new GetDataLogic();
        public Form1()
        {
            InitializeComponent();
        }

        public void LoadComboBox()
        {
            cmbEducation.DataSource = logic.GetAllEducation();
            cmbEducation.ValueMember = "IdEducation";
            cmbEducation.DisplayMember = "Name";
            

            cmbJobTitle.DataSource = logic.GetAllOccupation();
            cmbJobTitle.ValueMember = "IdOccupation";
            cmbJobTitle.DisplayMember = "Description";

            cmbSuburb.DataSource = logic.GetAllSuburbs();
            cmbSuburb.ValueMember = "IdSuburb";
            cmbSuburb.DisplayMember = "Name";

            cmbProName.DataSource = logic.GetAllProducts();
            cmbProName.ValueMember = "IdProduct";
            cmbProName.DisplayMember = "Name";

            cmbOrderCust.DataSource = logic.GetAllCustomers();
            cmbOrderCust.ValueMember = "IdCustomer";
            cmbOrderCust.DisplayMember = "Name";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveCustomer();
            string value = "customers";

            ClearTextBoxes(value);
            LoadCustomers();
        }

        public void LoadCustomers()
        {
            List<Customer> customerList = new List<Customer>();
           

          
           customerList = logic.GetAllCustomers();

            var query = (from c in customerList
                        select new { c.IdCustomer, c.Name, 
                                     c.Address,c.PostalCode,
                                     c.Phone, c.JobTitle, c.Qualification,
                                     c.SuburbName}).ToList();
            
            GridCustomers.DataSource = query;
            GridCustomers.Columns["IdCustomer"].DisplayIndex = 0;
        }

        public void LoadProducts()
        {
            List<Product> productList = new List<Product>(); 
            
           productList = logic.GetAllProducts();

           GridViewProduct.DataSource = productList;
           GridViewProduct.Columns["IdProduct"].DisplayIndex = 0;
     
        }

        public void LoadOrders()
        {
            List<Order> orderList = new List<Order>();
            orderList = logic.GetAllOrders();
            var query = (from c in orderList
                         select new {c.IdOrder,c.CustomerName, c.Quantity, c.ProductName, c.OrderDate }).ToList();

            
            GridViewOrders.DataSource = query;
            GridViewOrders.Columns["IdOrder"].DisplayIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            LoadProducts();
            LoadCustomers();
            LoadOrders();
        }

        private void GridCustomers_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int id = Convert.ToInt32(GridCustomers.CurrentRow.Cells["IdCustomer"].Value);
            Customer customer = logic.GetCustomerById(id);

            txtId.Text = customer.IdCustomer.ToString();
            txtName.Text = customer.Name.ToString();
            txtAddress.Text = customer.Address.ToString();
            txtPostal.Text = customer.PostalCode.ToString();
            txtPhone.Text = customer.Phone.ToString();
        }

        private void GridViewProduct_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            int id = Convert.ToInt32(GridViewProduct.CurrentRow.Cells["IdProduct"].Value);
            Product product = logic.GetProductById(id);
            txtProductId.Text = product.IdProduct.ToString();
            txtProductName.Text = product.Name;
            txtPrice.Text = product.Price.ToString();

        }

        private void GridViewOrders_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int id = Convert.ToInt32(GridViewOrders.CurrentRow.Cells["IdOrder"].Value);
            Order order = logic.GetOrderById(id);
            txtIdOrder.Text = order.IdOrder.ToString();
            cmbProName.Text =  order.ProductName.ToString();
            txtQty.Text = order.Quantity.ToString();
            cmbOrderCust.Text = order.CustomerName.ToString();

        }
        public void ClearTextBoxes(string value)
        {
            switch(value)
            {
                case "products":
                    {
                        txtProductId.Text = "";
                        txtProductName.Text = "";
                        txtPrice.Text = "";
                        break;
                    }
                case "customers":
                    {
                        txtName.Text = "";
                        txtAddress.Text = "";
                        txtPhone.Text = "";
                        txtPostal.Text = "";
                        break;
                    }
                case "orders":
                    {
                        txtQty.Text = "";
                        txtIdOrder.Text = "";
                    }
                    break;
                default:
                break;
            }
        }


        public void EnabledTextBoxes2(bool setting)
        {
            foreach (Control txt in groupBox2.Controls)
            {
                if (txt is TextBox)
                {
                    txt.Enabled = setting;
                }
            }
        }

        private void btnSave1_Click(object sender, EventArgs e)
        {
            SaveProduct();
            string value = "products";
            ClearTextBoxes(value);
            LoadProducts();
        }

        public void SaveProduct()
        {
            Product product = new Product();
            product.Name = txtProductName.Text;
            product.Price = Convert.ToDouble(txtPrice.Text);

            logic.SaveProduct(product);

        }

        public void SaveCustomer()
        {
            Customer customer = new Customer();
            customer.Name = txtName.Text;
            customer.PostalCode = txtPostal.Text;
            customer.Phone = txtPhone.Text;
            customer.Address = txtAddress.Text;
            customer.IdOccupation = Convert.ToInt32(cmbJobTitle.SelectedValue);
            customer.IdEducation = Convert.ToInt32(cmbEducation.SelectedValue);
            customer.IdSuburb = Convert.ToInt32(cmbSuburb.SelectedValue);

            {
                Occupation occupation = new Occupation();
                occupation.Description = cmbJobTitle.Text;

                Education education = new Education();
                education.Name = cmbEducation.Text;

                Suburb suburb = new Suburb();
                suburb.Name = cmbSuburb.Text;

                customer.educ = education;
                customer.oc = occupation;
                customer.sub = suburb;
            }

        
            logic.SaveCustomer(customer);

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateProduct();
            string value = "products";
            ClearTextBoxes(value);
            LoadProducts();
        }

        public void UpdateProduct()
        {
            Product product = new Product();
            product.IdProduct = Convert.ToInt32(txtProductId.Text);
            product.Name = txtProductName.Text;
            product.Price = Convert.ToDouble(txtPrice.Text);

            logic.UpdateProduct(product);
        }

        private void btnUpdate1_Click(object sender, EventArgs e)
        {
            UpdateCustomer();
            string value = "customers";

            ClearTextBoxes(value);
            LoadCustomers();
        }

        public void UpdateCustomer()
        {
            Customer customer = new Customer();
            customer.IdCustomer = Convert.ToInt32(txtId.Text);
            customer.Name = txtName.Text;
            customer.PostalCode = txtPostal.Text;
            customer.Phone = txtPhone.Text;
            customer.Address = txtAddress.Text;
            customer.IdOccupation = Convert.ToInt32(cmbJobTitle.SelectedValue);
            customer.IdEducation = Convert.ToInt32(cmbEducation.SelectedValue);
            customer.IdSuburb = Convert.ToInt32(cmbSuburb.SelectedValue);

            {
                Occupation occupation = new Occupation();
                occupation.Description = cmbJobTitle.Text;

                Education education = new Education();
                education.Name = cmbEducation.Text;

                Suburb suburb = new Suburb();
                suburb.Name = cmbSuburb.Text;

                customer.educ = education;
                customer.oc = occupation;
                customer.sub = suburb;
            }


            logic.UpdateCustomer(customer);
        }

        private void btnSave3_Click(object sender, EventArgs e)
        {
            SaveOrders();
            string value = "orders";
            ClearTextBoxes(value);
            LoadOrders();

        }

        public void SaveOrders()
        {
            Order order = new Order();
            order.IdCustomer = Convert.ToInt32(cmbOrderCust.SelectedValue);
            order.IdProduct = Convert.ToInt32(cmbProName.SelectedValue);
            order.Quantity = Convert.ToInt32(txtQty.Text);
            order.OrderDate = DateTime.Now;

            {
                Customer customer = new Customer();
                customer.Name = cmbOrderCust.Text;

                Product product = new Product();
                product.Name = cmbProName.Text;

                order.customer = customer;

                order.product = product;

            }

            logic.SaveOrder(order);
        }

        public void UpdateOrders()
        {
            Order order = new Order();
            order.IdOrder = Convert.ToInt32(txtIdOrder.Text);
            order.IdCustomer = Convert.ToInt32(cmbOrderCust.SelectedValue);
            order.IdProduct = Convert.ToInt32(cmbProName.SelectedValue);
            order.Quantity = Convert.ToInt32(txtQty.Text);
            order.OrderDate = DateTime.Now;

            {
                Customer customer = new Customer();
                customer.Name = cmbOrderCust.Text;

                Product product = new Product();
                product.Name = cmbProName.Text;

                order.customer = customer;

                order.product = product;

            }

            logic.UpdateOrder(order);

        }

        private void btnUpdate2_Click(object sender, EventArgs e)
        {
            UpdateOrders();
            string value = "orders";
            ClearTextBoxes(value);
            LoadOrders();
        }

      
    }
}
