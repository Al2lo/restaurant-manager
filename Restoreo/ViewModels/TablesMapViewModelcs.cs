using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using Microsoft.OData.Edm;
using Restoreo.Models;
using Restoreo.Pages;
using Restoreo.Properties;
using Restoreo.Views;
using Restoreo.WorkWithBD;

namespace Restoreo.ViewModels
{
    internal class TablesMapViewModelcs:ViewModelBase
    {
        public static Zakaz Myzakaz = new Zakaz();
        ChoiceTablePage page;
        public TablesMapViewModelcs(ChoiceTablePage page)
        {
            this.page = page;


            Tabless = TableBD.GetTables();



            zakazs = TableBD.GetOrders();
            Myzakaz.time = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
            Myzakaz.Day = DateTime.Now.Day.ToString() + "." + DateTime.Now.Month.ToString() + "." + DateTime.Now.Year.ToString();
            Myzakaz.Name = RegistrationViewModel.user.login;
            this.GetFreeTables();
        }


        private List<Zakaz> zakazs;

        private ComboBoxItem time = new ComboBoxItem() { Content = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString()};

        private DateTime date = DateTime.Now;

        public DateTime Date
        {
            get { return date; }
            set { 
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
        public ObservableCollection<Table> Tabless { get { return tables; } 
            set { tables = value; OnPropertyChanged("Tabless"); } }



        private Table table;

        public Table IsSelect
        {
            get { return table; }
            set {
                table = value;
                if (table == null)
                {
                    return;
                }
                if (!table.isFree)
                {
                    table = null;
                    return;
                }

                foreach (var item in Tabless)
                {
                    if (item.isEnter == true)
                    {
                        Tabless.Remove(item);
                        item.isEnter = false;
                        Tabless.Add(item);
                        break;
                    }
                }
                foreach (var item in Tabless)
                {
                    if (item.Equals(IsSelect))
                    {
                        Tabless.Remove(item);
                        item.isEnter = true;
                        Tabless.Add(item);
                        break;
                    }
                    }

                OnPropertyChanged("IsSelect");
                if (Tabless.Count == 13)
                {
                    foreach (var item in Tabless)
                    {
                        if (item.isEnter)
                        {
                            table = item;
                        }
                    }
                    RegistrationViewModel.user.table = table;
                    Myzakaz.places = table.places;
                    Myzakaz.vip = table.vip;
                    Myzakaz.tableid = table.id;
                }
               
            
            }
        }



        private void GetFreeTables()
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

    }
}
