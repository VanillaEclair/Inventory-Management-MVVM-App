using Mei.Commands;
using Mei.Models;
using Mei.MVVM;
using Mei.Services;
using Mei.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Mei.ViewModels
{
    public class LoginViewModel: ViewModelBase
    {


        //public RelayCommand LoginCommand => new RelayCommand(execute => Login());

        public ICommand LoginCommand { get; }


        private string statusMessage;
        public string StatusMessage
        {
            get => statusMessage;
            set
            {
                statusMessage = value;
                OnPropertyChanged();
            }
        }


        private string inputUsername;

        public string InputUsername
        {
            get { return inputUsername; }
            set { inputUsername = value; }
        }

        private string inputPassword;

        public string InputPassword
        {
            get { return inputPassword; }
            set { inputPassword = value;}


        }

        //public void DBconn()
        //{
        //    DBfunctions openConn = new DBfunctions(); // Create an instance
        //    string Query = "SELECT username, password FROM requiem.login";
        //    openConn.DBconnect(Query);
        //}
        public void Login()
        {
            //CheckUser();
            SQLfunctions sql = new SQLfunctions();

            string query = "SELECT * FROM item;";
            sql.DataQuery(query);
        }


        public bool isCredCorrect = false;

        private readonly AuthService _authService;
        private readonly NavigationStore _navigationStore;
        private readonly VMFactory _vMFactory;
        private readonly LoginViewModel _loginViewModel;
        private readonly SQLfunctions _sQLfunctions;
        private readonly MainWindowViewModel _mainWindowViewModel;
        private readonly EditItemStore _editItemStore;
        private readonly RefreshStore _refreshStore;

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        // Remove LoginViewModel parameter and use 'this' for the command
        public LoginViewModel(NavigationStore navigationStore, AuthService authService, VMFactory vMFactory, SQLfunctions sQLfunctions, MainWindowViewModel mainWindowViewModel, EditItemStore editItemStore, RefreshStore refreshStore)
        {
            _navigationStore = navigationStore;
            _authService = authService;
            _vMFactory = vMFactory;
            _sQLfunctions = sQLfunctions;
            _mainWindowViewModel = mainWindowViewModel;
            _editItemStore = editItemStore;
            _refreshStore = refreshStore;

            LoginCommand = new LoginCommand(_navigationStore, _authService, _vMFactory, this, _sQLfunctions, _mainWindowViewModel, _editItemStore, _refreshStore);

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        //public bool CheckUser()
        //{


        //    string Query = $"SELECT * FROM requiem.login WHERE username='{InputUsername}'AND password='{InputPassword}'";
        //    SQLfunctions Dbfunc = new SQLfunctions();

        //    isCredCorrect = Dbfunc.DBquery(Query);


        //    MessageBox.Show(isCredCorrect.ToString());

        //    return isCredCorrect;

    }

        //public void DBconnect()
        //{

        //    try
        //    {
        //        using (MySqlConnection conn = new MySqlConnection(connStr))
        //        {
        //            string Query = "SELECT username, password FROM requiem.login";

        //            conn.Open();
        //            MessageBox.Show("DB Opened");

        //            MySqlCommand cmd = new MySqlCommand(Query, conn);
        //            cmd.ExecuteNonQuery();


        //            MySqlDataReader rdr = cmd.ExecuteReader();

        //            while (rdr.Read())
        //            {
        //                LoginInfo.Add(new UserModel { Username = rdr[0].ToString(), Password = rdr[1].ToString()});
        //                MessageBox.Show(rdr[0] + " -- " + rdr[1]);
        //            }
        //            rdr.Close();



        //            conn.Close();
        //        }
        //    }
        //    catch (MySqlException ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //}

    }

