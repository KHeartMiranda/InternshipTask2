using MarsFramework.Global;
using MarsFramework.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;
using System.Linq;
using static MarsFramework.Global.GlobalDefinitions;
using System;
using System.Collections.Generic;

namespace MarsFramework.Pages
{
    internal class ManageListings
    {
        public ManageListings()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        public void Listings()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");
        }

        //Click on Manage Listings Link
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[1]/div/a[3]")]
        private IWebElement manageListingsLink { get; set; }

        //Click on Manage Listings Link on Listing Management page
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/section[1]/div/a[3]")]
        private IWebElement manageListingsLinktwo { get; set; }

        //View the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='eye icon'])[1]")]
        private IWebElement view { get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[1]/td[8]/i[3]")]
        private IWebElement delete { get; set; }

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='outline write icon'])[1]")]
        private IWebElement edit { get; set; }

        //Click on Yes or No
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div[3]/button[2]")]
        private IWebElement clickActionsButtonYes { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div[3]/button[1]")]
        private IWebElement clickActionsButtonNo { get; set; }


        //Listings
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/table/tbody")]
        private IWebElement ManageListingsTable { get; set; }

        //Listings Header
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/table/thead/tr")]
        private IWebElement ManageListingsTableHeader { get; set; }

        //Check Title on Manage Listings
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[1]/td[3]")]
        private IWebElement TitleOnManageListings { get; set; }

        //Check Description of Added Share Skill after clicking on View button
        [FindsBy(How = How.XPath, Using = "//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[1]/div/div/div/div[2]")]
        private IWebElement DescriptionManageListings { get; set; }

        //Check Title on Manage Listings after clicking on Edit button
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[1]/div/div[2]/div/div[1]/input")]
        private IWebElement Title { get; set; }

        internal void ValidateAddedShareSkill()
        {
            GlobalDefinitions.WaitForElement(ManageListingsTableHeader, 50);

            //Verify if Added ShareSkill existed by checking the description. If non-existent, fail test.
            Assert.That(TitleOnManageListings.Text, Is.EqualTo(ExcelLib.ReadData(2, "Title")));

        }

        internal void ViewShareSkill()
        {
            GlobalDefinitions.WaitForElement(manageListingsLink, 30);
            manageListingsLink.Click();

            GlobalDefinitions.WaitForElement(view, 50);
            view.Click();

            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");

            //Verify if Added ShareSkill existed by checking the description. If null, fail test.
            Assert.That(DescriptionManageListings.Text, Is.EqualTo(ExcelLib.ReadData(2, "Description")));
        }

        internal void EditShareSkill()
        {
            GlobalDefinitions.WaitForElement(manageListingsLink, 30);
            manageListingsLink.Click();

            GlobalDefinitions.WaitForElement(edit, 50);
            edit.Click();

            GlobalDefinitions.WaitForElement(Title, 30);

            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");

            //Verify if Added ShareSkill existed by checking the Title. If null, fail test.
            Assert.That(Title.Text, Is.EqualTo(ExcelLib.ReadData(2, "Title")));
        }

        internal void DeleteShareSkill()
        {
            GlobalDefinitions.WaitForElement(manageListingsLink, 30);
            manageListingsLink.Click();

            GlobalDefinitions.WaitForElement(ManageListingsTableHeader, 50);

            if (TitleOnManageListings.Displayed)
            {
                delete.Click();
                clickActionsButtonYes.Click();         
            }
        }

        internal void ValidateDeleteData()
        {
            GlobalDefinitions.WaitForElement(ManageListingsTableHeader, 50);

            //Get the title from the first skill on the listings after deletion
            IWebElement Titletwo = driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[2]/td[3]"));

            Console.WriteLine(Titletwo.Text);

            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");

            //Verify if the title is not the same as the deleted title. If the same, fail test.
            Assert.IsFalse(Titletwo.Text == (ExcelLib.ReadData(2, "Title")));
        }
    }

}