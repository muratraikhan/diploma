using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;



using diplom.model;

namespace diplom
{
    /// <summary>
    /// Логика взаимодействия для createzayavka.xaml
    /// </summary>
    public partial class createzayavka : Window
    {
       
        public createzayavka()
        {

            InitializeComponent();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("category");
            dt.Columns.Add("naimenovaniye");
            dt.Columns.Add("servicecompany");
            dt.Columns.Add("description");
            dt.Columns.Add("garanty");
            DataRow dr = dt.NewRow();
           
            
            dt.Rows.Add(dr);
            datagrid1.ItemsSource = dt.DefaultView;
            fillcombo();

        }

       
        
        void fillcombo()
        {

            {

                SqlConnection con = new SqlConnection("Data Source=NOTE-AZAMAT;Initial Catalog=diplom;Integrated Security=True");


                try
                {
                    con.Open();
                    string sql = "select * from Category ";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    //cmd.ExecuteReader();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        string Category = dr.GetString(1);
                        categoryComboBox.Items.Add(Category);

                    }

                    con.Close();
                }


                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                try
                {
                    con.Open();
                    string sql = "select * from naimenovaniye ";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    //cmd.ExecuteReader();
                    SqlDataReader dn = cmd.ExecuteReader();
                    while (dn.Read())
                    {
                        string наименование = dn.GetString(1);
                        naimenovaniyeComboBox.Items.Add(наименование);

                    }

                    con.Close();
                }




                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


               

                try
                {
                    con.Open();
                    string sql = "select * from servicecompany ";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    //cmd.ExecuteReader();
                    SqlDataReader dn = cmd.ExecuteReader();
                    while (dn.Read())
                    {
                        string serviceName = dn.GetString(1);
                        servicecompanyComboBox.Items.Add(serviceName);

                    }

                    con.Close();
                }




                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                try
                {
                    con.Open();
                    string sql = "select * from garanty ";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    //cmd.ExecuteReader();
                    SqlDataReader dg = cmd.ExecuteReader();
                    while (dg.Read())
                    {
                        string garanty = dg.GetString(1);
                        garantyComboBox.Items.Add(garanty);

                    }

                    con.Close();
                }




                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }



        }
         


    

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataView dv = datagrid1.ItemsSource as DataView;
            DataTable dt = dv.Table;
            DataRow dr = dt.NewRow();
            dr["ID"] = numberTextBox.Text;
            dr["category"] = categoryComboBox.Text;
            dr["naimenovaniye"] = naimenovaniyeComboBox.Text;
            dr["servicecompany"] = servicecompanyComboBox.Text;
            dr["description"] = DescriptionTextBox.Text;
            dr["garanty"] = garantyComboBox.Text;
            dt.Rows.Add(dr);

            SqlConnection con = new SqlConnection("Data Source=NOTE-AZAMAT;Initial Catalog=diplom;Integrated Security=True");
            try
            {
                con.Open();
                string sql = "insert into remontzayavka (idRemont,category,naimenovaniye,servicecompany,descriptions,garantiya) values('" + this.numberTextBox.Text + "','" + categoryComboBox.Text + "','" + naimenovaniyeComboBox.Text + "','" + servicecompanyComboBox.Text + "','" + this.DescriptionTextBox.Text + "','" + garantyComboBox.Text + "')";
                SqlCommand cmd = new SqlCommand(sql, con);
                //cmd.ExecuteReader();
                cmd.ExecuteNonQuery();
                SqlDataReader dn = cmd.ExecuteReader();
                MessageBox.Show("Заявка на ремонт создана успешно");

                con.Close();
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nazad_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

      

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void servicecompanyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
    
}