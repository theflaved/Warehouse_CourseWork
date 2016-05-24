using System;
using System.Collections.Generic;

namespace Warehouse
{
    //Интерфейс содержащий информацию о единицах измерения и цене единицы товара и класс, который реализует его 
    public interface INumInSI
    {
        //Колличество
        double Quanity { get; set; }
        //Приставка которая сигнализует о размерности
        string Factor { get; set; }
        //Словарь приставок и их множителей
        Dictionary<string, double> FactDictionary { get; set; }
        //Метод возвращающий номер в единцах измерения СИ
        double GetSINumber();
    }
    [Serializable]
    abstract class ADTUnits : INumInSI, IComparable<ADTUnits>
    {
        public double Quanity { get; set; }
        public string Factor
        {
            get { return _factor; }
            set
            {
                if(FactDictionary.ContainsKey(value)) throw new ArgumentException("Invalid factor");
                _factor = value;
            }
        }
        private string _factor;
        public Dictionary<string, double> FactDictionary { get; set; }
        public double Price { get; set; }
        public virtual double GetSINumber()
        {
            return Quanity * FactDictionary[Factor];
        }
        public virtual void SetToFactor(string newFact)
        {
            Quanity = GetSINumber() / FactDictionary[newFact];
            Factor = newFact;
        }
        public override string ToString()
        {
            return (Price + " грн./" + Quanity + " " + Factor);
        }
        public virtual int CompareTo(ADTUnits other)
        {
            return Price.CompareTo(other.Price);
        }
    }
    //Вес
    [Serializable]
    sealed class Weight : ADTUnits
    {
        public Weight(double price, double quanity, string factor)
        {
            FactDictionary = new Dictionary<string, double>();
            Quanity = quanity;
            Factor = factor;
            Price = price;

            FactDictionary.Add("т.", 1000); //Тонна
            FactDictionary.Add("ц.", 100); //Центнер
            FactDictionary.Add("кг.", 1); //Килограмм
            FactDictionary.Add("г.", 0.001); //Грамм
            FactDictionary.Add("мг.", 0.000001); //Миллиграмм

            if (!FactDictionary.ContainsKey(Factor)) throw new ArgumentException("Invalid factor");
        }
    }
    //Объем
    [Serializable]
    sealed class Volume : ADTUnits
    {
        public Volume(double price, double quanity, string factor)
        {
            FactDictionary = new Dictionary<string, double>();
            Quanity = quanity;
            Factor = factor;
            Price = price;

            FactDictionary.Add("л.", 1); //Литр
            FactDictionary.Add("мл.", 0.001); //Грамм
            FactDictionary.Add("мг.", 0.000001); //Миллиграмм

            if (!FactDictionary.ContainsKey(Factor)) throw new ArgumentException("Invalid factor");
        }
    }
    //Количество
    [Serializable]
    sealed class UnitsOnly : ADTUnits
    {
        public UnitsOnly(double price, double quanity)
        {
            FactDictionary = new Dictionary<string, double>();
            Quanity = quanity;
            Factor = "шт.";
            Price = price;
        }
        public override double GetSINumber() => Quanity;

        public override void SetToFactor(string newFact)
        {
            throw new InvalidOperationException();
        }
    }
}
