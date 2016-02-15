using System.Collections.Generic;
using JuiceCalculator;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestCalculator()
        {
            var c = new Calculator(30, (decimal)0.5, 72, 6, new List<Flavour>() {new Flavour() {Name = "Custard", Percentage = (decimal)0.15}});

            c.Calculate();

            Assert.IsNotEmpty(c.ToString());

            System.Console.WriteLine(c.ToString());
        }
    }
}
