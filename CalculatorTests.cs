using NUnit.Framework;

namespace Calculator
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void SeedingCalculatorReturnsSeed()
        {
            Assert.That(new Calculator().Seed(10).Result, Is.EqualTo(10));
        }

        [Test]
        public void CalculatorAddsANumber()
        {
            Assert.That(new Calculator().Seed(10).Plus(5).Result, Is.EqualTo(15));
        }

        [Test]
        public void CalculatorSubtractsANumber()
        {
            Assert.That(new Calculator().Seed(10).Minus(5).Result, Is.EqualTo(5));
        }

        [Test]
        public void CalculatorUndoesAddingANumber()
        {
            Assert.That(new Calculator().Seed(10).Plus(5).Undo().Result, Is.EqualTo(10));
        }

        [Test]
        public void CalculatorRedoesAddingANumber()
        {
            Assert.That(new Calculator().Seed(10).Plus(5).Undo().Redo().Result, Is.EqualTo(15));
        }

        [Test]
        public void CalculatorIgnoresUndoAfterSave()
        {
            Assert.That(new Calculator().Seed(10).Plus(5).Save().Undo().Result, Is.EqualTo(15));
        }

        
    }
}