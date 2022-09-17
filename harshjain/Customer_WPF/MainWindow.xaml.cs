using Customer_WPF.DAO;
using Customer_WPF.Model;
using EmployeeWpfMvvmApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Customer_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mdl = (EmployeeViewModel)MyLayout.DataContext;

        }
        public static MainWindow Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MainWindow();
                }
                return instance;
            }
        }
        public static MainWindow instance;
        private EmployeeViewModel mdl;

        bool isNew = true;
        public bool IsNew
        {
            get { return isNew; }
            set
            {
                isNew = value;
                LblFormStatus.Content = isNew ? "New Employee" : "Edit Employee";
                TxtID.IsReadOnly = !isNew;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure to save?", "Confirm", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
            {
                return;
            }


            if (IsNew)
            {
                CustomerDAO.Create(mdl.EmployeeForm);
            }
            {
                CustomerDAO.Update(mdl.EmployeeForm);
            }

            MessageBox.Show("Employee is saved successfully.");
            lblStatus.Text = "Employee is saved successfully.";

            BtnLoad_Click(null, null);
            BtnNew_Click(null, null);
        }

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
             ObservableCollection<CustomerModel> customer = CustomerDAO.ReadAll();
            mdl.EmployeesGrid = customer;
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            mdl.EmployeeForm = new CustomerModel();
            IsNew = true;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            mdl.EmployeeForm = (CustomerModel)GrdEmployees.SelectedItem;
            IsNew = false;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete?", "Confirm", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
            {
                return;
            }
            CustomerModel employee = (CustomerModel)GrdEmployees.SelectedItem;
            CustomerDAO.Delete(employee.Id);

            MessageBox.Show("Employee is deleted successfully.");
            lblStatus.Text = "Employee is deleted successfully.";

            BtnLoad_Click(null, null);
            BtnNew_Click(null, null);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.Show();
            this.Hide();
        }
    }
}
