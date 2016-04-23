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
            if(!FactDictionary.ContainsKey(Factor)) throw new ArgumentException("Invalid factor");

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


    //TODO: Попробовать enum
    /*    class Weight : INumInSI
        {
            public double Quanity { get; set; }
            public string Factor { get; set; }
            public Dictionary<string, double> FactDictionary { get; set; }

            public Weight(double quanity, string factor)
            {
                Quanity = quanity;
                Factor = factor;

                FactDictionary.Add("т.", 1000); //Тонна
                FactDictionary.Add("ц.", 100); //Центнер
                FactDictionary.Add("кг.", 1); //Килограмм
                FactDictionary.Add("г.", 0.001); //Грамм
                FactDictionary.Add("мг.", 0.000001); //Миллиграмм
            }
            public double GetSINumber()
            {
                return Quanity * FactDictionary[Factor];
            }

            public void SetToFactor(string newFact)
            {
                Quanity = GetSINumber() / FactDictionary[newFact];
                Factor = newFact;
            }
        }

        class Volume : INumInSI
        {
            public double Quanity { get; set; };

        }
        */
}
