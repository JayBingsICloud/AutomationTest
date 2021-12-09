using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationTest
{


    //Dictionary to store variable as you see fit if you want to use them along the classes
    public class Parameters
    {
         private static Dictionary<String, object> parameter = new Dictionary<string, object>();
            public static T GetData<T>(String key)
            {
                var value = (dynamic)null;
                try
                {
                    value = Convert.ChangeType(parameter[key.ToUpper()], typeof(T));
                }
                catch (Exception e)
                {
                    value = default(T);
                    throw new Exception(string.Format("For Key {0}: {1}", key.ToUpper(), e.Message));

                }
                return value;
            }
            public static void SetData(String key, object ob)
            {
                if (parameter.ContainsKey(key.ToUpper()))
                {
                    parameter[key.ToUpper()] = ob;
                }
                else
                {

                    Console.WriteLine(string.Format("Key: {0} value: {1}", key, ob));
                    parameter.Add(key.ToUpper(), ob);
                }
            }
        }

    }

