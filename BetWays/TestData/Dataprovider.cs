using Ganss.Excel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace AutomationTest.TestData
{
    class Dataprovider
    {
        static string pathToIcoFile = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug\netcoreapp3.1", "");
        static string Path = pathToIcoFile + @"\Testdata\data.json";
        public static void JsonD()
        {
            JObject o1 = JObject.Parse(File.ReadAllText(@"C:\Users\ABVB210\Documents\AutomationTest\AutomationTest\TestData\data.json"));

            // read JSON directly from a file
            StreamReader file = File.OpenText(@"C:\Users\ABVB210\Documents\AutomationTest\AutomationTest\TestData\data.json");
            JsonTextReader reader = new JsonTextReader(file);
            {
                JObject o2 = (JObject)JToken.ReadFrom(reader);

             
            }

            
        }


        public static void readFromJson()
        {
            using (StreamReader r = new StreamReader(Path))
            {
                string json = r.ReadToEnd();
                
                JsonTextReader reader = new JsonTextReader(new StringReader(json));
                while (reader.Read())
                {
                    if (reader.Value != null)
                    {
                        Console.WriteLine("Token: {0}, Value: {1}", reader.TokenType, reader.Value);
                    }
                    else
                    {
                        Console.WriteLine("Token: {0}", reader.TokenType);
                    }
                }

                var item = JsonConvert.DeserializeObject<List<Item>>(json);
                var myItems = (from s in item select s).FirstOrDefault();

                Parameters.SetData("testData", myItems);

                Console.WriteLine(myItems.name);
                Console.WriteLine(myItems.email);
                Console.WriteLine(myItems.website);
                Console.WriteLine(myItems.experience);
                Console.WriteLine(myItems.comment);





            }

        }

       

        public class Item
        {
            public string name { get; set; }
            public string email { get; set; }
            public string website { get; set; }
            public string experience { get; set; }
            public string comment { get; set; }

        }

        public void readFromExcel()
        {
            int count = 0;
            var filename = @"C: \Users\ABVB210\Documents\AutomationTest\AutomationTest\TestData\testData.xlsl";
           // var testData = new ExcelMapper(filename).Fetch<DataSheet>();
            Assert.AreEqual(1, count);
        }


    }
}
