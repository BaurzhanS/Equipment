using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace Accounting.Computer.Lib
{
    public delegate void PrintMessage(string str);
    public delegate void ShowError(Exception ex);

    public struct ServiceEquipment
    {
        //public ServiceEquipment(string dbName)
        //{
        //    DBName = dbName;
        //}

        PrintMessage printMessage;
        ShowError showError;

        public void RegisterMessage(PrintMessage printMessage)
        {
            this.printMessage = printMessage;
        }

        public void RegisterError(ShowError showError)
        {
            this.showError = showError;
        }

        public string DBName { get; set; }
        public void AddEquipment(Equipment equipment)
        {
            try
            {
                if (string.IsNullOrEmpty(DBName))
                    throw new Exception("Строка подключения к базе данных не должна быть пустой");

                using (LiteDatabase db=new LiteDatabase(DBName))
                {
                    var equipments = db.GetCollection<Equipment>("Equipment");
                    equipments.Insert(equipment);
                }
                if (printMessage != null)
                    printMessage.Invoke("Запись добавлена успешно");
            }
            catch (Exception ex)
            {
                if (showError!=null)
                {
                    showError.Invoke(ex);
                }
            }
        }

        public void EditEquipment(Equipment equipment)
        {
            try
            {
                if (string.IsNullOrEmpty(DBName))
                    throw new Exception("Строка подключения к базе данных не должна быть пустой");

                using (LiteDatabase db = new LiteDatabase(DBName))
                {
                    var equipments = db.GetCollection<Equipment>("Equipment");
                    equipments.Update(equipment);
                }
                if (printMessage != null)
                    printMessage.Invoke("Запись изменена успешно");
            }
            catch (Exception ex)
            {
                if (showError != null)
                {
                    showError.Invoke(ex);
                }
            }
        }

        public void DelEquipment(int equipmentId)
        {
            try
            {
                if (string.IsNullOrEmpty(DBName))
                    throw new Exception("Строка подключения к базе данных не должна быть пустой");

                using (LiteDatabase db = new LiteDatabase(DBName))
                {
                    var equipments = db.GetCollection<Equipment>("Equipment");
                    equipments.Delete(equipmentId);
                }
                if (printMessage != null)
                    printMessage.Invoke("Запись удалена" +
                        " успешно");
            }
            catch (Exception ex)
            {
                if (showError != null)
                {
                    showError.Invoke(ex);
                }
            }
        }

        public List<Equipment> SearchEquipment(string name)
        {
            List<Equipment> listEq = null;
            try
            {
                if (string.IsNullOrEmpty(DBName))
                    throw new Exception("Строка подключения к базе данных не должна быть пустой");

                using (LiteDatabase db = new LiteDatabase(DBName))
                {
                    var equipments = db.GetCollection<Equipment>("Equipment");
                    listEq=equipments.Find(x=>x.Name.Equals(name)).ToList();
                }
                return listEq;
            }
            catch (Exception ex)
            {
                if (showError != null)
                {
                    showError.Invoke(ex);
                }
                return listEq;
            }
        }
    }
}
