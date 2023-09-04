using Restoreo.Models;
using Restoreo.Pages;
using Restoreo.Views;
using Restoreo.WorkWithBD;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Restoreo.ViewModels
{
    internal class AdminTablesViewModel:ViewModelBase
    {
        private List<Zakaz> zakazs;
        public AdminApplicationViewModels window;

        private ComboBoxItem time = new ComboBoxItem() { Content = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() };

        private DateTime date = DateTime.Now;


        public static Zakaz Myzakaz = new Zakaz();
        public static AdminChoiceTable page;
        public AdminTablesViewModel(AdminChoiceTable page, AdminApplicationViewModels widow)
        {
            AdminTablesViewModel.page = page;
            this.window = widow;
            table = null;

            Tabless = TableBD.GetTables();

            zakazs = TableBD.GetOrders();
            Myzakaz.time = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
            Myzakaz.Day = DateTime.Now.Day.ToString() + "." + DateTime.Now.Month.ToString() + "." + DateTime.Now.Year.ToString();
            Myzakaz.Name = RegistrationViewModel.user.login;
            this.GetFreeTables();

            GetAllOrders = new Command(ExecuteGetAllOrders, CanExecuteGetAllOrders);

        }


        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                Myzakaz.Day = date.Day.ToString() + "." + date.Month.ToString() + "." + date.Year.ToString();
                GetFreeTables();
                OnPropertyChanged("Date");
            }
        }
        public ComboBoxItem Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
                Myzakaz.time = time.Content.ToString();
                GetFreeTables();
                OnPropertyChanged("Time");
            }
        }


        private ObservableCollection<Table> tables = new ObservableCollection<Table>();
        public ObservableCollection<Table> Tabless
        {
            get { return tables; }
            set { tables = value; OnPropertyChanged("Tabless"); }
        }



        private Table table;

        public Table IsSelect
        {
            get { return table; }
            set
            {
                table = value;
                if (table == null)
                {
                    return;
                }

                if (table.isFree == true)
                {
                    return;
                }

                foreach (var item in zakazs)
                {
                    if (table.id == item.tableid)
                    {
                        Zakaz order = GetOrder(table);
                        AdminWorkTableWindow adminWorkTableWindow = new AdminWorkTableWindow();
                        adminWorkTableWindow.DataContext = new AdminWOrkRableViewModel(table,order, window);
                        adminWorkTableWindow.ShowDialog();
                        return;
                    }
                }
            }
        }

        public void GetFreeTables()
        {
            int ii = -1;
            foreach (var item in zakazs)
            {
                for (int i = 0; i < tables.Count; i++)
                {
                    int hourT = Int32.Parse(Time.Content.ToString().Split(':')[0].ToString());
                    int hourZ = Int32.Parse(item.time.Split(':')[0]);
                    if (item.tableid == tables[i].id)
                    {
                        if (item.Day == (date.Day.ToString() + "." + date.Month.ToString() + "." + date.Year.ToString()) && hourT <= hourZ + 1 && hourT >= hourZ - 1)
                        {
                            ii = i;
                            Tabless[i].isFree = false;
                            continue;
                        }
                        else
                        {
                            if (ii == i)
                            {
                                continue;
                            }
                            Tabless[i].isFree = true;
                        }

                    }
                }
            }

            OnPropertyChanged(nameof(Tabless));


            page.DataContext = null;
            page.DataContext = this;

        }


        private Zakaz GetOrder(Table table)
        {
            int hourT = Int32.Parse(Time.Content.ToString().Split(':')[0].ToString());
            foreach (var item in zakazs)
            {
                int hourZ = Int32.Parse(item.time.Split(':')[0]);
                if (item.tableid == table.id)
                {
                    if (item.Day == (date.Day.ToString() + "." + date.Month.ToString() + "." + date.Year.ToString()) && hourT <= hourZ + 1 && hourT >= hourZ - 1)
                    {
                        return item;
                    }
                }

            }
            return null;
        }





        public ICommand GetAllOrders { get; }


        private void ExecuteGetAllOrders(object obj)
        {
            AllOrdersWindow allOrdersWindow = new AllOrdersWindow();
            allOrdersWindow.Show();
        }

        private bool CanExecuteGetAllOrders(object arg)
        {
            return true;
        }



    }
}
