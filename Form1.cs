namespace StroyModern
{
    public partial class Form1 : Form
    {
        int currentpage = 1;
        public Form1()
        {
            InitializeComponent();
            productToUser();
            label4.Text = MaxPage(allproducts.Count).ToString();
            label2.Text = currentpage.ToString();
            comboBox1.Items.AddRange(new string[] { "По алфавиту", "Против алфавита" });
        }
        static string sqlCommand = "SELECT * FROM tovar";
        public List<Product> allproducts = Connect.ListData(sqlCommand);


        private void label1_Click(object sender, EventArgs e)
        {
            if (currentpage == 1)
            {
                currentpage = MaxPage(allproducts.Count);
                label2.Text = currentpage.ToString();
            }
            else
            {
                currentpage--;
                label2.Text = currentpage.ToString();
            }
            productToUser();
        }

        private void label5_Click(object sender, EventArgs e)
        {

            int maxpage = MaxPage(allproducts.Count);
            if (currentpage == maxpage)
            {
                currentpage = 1;
                label2.Text = currentpage.ToString();
            }
            else
            {
                currentpage++;
                label2.Text = currentpage.ToString();
            }
            productToUser();
        }

        public int MaxPage(int page)
        {
            int maxpage;
            if (page % 5 == 0)
            {
                maxpage = page / 5;
            }
            maxpage = page / 5 + 1;
            return maxpage;
        }

        public void productToUser()
        {
            flowLayoutPanel1.Controls.Clear();
            allproducts = Connect.ListData(sqlCommand);
            int iEnd = 5;
            int maxpage = MaxPage(allproducts.Count);
            if (currentpage == maxpage)
            {
                iEnd = allproducts.Count % 5;
            }
            for (int i = 0 + 5 * (currentpage - 1); i < iEnd + 5 * (currentpage - 1); i++)
            {
                UserControl1 uc = new UserControl1();
                uc.Size = new Size(431, 127);
                uc.product = allproducts[i];
                uc.label1.Text = allproducts[i].Articul.ToString();
                uc.label2.Text = allproducts[i].Name_t.ToString();
                uc.label3.Text = allproducts[i].Prise.ToString();
                flowLayoutPanel1.Controls.Add(uc);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        public void Search()
        {
            string main = "SELECT * FROM tovar";
            bool where = false;
            string searchLetters = "";
            string sortType = "";
            string result = "";

            if (textBox1.Text.Trim(' ') != "")
            {
                searchLetters = $" name_t ILIKE '%{textBox1.Text}%'";
                where = true;
            }

            switch (comboBox1.SelectedIndex)
            {
                case -1:
                    sortType = "";
                    break;
                case 0:
                    sortType = " ORDER BY name_t ASC";
                    break;
                case 1:
                    sortType = " ORDER BY name_t DESC";
                    break;
            }


            if (where)
            {
                result = $"{main} WHERE {searchLetters} {sortType}";
            }
            else
            {
                result = $"{main} {sortType}";
            }

            sqlCommand = result;
            productToUser();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search(); 
        }
    }
}
