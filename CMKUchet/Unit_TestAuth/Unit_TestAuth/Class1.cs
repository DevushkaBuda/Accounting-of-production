using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace Unit_TestAuth
{
    public class AuthClass
    {
        public static CMKUchetEntities db = new CMKUchetEntities();
        public static string Auto(string login, string password)
        {
            var currentUser = db.User.FirstOrDefault(p => p.login == login && p.password == password);
            if (currentUser !=null)
            {
                switch (currentUser.role_id)
                {
                    case 1: return "Сотрудник";
                    case 2: return "Клиент";
                 
                }
            }
            return "Такого пользователя нет";
        }
    }
}
