using MarsFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        [Category("Sprint1")]
        class User : Global.Base
        {
            [Test, Order(1)]
            public void AddShareSkillTest()
            {
                ShareSkill shareskill = new ShareSkill();
                ManageListings manageListings = new ManageListings();
                shareskill.AddShareSkill();
                manageListings.ValidateAddedShareSkill();
                
            }

            [Test, Order(2)]
            public void ViewShareSkillTest()
            {
                ManageListings manageListings = new ManageListings();
                manageListings.ViewShareSkill();
            }

            [Test, Order(3)]
            public void EditShareSkillTest()
            {
                ManageListings manageListings = new ManageListings();
                manageListings.EditShareSkill();
            }

            [Test]
            public void DeleteShareSkillTest()
            {
                ManageListings manageListings = new ManageListings();
                manageListings.DeleteShareSkill();
                manageListings.ValidateDeleteData();
            }

        }
    }
}