using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace session1
{
    public partial class Logins : Form1
    {
        public Logins()
        {
            InitializeComponent();

            if (Properties.Settings.Default.currenUser != "")
            {
                currenLogin = db.Users.Where(x => x.GUID == Guid.Parse(Properties.Settings.Default.currenUser)).FirstOrDefault();
                    
                if (Properties.Settings.Default.dataUser != "")
                {
                    userData = db.Users.Where(x => x.GUID == Guid.Parse(Properties.Settings.Default.dataUser)).FirstOrDefault();
                }

                if (currenLogin != null)
                {
                    new MainForm().Show();
                    Hide();
                    
                    
                }
            }
        }

        private void Logins_Load(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            //แสดงรหัสผ่าน
            textBox3.UseSystemPasswordChar = checkBox2.Checked ? false : true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //เช็คช่องข้อความ
            if(textBox2.Text == "")
            {
                MessageBox.Show("Please enter Username");
                return;
            }
            if(textBox3.Text == "")
            {
                MessageBox.Show("Please enter Passwoed");
                return;
            }
            if(textBox1.Text == textBox2.Text)
            {
                MessageBox.Show("Can't found Username same feild Employee");
                return;
            }

            if(textBox1.Text != "")
            {
                //Employee
                currenLogin = db.Users.Where(x => x.Username == textBox1.Text && x.Password == textBox3.Text).FirstOrDefault();
                userData = db.Users.Where(x => x.Username == textBox2.Text).FirstOrDefault();
            }
            else
            {
                //User
                currenLogin = db.Users.Where(x => x.Username == textBox2.Text && x.Password == textBox3.Text).FirstOrDefault();
            }
            if(currenLogin != null)
            {
                if (textBox1.Text != "")
                {
                    if(userData == null)
                    {
                        MessageBox.Show("Can't found Username Detail");
                        return;
                    }
                }

                new MainForm().Show();
                if (checkBox1.Checked)
                {
                    if(currenLogin.UserTypeID == 1)
                    {
                        Properties.Settings.Default.currenUser = currenLogin.GUID.ToString();
                        Properties.Settings.Default.dataUser = userData.GUID.ToString();
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        Properties.Settings.Default.currenUser = currenLogin.GUID.ToString();
                        Properties.Settings.Default.Save();
                    }
                }

                else
                {
                    Properties.Settings.Default.currenUser = "";
                    Properties.Settings.Default.dataUser = "";
                    Properties.Settings.Default.Save();
                }
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                Hide();

            }


        }

        private void Logins_Shown(object sender, EventArgs e)
        {
            foreach (Control a in Application.OpenForms)
            {
                if (a.Name == "MainForm")
                {
                    Hide();
                }
            }
        }
    }
}
