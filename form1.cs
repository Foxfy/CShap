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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public DataClasses1DataContext db = new DataClasses1DataContext();

        public static User currenLogin;
        public static User userData;

        public void setProp(Control ctrl)
        {
            foreach(Control a in ctrl.Controls)
            {
                if (a is Button)
                {
                    Button bt = (Button)a;
                    bt.BackColor = ColorTranslator.FromHtml("#555555");
                    bt.ForeColor = Color.White;
                    if (bt.Text == "Exit" || bt.Text == "Delete" || bt.Text == "Cancel")
                    {
                        bt.BackColor = ColorTranslator.FromHtml("#e51a2e");
                        bt.ForeColor = Color.Black;
                    }
                }
                if (a is ComboBox)
                {
                    ComboBox cb = (ComboBox)a;
                    cb.DropDownStyle = ComboBoxStyle.DropDownList;
                }
                if (a is DataGridView)
                {
                    DataGridView dtg = (DataGridView)a;
                    dtg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dtg.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dtg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dtg.ForeColor = Color.Black;
                    dtg.MultiSelect = false;
                    dtg.RowHeadersVisible = false;
                    dtg.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
                    dtg.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
                    dtg.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#333333");
                    dtg.ColumnHeadersDefaultCellStyle.ForeColor = Color.Wheat;
                    dtg.EnableHeadersVisualStyles = false;
                }
                if (a is DateTimePicker)
                {
                    DateTimePicker dt = (DateTimePicker)a;
                    dt.Format = DateTimePickerFormat.Custom;
                    dt.CustomFormat = (" / / ");
                }
                if (a.HasChildren)
                {
                    setProp(a);
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.BackColor = ColorTranslator.FromHtml("#bbbbbb");
            panel1.ForeColor = ColorTranslator.FromHtml("#000000");
            setProp(panel1);
            panel1.Font = new Font("WSC2022SE_TP09_Gotham-Thin_actual_en", 15);
        }
    }
}
