using System;
using System.Reflection;
using System.Text;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using P01_BillsPaymentSystem.Data;
using P01_BillsPaymentSystem.Data.Configuration;

namespace P01_BillsPaymentSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine.Run();

           
        }
    }
}
