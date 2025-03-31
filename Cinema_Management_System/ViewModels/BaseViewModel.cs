using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Management_System.ViewModels
{
    // BaseViewModel là một lớp trừu tượng để các ViewModel khác kế thừa chức năng
    // Ở đây nó cài giao diện INotifyPropertyChanged, giúp thông báo khi thuộc tính thay đổi trong MVVM
    // Khi một thuộc tính thay đổi, phương thức này gọi sự kiện PropertyChanged, giúp UI tự động cập nhật

    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
