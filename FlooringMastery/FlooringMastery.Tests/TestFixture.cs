using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using NUnit.Framework;
using FlooringMaster.Data;
using FlooringMastery.BLL;
using FlooringMastery.Models;
using FlooringMastery.UI;

namespace FlooringMastery.Tests
{
    [TestFixture]
    internal class TestFixture
    {

        [TestCase(1, "IA")]
        [TestCase(3, "ND")]
        [TestCase(4, "SD")]
        public void TestGetStates(int i, string expected)
        {
            TestStates myTestRepo = new TestStates();
            List<State> result = myTestRepo.GetStates();
            string stateAbbrev = result[i].StateAbbreviation;

            Assert.AreEqual(expected, stateAbbrev);
        }


        [TestCase(1, "Laminate")]
        [TestCase(2, "Tile")]
        [TestCase(3, "Wood")]
        public void TestGetProducts(int i, string expected)
        {
            TestProducts myTestRepo = new TestProducts();
            List<Product> result = myTestRepo.GetProducts();
            string productName = result[i].ProductType;

            Assert.AreEqual(expected, productName);
        }


        [TestCase(0, "Walter White")]
        [TestCase(1, "Saul Goodman")]
        [TestCase(2, "Jessie Pinkman")]
        public void TestGetOrders(int i, string expected)
        {
            TestOrders myTestRepo = new TestOrders();
            var result = myTestRepo.LoadOrders(DateTime.Now);
            string customerName = result[i].CustomerName;

            Assert.AreEqual(expected, customerName);
        }


        [TestCase(0, "Walter White")]
        [TestCase(1, "Saul Goodman")]
        [TestCase(2, "Jessie Pinkman")]
        public void TestSaveOrders(int i, string expected)
        {
            TestOrders myTestRepo = new TestOrders();
            myTestRepo.SaveOrdersToFile(DateTime.Now, myTestRepo.LoadOrders(DateTime.Now));

            Assert.AreEqual(myTestRepo.FakeDB[i].CustomerName, expected);
        }

       [Test]
        public void TestCloneOrder()
        {
            Order newOrder = new Order();
            newOrder.CustomerName = "Mr. Test";
            newOrder.Area = 420;
            newOrder.ProductType = "Test Material";

            var result = Manipulation.CloneOrder(newOrder);

        //public void Go(var str, var expected)
        //{
        //    Output Homescreen = new Output();
        //    var result = new HomeScreen;
        //    Assert.AreEqual(result, expected);
        //}

        /// <summary>
        /// Test Calculation.DateToFileName(DateTime fileDate)
        /// </summary>
        /// <param name="myDateTime"></param>
        /// <param name="expected"></param>
        /// <returns></returns>
        [TestCase("06/01/2013", true)]
        [TestCase("09/20/2016", false)]
        public void Validate_DoesOrderFileExist(string myDateTime, bool expected)
        {
            DateTime testDate = DateTime.Parse(myDateTime);
            bool result = Calculation.DoesOrderFileExist(testDate);
            Assert.AreEqual(expected, result);
        }


        /// <summary>
        /// Test Calculation.DateToFileName(DateTime fileDate)
        /// </summary>
        /// <param name="fileDate"></param>
        /// <returns></returns>
        [TestCase("03/15/2014", "Orders_03152014.txt")]
        [TestCase("07/01/2015", "Orders_07012015.txt")]
        [TestCase("04/20/2013", "Orders_04202013.txt")]
        public void Validate_DateToFileName(string fileDate, string expected)
        {
            DateTime testDate = DateTime.Parse(fileDate);
            string result = Calculation.DateToFileName(testDate);
            Assert.AreEqual(expected, result);
        }


        [TestCase("06/01/2013", 1, 2]
        public void Validate_GetAllOrderNumbers(string orderDateTime, int expected, int expected)
        {
            DateTime testDate = DateTime.Parse(orderDateTime);
            List<int> result = Calculation.GetAllOrderNumbers(testDate);
            Assert.AreEqual(expected, result);
        }}

            Assert.AreEqual(newOrder.CustomerName, result.CustomerName);
            Assert.AreEqual(newOrder.Area, result.Area);
            Assert.AreEqual(newOrder.ProductType, result.ProductType);
        }

    }
}
