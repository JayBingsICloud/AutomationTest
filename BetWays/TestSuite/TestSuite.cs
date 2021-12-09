using AutomationTest.PageOjects;
using AutomationTest.TestData;
using Ganss.Excel;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using static AutomationTest.TestData.Dataprovider;
using static AutomationTest.Parameters;

namespace AutomationTest
{
    public class Test
    {

        IWebDriver driver;

        


        [SetUp]
        public void Setup()
        {


          SeleniumWebDriver.Launchbrowser("CHROME");
          Log.initExtentReport("Windows", "RIB CCS");
          Log.CreateTestFeature("RIB CCS Tests");
          Dataprovider.readFromJson();


            var item = Parameters.GetData<Item>("testData");
         
            var name = item.name;
            var email = item.email;
            var website = item.website;
            var experience = item.experience;
            var comment = item.comment;




        }

        [Test]

        
  
        public void Tests()
        {
            Log.CreateScenarionNode("Drag and drop images to trash");

            try
            {
               
                Web.HomeScreen.go2Url("http://www.globalsqa.com/demo-site/draganddrop/");
                SeleniumWebDriver.waitForPageToBeReady_2();
                Web.HomeScreen.Validate_LandingPage();
                Log.LogResults("Navigate to home Page", "Pass");

        
                Web.HomeScreen.dragAndDrop();
                Web.HomeScreen.dragAndDrop();
                Log.LogResults("Dragged and Dropped","Pass");

            }
            catch (Exception e )
            {
                Log.LogResults("Dragged and Dropped" + e.Message, "Fail");
                throw new Exception(e.Message);
                
            }

            Log.CreateScenarionNode("Navigate to Dropdown Menu and choose a country");

            try
            {

                Web.HomeScreen.navigateToDropdownMenu("AGO");
                Log.LogResults("Navigate to Dropdown Menu and choose a country", "Pass");



            }
            catch (Exception e)
            {
                Log.LogResults("Navigate to Dropdown Menu and choose a country" + e.Message, "Fail");
                throw new Exception(e.Message);


            }

            Log.CreateScenarionNode("Navigate to the sample page test and fill in information");

            try
            {
                Dataprovider.readFromJson();


                var item = Parameters.GetData<Item>("testData");

                var name = item.name;
                var email = item.email;
                var website = item.website;
                var experience = item.experience;
                var comment = item.comment;

                Web.HomeScreen.navigateToSampleAndFillInInfo(item.name,item.email,item.website,item.experience,"",item.comment);
                Log.LogResults("Navigate to the sample page test and fill in information", "Pass");

               

            }
            catch (Exception e)
            {
                Log.LogResults("NNavigate to the sample page test and fill in information" + e.Message, "Fail");
                throw new Exception(e.Message);
                

            }

            


        }

        [TearDown]
        public void tearDown()
        {

            SeleniumWebDriver.close();
            Log.flush();
        }
    }
}