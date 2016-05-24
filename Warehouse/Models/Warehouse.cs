using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Warehouse.Annotations;

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
        //Счетчик для уникальных идентификаторов в коллекции
        public int _idCounter { get; private set; }
        //Оригинальный (не сортированый)
        private List<Item> innerList;
        //Направление сортировки
        private ListSortDirection sortDirection;
        //Событие изменения коллекции
        public delegate void CollectionChanged();
        public event CollectionChanged OnCollectionChange;
        //Поле, которое описывает название поля по которому в данный момент осуществляется сортировка
        [NonSerialized] private PropertyDescriptor sortProperty;

        //Сброс режима сортировки
        Action<Warehouse, List<Item>>
            populateBaseList = (a, b) => a.ResetItems(b);

        //Словарь методов для сортировки списка, при отсутствии в нем методя для подходящего свойства создается новый и сохраняется в этом словаре
        private static Dictionary<string, Func<List<Item>, IEnumerable<Item>>>
            cachedOrderByExpressions = new Dictionary<string, Func<List<Item>, IEnumerable<Item>>>();

        public Warehouse()
        {
            innerList = new List<Item>();
            _idCounter = 0;
        }

        public Warehouse(int idCounter) : this()
        {
            _idCounter = idCounter;
        }

        public Warehouse(IEnumerable<Item> listToClone)
        {
            innerList = listToClone.ToList();
            populateBaseList(this, innerList);
            _idCounter = 0;
        }

        public Warehouse(IEnumerable<Item> listToClone, int idCounter) : this(listToClone)
        {
            _idCounter = idCounter;
        }

        //Имплементация методов для сортируемого списка типа BindingList
        protected override void ApplySortCore(PropertyDescriptor prop,
            ListSortDirection direction)
        {
            sortProperty = prop;

            var orderByMethodName = sortDirection ==
                                    ListSortDirection.Ascending
                ? "OrderBy"
                : "OrderByDescending";
            var cacheKey = typeof(Item).GUID + prop.Name + orderByMethodName;

            if (!cachedOrderByExpressions.ContainsKey(cacheKey))
            {
                CreateOrderByMethod(prop, orderByMethodName, cacheKey);
            }

            ResetItems(cachedOrderByExpressions[cacheKey](innerList).ToList());
            ResetBindings();
            sortDirection = sortDirection == ListSortDirection.Ascending
                ? ListSortDirection.Descending
                : ListSortDirection.Ascending;
        }

        //Создание метода сортировки для определенного поля
        private void CreateOrderByMethod(PropertyDescriptor prop,
            string orderByMethodName, string cacheKey)
        {
            var sourceParameter = Expression.Parameter(typeof(List<Item>), "source");
            var lambdaParameter = Expression.Parameter(typeof(Item), "lambdaParameter");
            var accesedMember = typeof(Item).GetProperty(prop.Name);
            var propertySelectorLambda =
                Expression.Lambda(Expression.MakeMemberAccess(lambdaParameter,
                    accesedMember), lambdaParameter);
            var orderByMethod = typeof(Enumerable).GetMethods()
                .Where(a => a.Name == orderByMethodName &&
                            a.GetParameters().Length == 2)
                .Single()
                .MakeGenericMethod(typeof(Item), prop.PropertyType);

            var orderByExpression = Expression.Lambda<Func<List<Item>, IEnumerable<Item>>>(
                Expression.Call(orderByMethod,
                    new Expression[]
                    {
                        sourceParameter,
                        propertySelectorLambda
                    }),
                sourceParameter);

            cachedOrderByExpressions.Add(cacheKey, orderByExpression.Compile());
        }

        //Сброс сортировки
        protected override void RemoveSortCore()
        {
            ResetItems(innerList);
        }

        //Сброс сортировки с заменой
        private void ResetItems(List<Item> items)
        {

            base.ClearItems();

            for (int i = 0; i < items.Count; i++)
            {
                base.InsertItem(i, items[i]);
            }
        }

        //Сигнализация того, что список поддерживает сортировку
        protected override bool SupportsSortingCore
        {
            get { return true; }
        }

        //Направление сортировки
        protected override ListSortDirection SortDirectionCore
        {
            get { return sortDirection; }
        }

        //Свойство по которому в данный момент осуществляется сортировка
        protected override PropertyDescriptor SortPropertyCore
        {
            get { return sortProperty; }
        }

        //Добавление с заменой или без по уникальному идентификатору
        public void AddWithID(Item item, bool replaceFlag = false)
        {
            if (item.ID == null)
            {
                item.ID = ++_idCounter;
                Add(item);
            }
            else
            {
                if (Contains(item) && replaceFlag) this[IndexOfID(item)] = item;
                else
                {
                    //item.ID = ++_idCounter;
                    Add(item);
                }
            }
            OnCollectionChange?.Invoke();
        }

        //Глубокое копирование списка
        public object Clone()
        {
            Warehouse result = new Warehouse();
            foreach (Item item in this)
            {
                result.Add(item);
            }
            return result;
        }

        //Метод для проверки наличия определенного элемента в списке
        public new bool Contains(Item item)
        {
            foreach (Item itemCol in this)
            {
                if (item.ID == itemCol.ID) return true;
            }
            return false;
        }

        //Метод для поиска индекса определнного элемента в списке
        public int IndexOfID(Item item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i].ID == item.ID) return i;
            }
            return -1;
        }

        //Метод удаления из списка и дальнейшая сигнализация о изменении в списке
        public new void Remove(Item item)
        {
            base.Remove(item);
            OnCollectionChange?.Invoke();
        }

    }
}