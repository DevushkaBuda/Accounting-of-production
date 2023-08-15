using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unit_TestAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;



namespace Unit_TestAuth.Tests
{
    [TestClass()]
    public class AuthClassTests
    {
        [TestMethod()]
        public void AutoTestPositive1()
        {
            Assert.AreEqual("Сотрудник", AuthClass.Auto("admin", "1"));
        }
        [TestMethod()]
        public void AutoTestNegative1()
        {
            Assert.AreEqual("Сотрудник", AuthClass.Auto("admin", "2"));
        }


    }
    [TestClass]
    public class PasswordClassTests
    {
        /// <summary>
        /// Проверка с помощью функции подходит ли пароль нашим условиям
        /// </summary>
        [TestMethod]

        public void CheckPassword_StringEmpty_ReturnedFalse_Positive2()
        {
            string password = string.Empty;
            PasswordClass c = new PasswordClass();
          
        }
        /// <summary>
        /// Проверка слишком короткого пароля
        /// </summary>
        [TestMethod]
        public void PasswordStrengthCheker_ShortPassword_Positive3()
        {
            string password = "123a";
            int excepted = 0;
            int actual = PasswordClass.PasswordStrengthCheker(password);
            Assert.AreEqual(actual, excepted);
        }
        /// <summary>
        /// Проверка пустую строку
        /// </summary>
        [TestMethod]
        public void PasswordStrengthCheker_OnlyNumbers_Positive4()
        {
            string password = "";
            int excepted = 0;
            int actual = PasswordClass.PasswordStrengthCheker(password);
            Assert.AreEqual(actual, excepted);
        }
        /// <summary>
        /// Проверка корректности ФИО
        /// </summary>
        [TestMethod]
        public void NameCheck_RightString_Positive5()
        {
            string author = "Александр";
            InterProviderLibrary obj = new InterProviderLibrary();
            bool res = obj.NameCheck(author);
            Assert.IsTrue(res);
        }

        /// <summary>
        /// Проверка слишком короткого пароля(отрицательный)
        /// </summary>
        [TestMethod]
        public void PasswordStrengthCheker_ShortPassword_Negative2()
        {
            string password = "123a11111111";
            int excepted = 0;
            int actual = PasswordClass.PasswordStrengthCheker(password);
            Assert.AreEqual(actual, excepted);
        }

        /// <summary>
        /// Проверка пустую строку(отрицательный)
        /// </summary>
        [TestMethod]
        public void PasswordStrengthCheker_OnlyNumbers_Negative3()
        {
            string password = "     ";
            int excepted = 1; 
            int actual = PasswordClass.PasswordStrengthCheker(password);
            Assert.AreEqual(actual, excepted);
        }

        /// <summary>
        /// Проверка корректности ФИО
        /// Expostion так как ввод со строчной буквы
        [TestMethod]
        public void NameCheck_RightString_Negative4()
        {
            string author = "александр";
            InterProviderLibrary obj = new InterProviderLibrary();
            bool res = obj.NameCheck(author);
            Assert.IsTrue(res);
        }
       
        /// Проверка корректности ФИО
        /// Expostion так как пустая строка
       
        [TestMethod]
        public void NameCheck_StringEmpty_Negative5()
        {
            string author = String.Empty;
            InterProviderLibrary obj = new InterProviderLibrary();
            bool res = obj.NameCheck(author);
            Assert.IsTrue(res);
        }
      

        /// Проверка корректности ФИО
      /// Expostion так как "p" из латинского алфавита
     
        [TestMethod]
        public void NameCheck_FalseString_Negative6()
        {
            string author = "Александp";
            InterProviderLibrary obj = new InterProviderLibrary();
            bool res = obj.NameCheck(author);
            Assert.IsTrue(res);

        }
    
        
    }
}
