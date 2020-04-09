using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FightClub;

namespace UnitTestFightClub
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDamage()
        {
            //Arrange
            Character c1 = new Character("tester", 1, 10, 1);
            int finalHp = 5;
            //Act
            c1.Damage(5);

            //Assert
            Assert.AreEqual(finalHp, c1.HP);
            
        }
        [TestMethod]
        public void TestHeal()
        {
            //Arrange
            Character c1 = new Character("tester", 1, 10, 1);
            int finalHp = 15;
            //Act
            c1.Heal(5);

            //Assert
            Assert.AreEqual(finalHp, c1.HP);

        }
    }
}
