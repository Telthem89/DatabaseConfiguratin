using DatabaseConfig.DatabaseDll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseConfig
{
    public partial class DatabasConfigwiz : Form
    {
        public DatabasConfigwiz()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var pass=txtPass.Text;
            string connectionString = "";
            if (pass == "")
            {
                connectionString = "server='"+ txtServer.Text + "';user='" + txtUser.Text + "';password='" + txtPass.Text + "';database='" + txtDbName.Text + "';SSL Mode=None";
            }
            else
            {
                connectionString = "server='" + txtServer.Text + "';user='" + txtUser.Text + "';password='" + txtPass.Text + "';database='" + txtDbName.Text + "';SSL Mode=None";
            }
            try
            {
                SqlHelper helper = new SqlHelper(connectionString);
                if (helper.IsConnection)
                    MessageBox.Show("Test connection succeeded.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveCon_Click(object sender, EventArgs e)
        {
            //Set connection string
            var pass = txtPass.Text;
            string connectionString = "";
            if (pass == "")
            {
                connectionString = "server='" + txtServer.Text + "';user='" + txtUser.Text + "';password='" + txtPass.Text + "';database='" + txtDbName.Text + "';SSL Mode=None";
            }
            else
            {
                connectionString = "server='" + txtServer.Text + "';user='" + txtUser.Text + "';password='" + txtPass.Text + "';database='" + txtDbName.Text + "';SSL Mode=None";
            }
            try
            {
                SqlHelper helper = new SqlHelper(connectionString);
                if (helper.IsConnection)
                {
                    DatabaseConfigApp setting = new DatabaseConfigApp();
                    setting.SaveConnectionString("cn", connectionString);
                    MessageBox.Show("Your connection string has been successfully saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGetStrng_Click(object sender, EventArgs e)
        {
            DatabaseConfigApp setting = new DatabaseConfigApp();
            var m = setting.GetConnectionString("cn");
            MessageBox.Show(m, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
