using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsFramework.Pages
{
    internal class ShareSkill
    {
        public ShareSkill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on ShareSkill Button
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        private IWebElement ShareSkillButton { get; set; }

        //Enter the Title in textbox
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }

        //Enter the Description in textbox
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }

        //Click on Category Dropdown
        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement CategoryDropDown { get; set; }

        //Click on SubCategory Dropdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SubCategoryDropDown { get; set; }

        //Enter Tag names in textbox
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]")]
        private IWebElement Tags { get; set; }


        //Select the Service type
        [FindsBy(How = How.XPath, Using = "(//input[contains(@name,'serviceType')])[1]")]
        private IWebElement HourlyService { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[contains(@name,'serviceType')])[2]")]
        private IWebElement OneOff { get; set; }


        //Select the Location Type
        [FindsBy(How = How.XPath, Using = "(//input[contains(@name,'locationType')])[1]")]
        private IWebElement OnSite { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[contains(@name,'locationType')])[2]")]
        private IWebElement OnLine { get; set; }


        //Click on Start Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDateDropDown { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDateDropDown { get; set; }


        ////Storing the table of available days
        [FindsBy(How = How.XPath, Using = "(//input[contains(@tabindex,'0')])[5]")]
        private IWebElement Sunday { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[contains(@tabindex,'0')])[6]")]
        private IWebElement Monday { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[contains(@tabindex,'0')])[7]")]
        private IWebElement Tuesday { get; set; }


        ////Storing the starttime
        [FindsBy(How = How.XPath, Using = "(//input[contains(@name,'StartTime')])[1]")]
        private IWebElement SundayStartTime { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[contains(@name,'StartTime')])[2]")]
        private IWebElement MondayStartTime { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[contains(@name,'StartTime')])[3]")]
        private IWebElement TuesdayStartTime { get; set; }


        ////Storing the endtime
        [FindsBy(How = How.XPath, Using = "(//input[contains(@name,'EndTime')])[1]")]
        private IWebElement SundayEndTime { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[contains(@name,'EndTime')])[2]")]
        private IWebElement MondayEndTime { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[contains(@name,'EndTime')])[3]")]
        private IWebElement TuesdayEndTime { get; set; }



        //Click on StartTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTimeDropDown { get; set; }

        //Click on EndTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[3]/input[1]")]
        private IWebElement EndTimeDropDown { get; set; }


        //Click on Skill Trade option
        [FindsBy(How = How.XPath, Using = "(//input[contains(@name,'skillTrades')])[1]")]
        private IWebElement SkillExchangeOption { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[contains(@name,'skillTrades')])[2]")]
        private IWebElement CreditOption { get; set; }


        //Enter Skill Exchange
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        private IWebElement SkillExchange { get; set; }

        //Enter the amount for Credit
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
        private IWebElement CreditAmount { get; set; }

        //Click on Active/Hidden option
        [FindsBy(How = How.XPath, Using = "(//input[contains(@name,'isActive')])[1]")]
        private IWebElement Active { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[contains(@name,'isActive')])[2]")]
        private IWebElement Hidden { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }

        internal void Category(IWebElement element, string option)
        {
            element.Click();
            var selectelement = new SelectElement(element);
            selectelement.SelectByText(option);
        }

        internal void SubCategory(IWebElement element, string option)
        {
            element.Click();
            var selectelement = new SelectElement(element);
            selectelement.SelectByText(option);
        }

        internal void AddShareSkill()
        {
            ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");

            GlobalDefinitions.WaitForElement(ShareSkillButton, 30);
            ShareSkillButton.Click();
            
            GlobalDefinitions.WaitForElement(Title, 30);
            Title.SendKeys(ExcelLib.ReadData(2, "Title"));

            Description.SendKeys(ExcelLib.ReadData(2, "Description"));

            Category(CategoryDropDown, "Video & Animation");

            SubCategory(SubCategoryDropDown, "Promotional Videos");

            Tags.SendKeys(ExcelLib.ReadData(2, "Tags"));
            Tags.SendKeys(Keys.Enter);

            OneOff.Click();

            OnLine.Click();

            StartDateDropDown.SendKeys("11/01/2019");

            EndDateDropDown.SendKeys("11/07/2019");

            Sunday.Click();
            SundayStartTime.SendKeys("08:00AM");
            SundayEndTime.SendKeys("05:00PM");

            Monday.Click();
            MondayStartTime.SendKeys("08:00AM");
            MondayEndTime.SendKeys("05:00PM");

            Tuesday.Click();
            TuesdayStartTime.SendKeys("08:00AM");
            TuesdayEndTime.SendKeys("05:00PM");

            CreditOption.Click();

            if (SkillExchangeOption.Selected)
            {
                SkillExchange.SendKeys("photo editing");
            }
            else
            {
                CreditAmount.SendKeys("10");
            }

            Hidden.Click();

            Save.Click();
        }
    }
}
