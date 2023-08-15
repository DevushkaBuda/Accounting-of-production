using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Unit_TestAuth
{
    public class PasswordClass
    {
        /// <summary>
        /// Проверка на сложность пароля
        /// </summary>
        /// <param name="password">
        /// Является паролем
        /// </param>
        /// <returns>
        /// Возвращает сложность пароля
        /// </returns>
        public static int PasswordStrengthCheker(string password)
        {
            var count = 0;

            //метод, проверящий сложность пароля от 7 символов и более
            if (Regex.IsMatch(password, @".{7,}", RegexOptions.IgnoreCase))
            {
                count = count + 1;

                //метод, проверяющий наличие в пароле нижнего регистра
                if (Regex.IsMatch(password, @"(?=.*[a-z])"))
                {
                    count = count + 1;
                }
                //метод, проверящий наличие в пароле верхнего регистра 
                if (Regex.IsMatch(password, @"(?=.*[A-Z])"))
                {
                    count = count + 1;
                }
                //метод, проверяющий наличие в пароле цифр
                if (Regex.IsMatch(password, @"(?=.*\d)", RegexOptions.IgnoreCase))
                {
                    count = count + 1;
                }
                //метод, проверяющий наличие Кириллицы в пароле
                if (Regex.IsMatch(password, (@"\p{IsCyrillic}+"), RegexOptions.IgnoreCase))
                {
                    throw new Exception("Кириллические символы запрещены при вводе пароля");
                }
                //метод, проверяющий наличие спец символов
                if (Regex.IsMatch(password, @"(?=.*[!@#$%^&*])", RegexOptions.IgnoreCase))
                {
                    count = count + 1;
                }
            }





            return count;
        }
        /// <summary>
        /// Проверка правильности формирования пароля
        /// </summary>
        /// <param name="password">
        /// Пароль
        /// </param>
        /// <returns>
        /// Выводит, истина или ложь(подходит ли нам пароль или нет)
        /// </returns>
        public bool CheckPassword(string password)
        {
            if (Regex.IsMatch(password, @"((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,15})", RegexOptions.IgnoreCase))
            {
                if (Regex.IsMatch(password, @"(?=.*[\!\@\\\*\(\)\^\$])", RegexOptions.IgnoreCase))
                {
                    return true;
                }
                else
                {
                    throw new Exception("Не соответствует критериям");
                }
            }
            else
            {
                throw new Exception("Полное несоответствие");
            }

            return true;
        }
    }
}

