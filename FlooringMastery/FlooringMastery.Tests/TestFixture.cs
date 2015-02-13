using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FlooringMaster.Data;

namespace FlooringMastery.Tests
{
    [TestFixture]
    class TestFixture
    {
        
        //[TestCase("06012013","File was loaded successfully.", TestName = "ExistingFile")]
        //[TestCase("12071942", "A new order file was created for that date.", TestName = "NewFile")]
        //public void TestLoadOrdersFromFile(string date, string expected)
        //{
        //    TestOrders myTest = new TestOrders();
        //    string result = myTest.LoadOrderFile(date);

        //    Assert.AreEqual(expected, result);
        //}

        //[TestCase("badger", @"..\..\..\Documents\Orders_badger.txt", TestName = "Filename")]
        //[TestCase("badger.txt", @"..\..\..\Documents\Orders_badger.txt", TestName = "Filename.Extension")]
        //[TestCase(@"..\..\..\Documents\Orders_badger.txt", @"..\..\..\Documents\Orders_badger.txt", TestName = "Fullpath")]
        //public void TestFileNameBuilder(string input, string expected)
        //{
        //    string result = TestOrders.FileNameBuilder(input);

        //    Assert.AreEqual(expected, result);
        //}

        [TestCase("foobar", "foobar", TestName = "none")]
        [TestCase("foo bar", "foobar", TestName = "one")]
        [TestCase("f o o b a r ", "foobar", TestName = "many")]
        public void TestStripSpaces(string input, string expected)
        {
            string result = TestStates.StripSpaces(input);

            Assert.AreEqual(expected, result);
        }
    }
}
