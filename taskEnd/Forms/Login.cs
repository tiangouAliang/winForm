using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using taskEnd.Forms;
using taskEnd.BusinessRule;

namespace taskEnd
{
    public partial class Form_login : Form
    {

        string strConnection = "Server=localhost;UserId=root;Password= ;Database=cloudledger;pooling=false;CharSet=utf8;port=3306";
        
        
        
        
        public Form_login()
        {
            InitializeComponent();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            
            if (text_account.Text == "")
            {
                MessageBox.Show("请输入账号^v^");
                text_account.Focus();
                return;
            }
            else if (text_password.Text == "")
            {
                MessageBox.Show("请输入密码^v^");
                text_password.Focus();
                return;
            }
            MySqlConnection objConnection = new MySqlConnection(strConnection);
            objConnection.Open();
            MySqlCommand mySqlCommand = new MySqlCommand("select * from user_account where u_id='" + text_account.Text + "'", objConnection);//select * from 表名
            MySqlDataReader dataReader = mySqlCommand.ExecuteReader();
            if (dataReader.Read())
            {
                if (dataReader[1].ToString() != text_password.Text)
                {
                    MessageBox.Show("请输入正确的工号或密码^v^", "系统提示");
                }
                else
                {
                    //MessageBox.Show("欢迎使用营销管理系统!", "系统提示");
                    //打开主程序界面
                    Transmition.tans_user_id = text_account.Text;
                    Main f2 = new Main();
                    f2.ShowDialog();
                    this.Hide();
                    this.Dispose();
                }

            }
            else
            {
                MessageBox.Show("账号不存在^v^");
            }
            objConnection.Close();
            dataReader.Close();
        }

        private void button_more_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.baidu.com/");
        }

        private void label_forget_Click(object sender, EventArgs e)
        {
            PasswordAlter pa = new PasswordAlter();
            pa.ShowDialog();
            this.Dispose();
        }

        private void Form_login_Load(object sender, EventArgs e)
        {

        }
    }
}
