using System.Collections.Generic;
using System.Linq;

namespace JuiceCalculator
{
    public class Calculator
    {
        private const decimal One = (decimal) 1.0;

        private readonly decimal _amountToMake;

        private readonly decimal _targetVgPercentage;
        private readonly decimal _targetPgPercentage;

        private readonly decimal _nicContent;
        
        private readonly decimal _targetNic;
        private decimal _totalTargetFlavourPercentage;
        
        public decimal Vg { get; private set; }
        public decimal Pg { get; private set; }
        public decimal Nic { get; private set; }
        public List<Flavour> Flavours { get; private set; }

        public Calculator(decimal amountToMake, decimal targetVgPercentage, decimal nicContent, decimal targetNic, List<Flavour> flavours)
        {
            _amountToMake = amountToMake;
            _targetVgPercentage = targetVgPercentage;
            _nicContent = nicContent;
            _targetNic = targetNic;
            
            Flavours = flavours;

            _targetPgPercentage = One - _targetVgPercentage;
        }

        public void Calculate()
        {
            _totalTargetFlavourPercentage = GetTotalFlavourPercentage();

            //work out nic
            Nic = (_targetNic*_amountToMake)/_nicContent;

            var amountLeft = _amountToMake - Vg - Nic;

            foreach (var flavour in Flavours)
            {
            }

            Vg = _amountToMake * _targetVgPercentage;

            

            

            var totalPg = _amountToMake * _targetPgPercentage;

            Pg = totalPg - Nic - (totalPg * _totalTargetFlavourPercentage);
        }

        public override string ToString()
        {
            var outputString = string.Format("Vg: {0} Pg: {1} Nic: {2} ", Vg, Pg, Nic);
            outputString += Flavours.Aggregate(outputString, (current, f) => current + string.Format("Flavour: {0} Volume: {1} ", f.Name, f.Amount));
            outputString = outputString.Substring(0, outputString.Length - 1);

            return outputString;
        }

        private decimal GetTotalFlavourPercentage()
        {
            return Flavours.Sum(f => f.Percentage);
        }
    }

    public class Flavour
    {
        public string Name { get; set; }
        public decimal Percentage { get; set; }
        public decimal Amount { get; set; }
    }
}
