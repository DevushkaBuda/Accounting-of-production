using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_TestAuth
{
    public class InterProviderLibrary
    {
        public class Analytics
        {

            public Boolean CheckPrice(int price)
            {
                if (price <= 1500)
                {
                    return false;
                }
                else
                    return true;
            }

            public int DiscountPrice(int price)
            {
                int sum = ((price / 100) * 15) * price;
                return sum;
            }

            public string PriceNotNull(int price)
            {
                if (price <= 0)
                {
                    return "Цена не может быть меньше или равна нулю!!!";
                }
                else
                    return "Всё правильно";
            }
        }
        /// <summary>
        /// Проверка Имя клиента
        /// </summary>
        /// <param name="name">
        /// 
        /// </param>
        /// <returns>
        /// true если введено верно
        /// false введено не верно
        /// </returns>
        public bool NameCheck(string name)
        {
            string correctSymbols = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя-";
            string nameOne = name;
            name = name.ToLower();
            if (!name.All(x => correctSymbols.Contains(x)))
            {
                throw new Exception("Имя содержит недоступные символы. Писать на кириллице");
            }
            if (name == String.Empty)
            {
                throw new Exception("Вы не ввели имя полностью");
            }
            if (name.EndsWith("-") || name.StartsWith("-"))
            {
                throw new Exception("Имя содержит знак 'дефис' только в середине");
            }
            name = nameOne;
            char symbol = name[0];
            if (Char.IsLower(symbol))
            {
                throw new Exception("Имя должно начинаться с заглавной буквы");
            }
            return true;
        }
    }
}
