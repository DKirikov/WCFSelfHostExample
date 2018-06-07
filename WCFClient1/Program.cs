using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFClient1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inside Program::Main");

            SelfServiceReference.SelfServiceClient client = new SelfServiceReference.SelfServiceClient();

            try
            {
                var callsCount = client.get_CallsCount();
                Console.WriteLine("CallsCount = " + callsCount.ToString());

                WCFClient1.SelfServiceReference.Test1 testObj = new SelfServiceReference.Test1();

                testObj.name = args.Count() > 0 ? args[0] : "name_" + new Random().Next(100).ToString();
                string returnValue = client.SetTestObject(testObj);
                Console.WriteLine("Return value = " + returnValue);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error! Remote service doesn't respond!");
            }

            Console.ReadKey();
            client.Close();
        }
    }
}
