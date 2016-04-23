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
    class Warehouse : IList<Item>
    {
        List<Item> innerCollection;
        public bool IsReadOnly { get; }
        public int Count { get; }

        public Item this[int index]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public Warehouse(bool ReadOnlyFlag = false)
        {
            IsReadOnly = ReadOnlyFlag;
            innerCollection = new List<Item>();
            Count = 0;
        }

        public void Add(Item item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Item item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(Item item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, Item item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            
        }

        public void CopyTo(Item[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(Item item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Item> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}