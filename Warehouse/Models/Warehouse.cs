using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
TASK:
#12. Склад. 
1) База товаров, хранящихся на складе: наименование, единица измерения, цена единицы, количество, дата последнего завоза. 
2) Регистрация поступления товара (формирование приходной накладной) и отгрузки (расходная накладная). 
3) Вывод инвентарной ведомости.
*/
namespace Warehouse
{
    [Serializable]
    class Warehouse : BindingList<Item>, ICloneable
    {
        public int IdCounter { get; private set; }

        public Warehouse() { }
        public Warehouse SearchName(string name)
        {
            if (name == "") return this;
            Warehouse result = new Warehouse();
            name = name.ToLower();
            foreach (Item colItem in this)
            {
                if(colItem.Name.ToLower().Contains(name)) result.Add(colItem);
            }
            return result;
        }
        public object Clone()
        {
            Warehouse result = new Warehouse();
            foreach (Item item in this)
            {
                result.Add(item);
            }
            return result;
        }

        /*public static Comparer<Item> GetNameComparer()
        {

            return 
        }*/
    }

    static class BaseExtensionMethods
    {
        public static Warehouse ToWarehouse(this List<Item> toConvert)
        {
            Warehouse result = new Warehouse();
            foreach (Item item in toConvert)
            {
                result.Add(item);
            }
            return result;
        }
    }
}