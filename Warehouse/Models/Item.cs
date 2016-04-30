using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    class Item
    {
        public string Name { get; set; }
        public double Quanity { get; set; }
        public ADTUnits Units { get; private set; }
        private List<LastEntry> itemLog { get; }

        public Item(string name, double quanity, ADTUnits units)
        {
            itemLog = new List<LastEntry>();
            Name = name;
            Quanity = quanity;
            Units = units;
            itemLog.Add(new LastEntry(0));

        }

        public Item(string name, double quanity, ADTUnits units, LastEntry le)
        {
            itemLog = new List<LastEntry>();
            Name = name;
            Quanity = quanity;
            Units = units;
            itemLog.Add(le);
        }
    }

    class LastEntry
    {
        public DateTime lastDate;
        public double QuanityChange;

        public LastEntry(double qChange)
        {
            QuanityChange = qChange;
            lastDate = DateTime.Now;
        }

        public LastEntry(double qChange, DateTime time)
        {
            QuanityChange = qChange;
            lastDate = time;
        }
    }
}
