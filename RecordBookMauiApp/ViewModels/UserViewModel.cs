using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using RecordBookMauiApp.Models;
using Microsoft.Maui.Controls;

namespace RecordBookMauiApp.ViewModels
{
    public class UserViewModel : BindableObject
    {
        private ObservableCollection<User> _users;
        private User _selectedUser;
        private string _name;
        private string _email;

        public UserViewModel()
        {
            _users = new ObservableCollection<User>();
            AddUserCommand = new Command(AddUser);
            UpdateUserCommand = new Command(UpdateUser);
            DeleteUserCommand = new Command(DeleteUser);
            LoadUsersCommand = new Command(LoadUsers);
            ClearFieldsCommand = new Command(ClearFields);
        }

        public ObservableCollection<User> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged();
            }
        }

        public User SelectedUser
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;
                if (_selectedUser != null)
                {
                    Name = _selectedUser.Name;
                    Email = _selectedUser.Email;
                }
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddUserCommand { get; }
        public ICommand UpdateUserCommand { get; }
        public ICommand DeleteUserCommand { get; }
        public ICommand LoadUsersCommand { get; }
        public ICommand ClearFieldsCommand { get; }

        private void AddUser()
        {
            var user = new User { Name = Name, Email = Email };
            _users.Add(user);
            ClearFields();
        }

        private void UpdateUser()
        {
            if (_selectedUser != null)
            {
                _selectedUser.Name = Name;
                _selectedUser.Email = Email;
              
                ClearFields();
                
            }
        }

        private void DeleteUser()
        {
            if (_selectedUser != null)
            {
                _users.Remove(_selectedUser);
                ClearFields();
            }
        }

        private void LoadUsers()
        {
            
        }

        private void ClearFields()
        {
            Name = string.Empty;
            Email = string.Empty;
            SelectedUser = null;
        }
    }
}
