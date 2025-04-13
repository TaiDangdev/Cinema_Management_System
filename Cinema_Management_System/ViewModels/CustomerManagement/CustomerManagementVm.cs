using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Cinema_Management_System.Models.DAOs;
using Cinema_Management_System.Models.DTOs;
using System.Windows.Forms;

namespace Cinema_Management_System.ViewModels.CustomerManagement
{
    public class CustomerManagementVm : INotifyPropertyChanged
    {
        private readonly CustomerDA _customerDA = new CustomerDA();

        private ObservableCollection<CustomerDTO> _allCustomers;
        private ObservableCollection<CustomerDTO> _fillteredCustomer;
        private string _searchKeyword;
        public enum SearchType
        {
            FullName,
            PhoneNumber
        }


        //Thuộc tính để binding với DataGridView
        public ObservableCollection<CustomerDTO> Customers
        {
            get => _fillteredCustomer;
            set
            {
                _fillteredCustomer = value;
                OnPropertyChanged(nameof(Customers));
            }
        }
        public string searchKeyword
        {
            get => _searchKeyword;
            set
            {
                _searchKeyword = value;
                OnPropertyChanged(nameof(searchKeyword));
                FillterCustomers();
            }
        }
        private SearchType _currentSearchType = SearchType.FullName;
        public SearchType CurrentSearchType
        {
            get => _currentSearchType;
            set
            {
                _currentSearchType = value;
                OnPropertyChanged(nameof(CurrentSearchType));
                FillterCustomers();
            }
        }

        // Constructor
        public CustomerManagementVm()
        {
            LoadCustomers();
        }

        // Tải danh sách khách hàng từ DAO
        private void LoadCustomers()
        {
            try
            {
                var customerList = _customerDA.GetAllCustomer();
                _allCustomers = new ObservableCollection<CustomerDTO>(customerList);
                Customers = new ObservableCollection<CustomerDTO>(_allCustomers);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách khách hàng: " + ex.Message);
            }
        }

        private void FillterCustomers()
        {
            if (string.IsNullOrWhiteSpace(_searchKeyword))
            {
                Customers = new ObservableCollection<CustomerDTO>(_allCustomers);
            }
            else
            {
                var lowerKeyword = _searchKeyword.ToLower();
                var filltered = _allCustomers.Where(c => 
                                                   (_currentSearchType == SearchType.FullName && c.FullName.ToLower().Contains(lowerKeyword)) ||
                                                    (_currentSearchType == SearchType.PhoneNumber && c.PhoneNumber.Contains(lowerKeyword))
                                                    ).ToList();
                Customers = new ObservableCollection<CustomerDTO>(filltered);
            }
        }

        public bool AddCustomer(CustomerDTO customer)
        {
            try
            {
                bool result = _customerDA.AddCustomer(customer);
                if (result)
                {
                    _allCustomers.Add(customer);
                    FillterCustomers(); 
                }
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm khách hàng: " + ex.Message);
                return false;
            }
        }

        //Thực thi khi thuộc tính thay đổi
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
