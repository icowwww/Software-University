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
            List<string> validDataTypes = new List<string>();

            sbyte sbyteResult;
            byte byteResult;
            short shortResult;
            ushort ushortResult;
            int intResult;
            uint uintResult;
            long longResult;

            sbyte.TryParse(number, out sbyteResult);
            byte.TryParse(number, out byteResult);
            short.TryParse(number, out shortResult);
            ushort.TryParse(number, out ushortResult);
            int.TryParse(number, out intResult);
            uint.TryParse(number, out uintResult);
            long.TryParse(number, out longResult);

            if (sbyteResult != 0 || number == "0")  validDataTypes.Add("* sbyte");
            if (byteResult != 0 || number == "0")   validDataTypes.Add("* byte");
            if (shortResult != 0 || number == "0")  validDataTypes.Add("* short");
            if (ushortResult != 0 || number == "0") validDataTypes.Add("* ushort");
            if (intResult != 0 || number == "0")    validDataTypes.Add("* int");
            if (uintResult != 0 || number == "0")   validDataTypes.Add("* uint");
            if (longResult != 0 || number == "0")   validDataTypes.Add("* long");

            if (validDataTypes.Count == 0)
                Console.WriteLine("{0} can't be fitted anywhere", number);
            else
                Console.WriteLine("{0} can be fitted in:\n{1}", number, string.Join("\n", validDataTypes));
        }
    }
}