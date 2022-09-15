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
using System.Data.SqlClient;

namespace Airlines_App
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public void Clear()
        {
            txt_email.Clear();
            txt_fullname.Clear();
            txt_phonenumber.Clear();
            txt_username.Clear();
            p_password.Clear();
            p_confirmpassword.Clear();
        }
        public Register()
        {
            InitializeComponent();
        }

        string gender = "";

        string conString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Airlines_App;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            Login login1 = new Login();
            this.Visibility = Visibility.Collapsed;
            login1.Show();
        }

        private void lb_register_Click(object sender, RoutedEventArgs e)
        {
           
                if (txt_username.Text == String.Empty)
                {
                    txt_username.Focus();
                    MessageBox.Show("fill the username  fields");
                    return;
                }
                else if (string.IsNullOrEmpty(txt_fullname.Text.Trim()))

                {

                    MessageBox.Show("fill the full name  fields");

                    txt_fullname.Text = String.Empty;

                    return;

                }

                else if (txt_fullname.Text.StartsWith("."))

                {

                    MessageBox.Show("Value can not start with .");

                    txt_fullname.Text = String.Empty;

                    return;

                }

                else if (txt_fullname.Text.StartsWith(" "))

                {

                    MessageBox.Show(" Value can not start with blank space");

                    txt_fullname.Text = String.Empty;

                    return;

                }


                else if (System.Text.RegularExpressions.Regex.IsMatch(txt_fullname.Text, "[^a-z A-z]"))
                {
                    txt_fullname.Focus();
                    MessageBox.Show("fill the names only in fullname fields");
                    return;
                }
                else if (txt_email.Text.StartsWith(" "))

                {

                    MessageBox.Show(" Value can not start with blank space");

                    txt_fullname.Text = String.Empty;

                    return;

                }
                else if (txt_email.Text == String.Empty)
                {
                    txt_email.Focus();
                    MessageBox.Show("fill the email  fields");
                    return;
                }

                else if (txt_phonenumber.Text == String.Empty)
                {
                    txt_phonenumber.Focus();
                    MessageBox.Show("fill the phonenumber fields");
                    return;
                }
                else if (System.Text.RegularExpressions.Regex.IsMatch(txt_phonenumber.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please enter only numbers in phonenumber fields.");
                    txt_phonenumber.Text = String.Empty;

                    txt_phonenumber.Focus();
                    return;
                }
                else if (txt_phonenumber.Text.Length != 10)
                {
                    txt_phonenumber.Focus();
                    MessageBox.Show("phonenumber must be 10 digits");
                    return;
                }
                else if ((rdo_female.IsChecked == false) && (rdo_male.IsChecked == false) && (rdo_prefernotosay.IsChecked == false))
                {
                    rdo_female.Focus();
                    MessageBox.Show("select the gender  fields");
                    return;


                }
                else if (p_password.Password.ToString() == String.Empty)
                {
                    p_password.Focus();
                    MessageBox.Show("fill the password fields");
                    return;
                }
                else if (p_password.Password.Length < 6)
                {
                    p_password.Focus();
                    MessageBox.Show(" password must be more than 5 letters");
                    return;

                }
           
            else if (p_confirmpassword.Password.ToString() == String.Empty)
            {
                p_confirmpassword.Focus();
                MessageBox.Show("fill the confirm passwrod  fields");
                return;
            }

            else if (p_confirmpassword.Password != p_password.Password)
            {
                p_confirmpassword.Focus();
                MessageBox.Show("confirm passwrod is not matched with password fields");
                return;

            }
            else
            {
                SqlConnection con = new SqlConnection(conString);
                string que = ("insert into Users values('"+ txt_username.Text + "','" + txt_fullname.Text +"','"+ txt_email.Text + "',"+ txt_phonenumber.Text +",'" + gender +"','" + p_password.Password +"','"+p_confirmpassword.Password +"','" + Dp_Dob.DisplayDate +"')");
                con.Open();
                SqlCommand cmd = new SqlCommand(que,con);
               
                if(cmd.ExecuteNonQuery() != 0)
                {
                    MessageBox.Show("User register succesfully");
                    Clear();


                }


                con.Close();
                cmd.Dispose();

                Login login = new Login();
                this.Visibility = Visibility.Collapsed;
                login.Show();
               
            }

               
        }

        private void rdo_male_Click(object sender, RoutedEventArgs e)
        {
            gender = "MALE";
        }

        private void rdo_female_Click(object sender, RoutedEventArgs e)
        {
            gender = "FEMALE";
        }

        private void rdo_prefernotosay_Click(object sender, RoutedEventArgs e)
        {
            gender = "PREFER NOT TO SAY";
        }
    }
}
    