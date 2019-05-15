using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebDriverTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize the Chrome Driver
            using (var driver = new ChromeDriver())
            {
                // Go to the home page
                driver.Navigate().GoToUrl("http://testapp.galenframework.com/");

                // Get User Name field, Password field and Login Button
                var loginButton = driver.FindElementByXPath("//button[text()='Login']");
                // and click the login button to enter username and password
                loginButton.Click();

                var userNameField = driver.FindElementByName("login.username");
                var userPasswordField = driver.FindElementByName("login.password");
               
                
                // Type user name and password
                userNameField.SendKeys("testuser@example.com");
                userPasswordField.SendKeys("test123");

                // Login to system to create NOTE
                var loginToSytem = driver.FindElementByXPath("//button[text()='Login']");
                loginToSytem.Click();

                // Click Login button to open Add Note page
                var loginToAddNote = driver.FindElementByXPath("//button[text()='Add note']");
                loginToAddNote.Click();


                // Type Title and Description
                var titleField = driver.FindElementByName("note.title");
                var descriptionField = driver.FindElementByName("note.description");

                titleField.SendKeys("Title Note to Test");
                descriptionField.SendKeys("Title Description");

                // Add Note
                var addNote = driver.FindElementByXPath("//button[text()='Add Note']");
                addNote.Click();


                // Extract resulting message and save it into result.txt
                //var result = driver.FindElementByXPath("//div[@id='case_login']/h3").Text;
                // File.WriteAllText("result.txt", result);

                // Take a screenshot and save it into screen.png
                driver.GetScreenshot().SaveAsFile(@"screen.png", ImageFormat.Png);
            }
        }
    }
}
