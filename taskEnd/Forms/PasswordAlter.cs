using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace taskEnd.Forms
{
    public partial class PasswordAlter : Form
    {
        public PasswordAlter()
        {
            InitializeComponent();
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            Form_login login = new Form_login();
            login.ShowDialog();
            this.Dispose();

        }

        private void button_verify_next_Click(object sender, EventArgs e)
        {

        }

        


        
        private void button_exit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void text_verification_TextChanged(object sender, EventArgs e)
        {
            if (text_verification.Text != "")
            {
                button_send_verify.Text = "Verification";
            }
            else
            {
                button_send_verify.Text = "Send Message";
            }
        }
    }
}
