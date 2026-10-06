using System;
using System.Windows.Forms;
using OrderDetailsMaintenance.Models.DataLayer;


namespace OrderDetailsMaintenance
{
    public partial class frmCustomerMaintenance : Form
    {
        private NorthwindContext context = new NorthwindContext();

        // Marley Chilenski
        public frmCustomerMaintenance()
        {
            InitializeComponent();
        }

        // Marley Chilenski
        private void btnFind_Click(object sender, EventArgs e)
        {
            string customerId = txtCustomerId.Text;

            var customer = context.Customers.Find(customerId);

            if (customer != null)
            {
                txtContact.Text = customer.ContactName;
                txtAddress.Text = customer.Address;
                txtCity.Text = customer.City;
                txtCountry.Text = customer.Country;
            }
            else
            {
                MessageBox.Show("Customer not found.");
            }
        }

        // Marley Chilenski
        private void btnSave_Click(object sender, EventArgs e)
        {
            int customerId = int.Parse(txtCustomerId.Text);

            var customer = context.Customers.Find(customerId);

            if (customer != null)
            {
                customer.ContactName = txtContact.Text;
                customer.Address = txtAddress.Text;
                customer.City = txtCity.Text;
                customer.Country = txtCountry.Text;

                context.SaveChanges();

                MessageBox.Show("Customer saved.");
            }
            else
            {
                MessageBox.Show("Customer not found.");
            }
        }
    }
}