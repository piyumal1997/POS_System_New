using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PosSystem
{
    public partial class Admin_Form : Form
    {
        string Username;
        string Firstname;
        string JRole;
        public Admin_Form(String UN, String FN, String Role)
        {
            InitializeComponent();
            Dash_Admins au = new Dash_Admins();
            posUserControl(au);

            user.Text = FN;

            //Assign Passed Values
            Username = UN;
            Firstname = FN;
            JRole = Role;
        }

        private void posUserControl(UserControl userControl)
        {
            userControl.Dock= DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront(); 
        }

        private void AdminDash_Load(object sender, EventArgs e)
        {
            
        }

        private void addItem_Click(object sender, EventArgs e)
        {
            Item_Handle au = new Item_Handle();
            posUserControl(au);
        }

        private void summaryStatus_Click(object sender, EventArgs e)
        {
            Summary au = new Summary();
            posUserControl(au);
        }

        private void addUser_Click(object sender, EventArgs e)
        {
            Add_User au = new Add_User(JRole);
            posUserControl(au);
        }

        private void dashboard_Click(object sender, EventArgs e)
        {
            Dash_Admins au = new Dash_Admins();
            posUserControl(au);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Dash_Admins au = new Dash_Admins();
            posUserControl(au);
        }

        private void pos_Click(object sender, EventArgs e)
        {
            POS_Window f3 = new POS_Window(Username,JRole);
            f3.ShowDialog();
            Visible = true;
        }

        private void addCandB_Click(object sender, EventArgs e)
        {
            Brand_Category_Handler au = new Brand_Category_Handler();
            posUserControl(au);
        }

        private void addSupplier_Click(object sender, EventArgs e)
        {
            Supply_Handler au = new Supply_Handler(JRole);
            posUserControl(au);
        }

        private void barcodePrint_Click(object sender, EventArgs e)
        {
            Barcode_Handler au = new Barcode_Handler();
            posUserControl(au);
        }

        private void orders_Click(object sender, EventArgs e)
        {
            Inventory_Order au = new Inventory_Order(JRole);
            posUserControl(au);
        }

        private void viewInventory_Click(object sender, EventArgs e)
        {
            View_Inventory au = new View_Inventory();
            posUserControl(au);
        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void reportGen_Click(object sender, EventArgs e)
        {
            Report_Genorator au = new Report_Genorator();
            posUserControl(au);
        }

        private void logOut_Click(object sender, EventArgs e)
        {
            string message = $"Are you sure want logout the system?";
            string title = "Logout";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                loginForm f = new loginForm();
                f.Show();
                Visible = false;
            }
            else
            {
                //Do nothing
            }
        }
    }
}
