using Customer_WPF.Model;
//using EmployeeWpfMvvmApp.Model;
//using EmployeeWpfMvvmApp.MVVMBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EmployeeWpfMvvmApp.ViewModel
{
    public class EmployeeViewModel: ViewModelBase
    {
        private CustomerModel employeeForm;
        private ObservableCollection<CustomerModel> employeesGrid;

        public CustomerModel EmployeeForm
        {
            get { return employeeForm; }
            set { employeeForm = value; NotifyPropertyChanged("EmployeeForm"); }
        }

       

        public ObservableCollection<CustomerModel> EmployeesGrid
        {
            get { return employeesGrid; }
            set { employeesGrid = value; NotifyPropertyChanged("EmployeesGrid");  }
        }

        public EmployeeViewModel()
        {
            this.EmployeeForm = new CustomerModel();
            this.EmployeesGrid = new ObservableCollection<CustomerModel>();
            this.EmployeesGrid.CollectionChanged += EmployeesGrid_CollectionChanged;
        }

        void EmployeesGrid_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged("EmployeesGrid");
        }

    }

    public class SalaryValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double actualValue = 0;
            string valueToValidate = value as string;
            try
            {
                actualValue = double.Parse(valueToValidate);
            }
            catch (Exception)
            {
                return new ValidationResult(false, "Creadit Limit is not right format");
            }

            return new ValidationResult(true, null);
        }
    }
}
