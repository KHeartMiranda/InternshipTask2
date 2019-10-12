﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace MarsFramework.Pages
{
    class SignIn
    {
        public SignIn()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);

        }

        #region  Initialize Web Elements 
        //Finding the Sign Link
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Sign')]")]
        private IWebElement SignIntab { get; set; }

        // Finding the Email Field
        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement Email { get; set; }

        //Finding the Password Field
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement Password { get; set; }

        //Finding the Login Button
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Login')]")]
        private IWebElement LoginBtn { get; set; }

        #endregion

        internal void LoginSteps()
        {
            SignIntab.Click();
            
            Email.SendKeys("mvpstudio.qa@gmail.com");

            Password.SendKeys("SydneyQa2018");

            LoginBtn.Click();
        }
    }
}