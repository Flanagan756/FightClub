using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FightClub;


namespace FightClub.Test
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public static void DamageTest()
        {
            //Arrange
            FightClub.MainWindow p1 = new MainWindow();
            //Act
            int actualResult = p1.Damage(5, new Character("tester", 1, 20, 1));
            //Assert
             Assert.That(actualResult, Is.EqualTo(15));

        }
        [Test]
        public static void HealTest()
        {
            //Arrange
            FightClub.MainWindow p2 = new MainWindow();
            //Act
            int actualResult = p2.Heal(10, new Character("tester", 1, 10, 1));
            //Assert
            Assert.That(actualResult, Is.EqualTo(20));
        }

    }
}
