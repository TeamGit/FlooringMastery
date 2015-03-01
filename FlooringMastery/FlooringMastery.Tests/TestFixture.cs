﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FlooringMaster.Data;
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


        //[TestCase(" ", "Press enter to continue")]
        //public void PauseForReading(string str, string expected)
        //{
        //    //Output readingTest = new Output;
        //    string result = PauseForReading(str);
        //        Assert.AreEqual(result, expected);
        //}

        //public void Go(var str, var expected)
        //{
        //    Output Homescreen = new Output();
        //    var result = new HomeScreen;
        //    Assert.AreEqual(result, expected);
        //}
    }
}
