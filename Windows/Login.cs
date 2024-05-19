﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PosSystem
{
    public partial class loginForm : Form
    {
        Timer timer = null;

        public loginForm()
        {
            InitializeComponent();
            Connection conn = new Connection();
            conn.db_connect();
        }

        //Form Load
        private void Form1_Load(object sender, EventArgs e)
        {
            StartTimer(); //Timer Start
        }

        //Clear Button Click
        private void clear_Click(object sender, EventArgs e)
        {
            if (userName.Text == "" && password.Text == "")
            {
                //Do nothing
            }
            else
            {
                string message = "Are you sure want clear the inputs?";
                string title = "Clear";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    userName.Clear();
                    password.Clear();
                }
            }
        }

        //Close Button Click
        private void close_Click(object sender, EventArgs e)
        {
            string message = "Are you sure want close the application?";
            string title = "Close";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
                
        }

        private void login_Click(object sender, EventArgs e)
        {
            try
            {
                //DB Connection
                Connection conn = new Connection();
                conn.db_connect();

                SqlCommand cmd = new SqlCommand(); //SQL command reader
                
                string Username = userName.Text.Trim();
                string Password = password.Text.Trim();

                cmd.Connection = Connection.con;
                cmd.CommandText = "USE pos SELECT * FROM employee WHERE username = '" + userName.Text.Trim() + "' AND password = '" + password.Text.Trim() + "';";
                SqlDataReader read0 = cmd.ExecuteReader();
                read0.Read();
                if (read0.HasRows)
                {
                    string Status = read0["status"].ToString().Trim();
                    if (Status == "Active")
                    {
                        if (read0["role"].ToString().Trim() == "Owner")
                        {
                            Admin_Form f2 = new Admin_Form(read0["username"].ToString().Trim(), read0["firstname"].ToString().Trim(), read0["role"].ToString().Trim());
                            f2.Show();
                            Visible = false;
                        }
                        else
                        {
                            Cashier_Form f2 = new Cashier_Form(read0["username"].ToString().Trim(), read0["firstname"].ToString().Trim(), read0["role"].ToString().Trim());
                            f2.Show();
                            Visible = false;
                        }
                        
                    }
                    else
                    {
                        string Message = "Your account is dissabled!";
                        string warning = "Warning";
                        MessageBox.Show(Message, warning);

                        //Clear Inpute
                        userName.Clear();
                        password.Clear();
                    }
                }
                else
                {
                    string Message = "Username or Password is Incorrect, Please try agin!";
                    string warning = "Warning";
                    MessageBox.Show(Message, warning);

                    //Clear Inpute
                    userName.Clear();
                    password.Clear();
                }
                read0.Close();

                conn.db_connect_close();//DB Connection Close
            }
            catch(Exception ex)
            {
                string errorMessage = ex.Message;
                string error = "Error";
                MessageBox.Show(errorMessage, error);
            }
        }
        
        //Timer
        private void StartTimer()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Enabled = true;
        }

        //Show Time
        void timer_Tick(object sender, EventArgs e)
        {
            todayDateView.Text = DateTime.Now.ToString();
        }

    }
}
