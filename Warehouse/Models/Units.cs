using System;
using System.Collections.Generic;

namespace Warehouse
{
    public interface INumInSI
    {
        double Quanity { get; set; }
        string Factor { get; set; }
        Dictionary<string, double> FactDictionary { get; set; }
        double GetSINumber();
    }

    abstract class ADTUnits : INumInSI
    {
        public virtual double Quanity { get; set; }
        public virtual string Factor { get; set; }
        public virtual Dictionary<string, double> FactDictionary { get; set; }
        public virtual double GetSINumber()
        {
            return Quanity * FactDictionary[Factor];
        }
        public virtual void SetToFactor(string newFact)
        {
            Quanity = GetSINumber() / FactDictionary[newFact];
            Factor = newFact;
        }
    }

    sealed class Weight : ADTUnits
    {
        public Weight(double quanity, string factor)
        {
            Quanity = quanity;
            Factor = factor;
            if (!FactDictionary.ContainsKey(Factor)) throw new ArgumentException("Invalid factor");

            FactDictionary.Add("т.", 1000); //Тонна
            FactDictionary.Add("ц.", 100); //Центнер
            FactDictionary.Add("кг.", 1); //Килограмм
            FactDictionary.Add("г.", 0.001); //Грамм
            FactDictionary.Add("мг.", 0.000001); //Миллиграмм
        }
    }

    sealed class Volume : ADTUnits
    {
        public Volume(double quanity, string factor)
        {
            Quanity = quanity;
            Factor = factor;
            if (!FactDictionary.ContainsKey(Factor)) throw new ArgumentException("Invalid factor");

            FactDictionary.Add("т.", 1000); //Тонна
            FactDictionary.Add("ц.", 100); //Центнер
            FactDictionary.Add("л.", 1); //Литр
            FactDictionary.Add("мл.", 0.001); //Грамм
            FactDictionary.Add("мг.", 0.000001); //Миллиграмм
        }
    }

    sealed class UnitsOnly : ADTUnits
    {
        public UnitsOnly(double quanity)
        {
            Quanity = quanity;
            Factor = "шт.";
        }
        public override double GetSINumber() => Quanity;

        public override void SetToFactor(string newFact)
        {
            throw new InvalidOperationException();
        }
    }
}
