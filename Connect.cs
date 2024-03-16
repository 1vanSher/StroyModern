using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace StroyModern
{
    public class Connect
    {
        public static DataSet ds = new DataSet();
        public static DataTable dt = new DataTable();
        public static NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Port=5432;Username=postgres;Password=123456;Database=mdb;");

        public static void BindData(string sql)
        {
            conn.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            conn.Close();
        }

        public static void ChangesData(string sql)
        {
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public static List<Product> ListData(string sql)
        {
            BindData(sql);
            List<Product> products = new List<Product>();

            for (int i = 0; i < dt.Rows.Count; i++) { 
                Product product = new Product();
                product.Id = Convert.ToInt32(dt.Rows[i][0]);
                product.Name_t = dt.Rows[i][1].ToString();
                product.Prise = Convert.ToDouble(dt.Rows[i][2]);
                product.Articul = dt.Rows[i][3].ToString();
                product.Photo = dt.Rows[i][4].ToString();
                product.Quantity = Convert.ToInt32(dt.Rows[i][5]);
                products.Add(product);
            }
            return products;
        }
    }
}
