using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    [Serializable]
    class Item : IComparable<Item>
    {
        public string Name { get; set; }
        public double Quanity { get; set; }
        public ADTUnits Units { get; private set; }
        private List<LastEntry> itemLog { get; }

        public Item(string name, double quanity, ADTUnits units) : this(name,quanity,units,new LastEntry(quanity)) { }

        public Item(string name, double quanity, ADTUnits units, LastEntry le)
        {
            itemLog = new List<LastEntry>();
            Name = name;
            Quanity = quanity;
            Units = units;
            itemLog.Add(le);
        }

        public int CompareTo(Item other)
        {
            return Name.CompareTo(other.Name);
        }
    }
    [Serializable]
    class LastEntry
    {
        public DateTime lastDate;
        public double QuanityChange;

        public LastEntry(double qChange) : this(qChange, DateTime.Now) { }

        public LastEntry(double qChange, DateTime time)
        {
            QuanityChange = qChange;
            lastDate = time;
        }
    }

//    public class NameComparer : IComparer<Item>
//    {
        
//    }
}
