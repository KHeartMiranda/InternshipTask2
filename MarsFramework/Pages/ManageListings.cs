using MarsFramework.Global;
using MarsFramework.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;
using System.Linq;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsFramework.Pages
{
    internal class ManageListings
    {
        public ManageListings()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on Manage Listings Link
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement manageListingsLink { get; set; }

        //View the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='eye icon'])[1]")]
        private IWebElement view { get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "//table[1]/tbody[1]")]
        private IWebElement delete { get; set; }

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='outline write icon'])[1]")]
        private IWebElement edit { get; set; }

        //Click on Yes or No
        [FindsBy(How = How.XPath, Using = "//div[@class='actions']")]
        private IWebElement clickActionsButton { get; set; }


        //Check Description of Added Share Skill after clicking on View button
        [FindsBy(How = How.XPath, Using = "//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[1]/div/div/div/div[2]")]
        private IWebElement DescriptionManageListings { get; set; }

        //Check Title on Manage Listings after clicking on Edit button
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }

        internal void Listings()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");

        }

        internal void ViewShareSkill()
        {
            GlobalDefinitions.WaitForElement(manageListingsLink, 30);
            manageListingsLink.Click();

            GlobalDefinitions.WaitForElement(view, 50);
            view.Click();

            //Verify if Added ShareSkill existed by checking the description. If non-existent, fail test.
            Assert.That(DescriptionManageListings.Text, Is.EqualTo(ExcelLib.ReadData(2, "Description")));          
        }

        internal void EditShareSkill()
        {
            GlobalDefinitions.WaitForElement(manageListingsLink, 30);
            manageListingsLink.Click();

            GlobalDefinitions.WaitForElement(edit, 50);
            edit.Click();

            GlobalDefinitions.WaitForElement(Title, 30);
            //Verify if Added ShareSkill existed by checking the Title. If non-existent, fail test.
            Assert.That(Title.Text, Is.EqualTo(ExcelLib.ReadData(2, "Title")));

        }

    }
}