using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        List<string> nameList;

        public Authorization()
        {
            InitializeComponent();
            try
            {
                authorization_userDataContext db = new authorization_userDataContext();
                var users = db.authorization_user.Where(d => d.isenabled == true);
                nameList = new List<string>(); 
                foreach (var items in users)   
                {
                    nameList.Add(items.login);
                }
            }

            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }

        }

        private void Login_Populating(object sender, PopulatingEventArgs e)
        {
            try
            {
                string txt = autText.Text;
                List<string> autolist = new List<string>();
                autolist.Clear();
                if (nameList !=null)
                { foreach(string item in nameList)
                        {
                        if (!string.IsNullOrEmpty(autText.Text) )
                        {
                            if (item.ToLower(StartsWith(txt.ToLower)))
                            {
                                autolist.Add(item);
                            }

                        }
                    }}


                autText.ItemsSource = autolist;
                autText.PopulateComplete();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
        }
    }
}

