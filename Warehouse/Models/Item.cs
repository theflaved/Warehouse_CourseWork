using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    class Item
    {
        public double Quanity;
        public ADTUnits Units;
        private List<LastEntry> itemLog;

        public Item(double quanity, ADTUnits units)
        {
            Quanity = quanity;
            Units = units;
            itemLog.Add(new LastEntry(0));

        }

        public Item(double quanity, ADTUnits units, LastEntry le)
        {
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
