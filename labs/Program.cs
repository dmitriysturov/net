/// <summary>
/// 
/// </summary>

using System;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using PcTechs.models;
using PcTechs.UI;
using PcTechs.tests;



namespace PcTechs
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.GetEncoding("Windows-1251");
            tests.ComponentTestData.AddTestComponents();
            Menu.DefaultMenu();
        }
    }
}
