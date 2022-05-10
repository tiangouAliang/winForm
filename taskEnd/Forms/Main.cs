using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime;
using taskEnd.UControl;
using taskEnd.BusinessRule;
using taskEnd.DataAcess;

namespace taskEnd
{
    public partial class Main : Form
    {
        string get_u_id = Transmition.tans_user_id;
        
        
        int PanelWidth;
        bool isCopollapsed;

        public Main()
        {
            InitializeComponent();


            PanelWidth = panel_left.Width;
            isCopollapsed = false;
            timerTimer.Start();
            UC_Home uc = new UC_Home();
            


            
        }

        private void AddControlsToPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panel_home.Controls.Clear();
            panel_home.Controls.Add(c);

        }























        private void button_exit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void timerTimer_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            label_time.Text = dt.ToString("HH:mm:ss");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCopollapsed)
            {
                panel_left.Width = panel_left.Width + 10;
                if(panel_left.Width >= PanelWidth)
                {
                    timer1.Stop();
                    isCopollapsed = false;
                    this.Refresh();

                }
            }
            else
            {
                panel_left.Width = panel_left.Width - 10;
                if(panel_left.Width <= 65)
                {
                    timer1.Stop();
                    isCopollapsed = true;
                    this.Refresh();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        public void moverSlidePanel(Control btn)
        {
            panelSlide.Top = btn.Top;
            panelSlide.Height = btn.Height;

        }

       

        

        
        private void Main_Load(object sender, EventArgs e)
        {
            timerTimer.Start();
            string userid = Transmition.tans_user_id;
            string connection = Transmition.connnectionStr;
            
            DBConnection nickname = new DBConnection(connection);
            string name = "Noble Senior :"+nickname.get_Nickname(userid,connection);
            label_role.Text = name;
            UC_Home uc = new UC_Home();
            AddControlsToPanel(uc);
        }

        private void button_home_Click(object sender, EventArgs e)
        {
            moverSlidePanel(button_home);
            UC_Home uc = new UC_Home();
            AddControlsToPanel(uc);
        }

        private void button_query_Click(object sender, EventArgs e)
        {
            moverSlidePanel(button_query);
            UC_Query uc = new UC_Query();
            AddControlsToPanel(uc);
        }

        private void button_alter_Click(object sender, EventArgs e)
        {
            moverSlidePanel(button_alter);
            UC_Alter uc = new UC_Alter();
            AddControlsToPanel(uc);
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            moverSlidePanel(button_delete);
            UC_Delete uc = new UC_Delete();
            AddControlsToPanel(uc);
        }

        private void button_addition_Click(object sender, EventArgs e)
        {
            moverSlidePanel(button_addition);
            UC_Addition uc = new UC_Addition();
            AddControlsToPanel(uc);
        }

        private void panel_home_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_Alaccount_Click(object sender, EventArgs e)
        {
            moverSlidePanel(button_Alaccount);
            UC_Account uc = new UC_Account();
            AddControlsToPanel(uc);
            
        }
    }
}
