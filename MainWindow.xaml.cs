using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


using diplom.model;

namespace diplom
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
           
            InitializeComponent();
          
            fill_listbox();

        }
        void fill_listbox() {

            SqlConnection con = new SqlConnection("Data Source=NOTE-AZAMAT;Initial Catalog=diplom;Integrated Security=True");


            try
            {
                con.Open();
                string sql = "select * from remontzayavka ";
                SqlCommand cmd = new SqlCommand(sql, con);
                //cmd.ExecuteReader();
                SqlDataReader dbr = cmd.ExecuteReader();
                while (dbr.Read())
                {
                    
                    string ID = dbr.GetString(0);
                    string descriptions = dbr.GetString(4);
                    remontListBox.Items.Add(ID);
                    remontListBox.Items.Add(descriptions);

                }

                con.Close();
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
     
        }
      

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            spravochnic spr = new spravochnic();
            spr.Show();
            this.Close();

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

            sotrudniki sotr = new sotrudniki();
            sotr.Show();
            this.Close();
        }


        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            utilizaciya uti = new utilizaciya();
            uti.Show();
            this.Close();

        }
        
        private void sozdremont_Click_4(object sender, RoutedEventArgs e)
        {
            createzayavka cz = new createzayavka();
            cz.Show();
            this.Close();
        }

        private void remont_Click_4(object sender, RoutedEventArgs e)
        {
            createzayavka cz = new createzayavka();
            cz.Show();
            this.Close();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            remont re = new remont();
            re.Show();
            this.Close();
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            vydacha vy = new vydacha();
            vy.Show();
            
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            EdinSotrudnik re = new EdinSotrudnik();
            re.Show();
            
        }

        private void ListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            vydacha vy = new vydacha();
            vy.Show();
            this.Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            priemka re = new priemka();
            re.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {


            newsotrudnik ns =  new newsotrudnik();
            ns.Show();
            this.Close();
        }
    }
}