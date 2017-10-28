using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Different_Integers_Size
{
    class Different_Integers_Size
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            List<string> validDataTypes = GetValidDataTypes(number);

            if (validDataTypes.Count == 0)
                Console.WriteLine("{0} can't be fitted anywhere", number);
            else
                Console.WriteLine("{0} can be fitted in:\n{1}", number, string.Join("\n", validDataTypes));
        }

        private static List<string> GetValidDataTypes(string number)
        {
            string dataTypes = "sbyte,byte,short,ushort,int,uint,long";
            List<string> validDataTypes = dataTypes.Split(',').ToList();
            try
            {
                sbyte.Parse(number);
            }
            catch (Exception)
            {
                validDataTypes.Remove("sbyte");
            }
            try
            {
                byte.Parse(number);
            }
            catch (Exception)
            {
                validDataTypes.Remove("byte");
            }
            try
            {
                short.Parse(number);
            }
            catch (Exception)
            {
                validDataTypes.Remove("short");
            }
            try
            {
                ushort.Parse(number);
            }
            catch (Exception)
            {
                validDataTypes.Remove("ushort");
            }
            try
            {
                int.Parse(number);
            }
            catch (Exception)
            {
                validDataTypes.Remove("int");
            }
            try
            {
                uint.Parse(number);
            }
            catch (Exception)
            {
                validDataTypes.Remove("uint");
            }
            try
            {
                long.Parse(number);
            }
            catch (Exception)
            {
                validDataTypes.Remove("long");
            }
            for (int i = 0; i < validDataTypes.Count; i++)
                validDataTypes[i] = "* " + validDataTypes[i];
            return validDataTypes;
        }
    }
}