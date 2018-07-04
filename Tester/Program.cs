using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericValidation;
using GenericValidation.Config;
using FakeItEasy;
using NUnit;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            Fake<ConfigManager> config = new Fake<ConfigManager>();
            //config.CallsTo(a => a.GetAbstractValidatorByName());
            //ConfigManager config = new ConfigManager();
            Console.ReadKey();            
        }
    }
}
