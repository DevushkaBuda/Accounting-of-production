using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ProkatHolm
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static bool IsGone;
        public static Models.CMKUchetEntities DB = new Models.CMKUchetEntities();
        public static int Mode { get; set; }
        public static Models.Order currentOrder = null;
        public static Models.Client currentClient = null;
        public static Models.Nomenclature currentNomenclature = null;
        public static Models.Process currentProcess = null;
        public static Models.Shop currentShop = null;
        public static Models.User currentUser = null;
        public static int IdSh;
        public static int IdOr;
        public static int IdSchet;
        public static DateTime IdDateOp;

    }
}
