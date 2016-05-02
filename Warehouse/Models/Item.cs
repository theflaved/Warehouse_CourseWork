using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Warehouse
{
    [Serializable]
    class Item : IComparable<Item>
    {
        [DisplayName("Наименование")]
        public string Name { get; set; }
        [DisplayName("Колличество")]
        public double Quanity { get; set; }
        [DisplayName("Стоимость за единицу")]
        public ADTUnits Units { get; set; }
        [DisplayName("Общая цена")]
        public double CompletePriceSum => Quanity * Units.Price;
        [DisplayName("Дата последнего изменения")]
        public DateTime LastEntry => ItemLog.Last().LastDate;
        [DisplayName("Последнее изменение в количестве")]
        public double LastQuanityChange => ItemLog.Last().QuanityChange;
        private List<LastEntry> ItemLog { get; }
        public Item(string name, double quanity, ADTUnits units) : this(name,quanity,units,new LastEntry(quanity)) { }
        public Item(string name, double quanity, ADTUnits units, LastEntry le)
        {
            ItemLog = new List<LastEntry>();
            Name = name;
            Quanity = quanity;
            Units = units;
            ItemLog.Add(le);
        }
        public int CompareTo(Item other) => Quanity.CompareTo(other.Quanity);
    }
    [Serializable]
    class LastEntry
    {
        public DateTime LastDate;
        public double QuanityChange;

        public LastEntry(double qChange) : this(qChange, DateTime.Now) { }

        public LastEntry(double qChange, DateTime time)
        {
            QuanityChange = qChange;
            LastDate = time;
        }
    }
}
