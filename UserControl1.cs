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
    public partial class UserControl1 : UserControl
    {
        public Product product;
        public UserControl1()
        {
            InitializeComponent();
        }

        private void UserControl1_DoubleClick(object sender, EventArgs e)
        {
            UserControl1 userControl1 = sender as UserControl1;
            Form2 form2 = new Form2(userControl1,(Form1)userControl1.Parent.Parent);
            form2.ShowDialog();
        }
    }
}
