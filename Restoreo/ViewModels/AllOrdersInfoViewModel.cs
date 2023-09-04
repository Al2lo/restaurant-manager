using Restoreo.Models;
using Restoreo.WorkWithBD;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoreo.ViewModels
{
    internal class AllOrdersInfoViewModel:ViewModelBase
    {
        private ObservableCollection<AdminOrderInfo> adminOrderInfos;

        public AllOrdersInfoViewModel()
        {
            this.adminOrderInfos = AdminGetInfoBD.GetAllOrdersAdmin();
        }

        public ObservableCollection<AdminOrderInfo> AdminOrderInfos
        {
            get { return adminOrderInfos; }
            set { adminOrderInfos = value; }
        }
    }
}
