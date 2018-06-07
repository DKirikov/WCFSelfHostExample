using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SelfHost
{
    public class Test1
    {
        public object name;
    }

    [ServiceContract]
    public interface ISelfService
    {
        int CallsCount
        {
            [OperationContract]
            get;
        }

        [OperationContract]
        String SetTestObject(Test1 testObject);
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class SelfService : ISelfService
    {
        private int callsCount = 0;
        private string lastName = "none";

        public int CallsCount
        {
            get
            {
                callsCount++;
                return callsCount;
            }
        }


        public String SetTestObject(Test1 testObject)
        {
            if (testObject.name is String)
            {
                string res = "last name: '" + lastName + "' new name: '" + (testObject.name as string) + "'";
                lastName = testObject.name as string;
                return res;
            }

            throw new Exception("testObject.name is not String");
        }
    }
}
