using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace Warehouse
{
    //Класс содержащий название,колличество и т.п. характеристики товара на складе
    [Serializable]
    class Item : IComparable<Item>, ICloneable
    {
        private int? _ID;
        [DisplayName("ID")]
        public int? ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        [DisplayName("Наименование")]
        public string Name { get; set; }
        [DisplayName("Колличество")]
        public double Quanity { get; set; }
        [DisplayName("Стоимость за единицу и колличество товара на упаковку")]
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

        //Изменение колличества товара с пометкой по времени в данный момент
        public void InvChangeNow(double qChange)
        {
            ItemLog.Add(new LastEntry(qChange,DateTime.Now));
            if(Quanity + qChange < 0) throw new InvalidDataException("Bad quanity");
            Quanity += qChange;
        }

        //Если идентификатор товара не равен идентификатору другого товара, то объекты не равны
        public override bool Equals(object obj)
        {
            if (obj.GetType() == this.GetType())
            {
                return (((Item) obj).ID == ID);
            }
            return false;
        }

        //Сравнение по колличеству
        public int CompareTo(Item other) => Quanity.CompareTo(other.Quanity);

        //Конструктор клонирования объекта
        public object Clone()
        {
            Item result = new Item(Name, Quanity, Units);
            result.ItemLog.AddRange(ItemLog.AsEnumerable());
            result.ID = ID;
            return result;
        }
    }

    // Класс который содержит информацию о последнем изменении товара
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
