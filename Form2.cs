using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StroyModern
{
    public partial class Form2 : Form
    {
        UserControl1 usc;
        Form1 form1;
        public Form2(UserControl1 usc, Form1 form1)
        {
            InitializeComponent();
            this.usc = usc;
            this.form1 = form1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Insert")
            {
                textBox2.ReadOnly = false;
                textBox2.Enabled = true;
                textBox3.ReadOnly = false;
                textBox3.Enabled = true;
                textBox4.ReadOnly = false;
                textBox4.Enabled = true;
                textBox5.ReadOnly = false;
                textBox5.Enabled = true;
                textBox6.ReadOnly = false;
                textBox6.Enabled = true;
            }
            if (comboBox1.SelectedItem.ToString() == "Update")
            {
                textBox1.Text = usc.product.Id.ToString();
                textBox1.ReadOnly = false;
                textBox1.Enabled = true;
                textBox2.Text = usc.product.Name_t.ToString();
                textBox2.ReadOnly = false;
                textBox2.Enabled = true;
                textBox3.Text = usc.product.Prise.ToString();
                textBox3.ReadOnly = false;
                textBox3.Enabled = true;
                textBox4.Text = usc.product.Articul.ToString();
                textBox4.ReadOnly = false;
                textBox4.Enabled = true;
                textBox5.Text = usc.product.Photo.ToString();
                textBox5.ReadOnly = false;
                textBox5.Enabled = true;
                textBox6.Text = usc.product.Quantity.ToString();
                textBox6.ReadOnly = false;
                textBox6.Enabled = true;
            }
            if (comboBox1.SelectedItem.ToString() == "Delete")
            {
                textBox1.Text = usc.product.Id.ToString();
            }
        }

        public void button2_Click(object sender, EventArgs e)
        {
            string sql = string.Empty;
            if (comboBox1.SelectedItem.ToString() == "Insert")
            {
                sql = $"INSERT INTO tovar(name_t, prise, articul, photo, quantity) VALUES ('{textBox2.Text}', '{textBox3.Text}', '{textBox4.Text}', '{textBox5.Text}', '{textBox6.Text}');";
                label7.Text = sql ;
            }
            if (comboBox1.SelectedItem.ToString() == "Update")
            {
                sql = $"UPDATE tovar SET name_t='{textBox2.Text}', prise={Convert.ToDouble(textBox3.Text)}, articul='{textBox4.Text}', photo='{textBox5.Text}', quantity={Convert.ToInt32(textBox6.Text)} WHERE id = {Convert.ToInt32(textBox1.Text)};";
            }
            if (comboBox1.SelectedItem.ToString() == "Delete")
            {
                sql = $"DELETE FROM tovar WHERE id = {textBox1.Text};";
            }
            Connect.ChangesData(sql);
            form1.productToUser();
            this.Close();
        }
    }
}
