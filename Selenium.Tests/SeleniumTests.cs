using NUnit.Framework;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using OpenQA.Selenium;
using Allure.Commons;
using System;

namespace Selenium.Tests
{

    [TestFixture]
    [AllureNUnit]
    [AllureDisplayIgnored]
    public class SeleniumTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test(Description = "Test Selenium 1")]
        [AllureTag("Regression")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureIssue("ISSUE-1")]
        [AllureTms("TMS-12")]
        [AllureOwner("Juliano Costa")]
        [AllureSuite("Login")]
        [AllureSubSuite("Sucess")]
        public void Test1()
        {
            Random rnd = new Random();
            int n  = rnd.Next(1, 3);

            if (n % 2 == 0){
                Assert.Pass();
            }else{
                Assert.Fail();
            }
        }

        [Test(Description = "Test Selenium 2")]
        [AllureTag("Regression")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureIssue("ISSUE-2")]
        [AllureTms("TMS-13")]
        [AllureOwner("Juliano Costa")]
        [AllureSuite("Login")]
        [AllureSubSuite("Sucess")]
        public void Test2()
        {
            Assert.Pass();
        }

        [Test(Description = "Test Selenium 3")]
        [AllureTag("Regression")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureIssue("ISSUE-3")]
        [AllureTms("TMS-14")]
        [AllureOwner("Juliano Costa")]
        [AllureSuite("Login")]
        [AllureSubSuite("Sucess")]
        public void Test3()
        {
            Assert.Fail();
        }

        [Test(Description = "Test Selenium 4")]
        [AllureTag("Regression")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureIssue("ISSUE-4")]
        [AllureTms("TMS-15")]
        [AllureOwner("Juliano Costa")]
        [AllureSuite("Login")]
        [AllureSubSuite("Sucess")]
        public void Test4()
        {
            Assert.Pass();
        }

        [Test(Description = "Test Selenium 5")]
        [AllureTag("Regression")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureIssue("ISSUE-5")]
        [AllureTms("TMS-16")]
        [AllureOwner("Juliano Costa")]
        [AllureSuite("Login")]
        [AllureSubSuite("Sucess")]
        public void Test5()
        {
            Assert.Fail();
        }
    }
}