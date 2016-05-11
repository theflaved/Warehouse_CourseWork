using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

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
        private List<Item> innerList;
        private ListSortDirection sortDirection;
        [NonSerialized]
        private PropertyDescriptor sortProperty;
        Action<Warehouse, List<Item>>
               populateBaseList = (a, b) => a.ResetItems(b);
        private static Dictionary<string, Func<List<Item>, IEnumerable<Item>>>
            cachedOrderByExpressions = new Dictionary<string, Func<List<Item>, IEnumerable<Item>>>();
        public Warehouse()
        {
            innerList = new List<Item>();
        }
        public Warehouse(IEnumerable<Item> listToClone)
        {
            innerList = listToClone.ToList();
            populateBaseList(this, innerList);
        }
        /// TODO: WHAT DOES THAT PART DO? xD
        #region unknownCode_lol
        protected override void ApplySortCore(PropertyDescriptor prop,
                        ListSortDirection direction)
        {
            sortProperty = prop;

            var orderByMethodName = sortDirection ==
                ListSortDirection.Ascending ? "OrderBy" : "OrderByDescending";
            var cacheKey = typeof(Item).GUID + prop.Name + orderByMethodName;

            if (!cachedOrderByExpressions.ContainsKey(cacheKey))
            {
                CreateOrderByMethod(prop, orderByMethodName, cacheKey);
            }

            ResetItems(cachedOrderByExpressions[cacheKey](innerList).ToList());
            ResetBindings();
            sortDirection = sortDirection == ListSortDirection.Ascending ?
                            ListSortDirection.Descending : ListSortDirection.Ascending;
        }
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
                                                new Expression[] { sourceParameter,
                                                               propertySelectorLambda }),
                                                sourceParameter);

            cachedOrderByExpressions.Add(cacheKey, orderByExpression.Compile());
        }
        protected override void RemoveSortCore()
        {
            ResetItems(innerList);
        }
        private void ResetItems(List<Item> items)
        {

            base.ClearItems();

            for (int i = 0; i < items.Count; i++)
            {
                base.InsertItem(i, items[i]);
            }
        }
        protected override bool SupportsSortingCore
        {
            get
            {
                return true;
            }
        }
        protected override ListSortDirection SortDirectionCore
        {
            get
            {
                return sortDirection;
            }
        }
        protected override PropertyDescriptor SortPropertyCore
        {
            get
            {
                return sortProperty;
            }
        }
        protected override void OnListChanged(ListChangedEventArgs e)
        {
            innerList = base.Items.ToList();
        }
        #endregion
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

        public void AddSetItem(Item searchItem ,Item replaceItem)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].Equals(searchItem))
                {
                    this[i] = replaceItem;
                    return;
                }
            }
            this.Add(replaceItem);
        }
    }
}