using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounting.Computer.Lib;
using Accounting.Computer.Lib.Models.Soft;

namespace Accounting.Computer.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //Equipment equipment = new Equipment();
            //equipment.Name = "Computer";
            //equipment.Model = "Apple";
            //equipment.Price = 3000;
            //equipment.IssueDate = DateTime.Now;
            //equipment.Garantee = 3;

            ServiceEquipment seq = new ServiceEquipment();
            //seq.RegisterError(PrintMessage);
            seq.DBName = @"\\sd\City\SDP-181\Задание 03\Account.DB";
            //seq.RegisterMessage(PrintMessage);
            //seq.AddEquipment(equipment);

            SoftWare softWare = new SoftWare();
            softWare.Price = 100;
            softWare.SoftwareTypes = SoftwareTypes.free;
            softWare.InstalDate = DateTime.Now;
            if(seq.SearchEquipment("Computer")!=null)
                softWare.Equipment = seq.SearchEquipment("Computer")[0];
            ServiceSoftware ss = new ServiceSoftware();
            ss.DBName = @"\\sd\City\SDP-181\Задание 03\Account.DB";
            ss.RegisterError(PrintMessage);
            ss.RegisterMessage(PrintMessage);
            ss.AddSoftware(softWare);

        }

        public static void PrintMessage(string str)
        {
            System.Console.ForegroundColor = System.ConsoleColor.Green;
            System.Console.WriteLine(str);
            System.Console.ForegroundColor = System.ConsoleColor.White;
        }

        public static void PrintMessage(Exception ex)
        {
            System.Console.ForegroundColor = System.ConsoleColor.Red;
            System.Console.WriteLine(ex.Message);
            System.Console.ForegroundColor = System.ConsoleColor.White;
        }

        public static void SendNotification(SoftWare sw)
        {
            System.Console.WriteLine("Уведомление об установке отпарвлено");
        }
    }
}
