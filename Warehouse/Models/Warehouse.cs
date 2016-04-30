using System;
using System.Collections;
using System.Collections.Generic;
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
    class Warehouse : List<Item>
    {
        public int IdCounter { get; private set; }
        public Warehouse SearchName(string name)
        {
            if (name == null) return this;
            Warehouse result = new Warehouse();
            name = name.ToLower();
            foreach (Item colItem in this)
            {
                if(colItem.Name.ToLower() == name) result.Add(colItem);
            }
            return result;
        }
    }
}