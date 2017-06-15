using FluentAssertions;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace DynamicCalculatorTest
{
    [TestFixture]
    public class DynamicCalculatorTest
    {
        private List<dynamic> _orders;
        public DynamicCalculatorTest()
        {
            _orders = new List<dynamic> {
                new
                {
                    Id =1,Cost=1,Revenue=11,SellPrice=21
                },
                 new
                {
                    Id =2,Cost=2,Revenue=12,SellPrice=22
                },
                 new
                {
                    Id =3,Cost=3,Revenue=13,SellPrice=23
                },
                  new
                {
                    Id =4,Cost=4,Revenue=14,SellPrice=24
                },
                   new
                {
                    Id =5,Cost=5,Revenue=15,SellPrice=25
                },
                    new
                {
                    Id =6,Cost=6,Revenue=16,SellPrice=26
                },
                     new
                {
                    Id =7,Cost=7,Revenue=17,SellPrice=27
                },
                      new
                {
                    Id =8,Cost=8,Revenue=18,SellPrice=28
                },
                        new
                {
                    Id =9,Cost=9,Revenue=19,SellPrice=29
                },
                        new
                {
                    Id =10,Cost=10,Revenue=20,SellPrice=30
                },
                        new
                {
                    Id =11,Cost=11,Revenue=21,SellPrice=31
                }
            };
        }

        [Test]
        public void CalculateTest_3筆成一組_取得Cost的總和_預期為_6_15_24_21()
        {
            //arrange
            var target = new DynamicCalculator.DynamicCalculator();
            var expected = new List<int> { 6, 15, 24, 21 };

            //act
            var result = target.Calculate(_orders, 3, o => o.Cost) as List<int>;

            //assert
            result.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void CalculateTest_4筆成一組_取得Revenue的總和_預期為_50_66_60()
        {
            //arrange
            var target = new DynamicCalculator.DynamicCalculator();
            var expected = new List<int> { 50, 66, 60 };

            //act
            var result = target.Calculate(_orders, 4, o => o.Revenue) as List<int>;

            //assert
            result.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void CalculateTest_尋找的欄位若不存在_預期會拋RuntimeBinderException()
        {
            //arrange
            var target = new DynamicCalculator.DynamicCalculator();

            //act
            Action act = () =>
            {
                target.Calculate(_orders, 4, o => o.NotHere);
            };

            //assert 
            act.ShouldThrow<RuntimeBinderException>();
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void CalculateTest_筆數若輸入若小於等於0_則傳回ArgumentException(int divideSize)
        {
            //arrange
            var target = new DynamicCalculator.DynamicCalculator();
            //act
            Action act = () =>
            {
                target.Calculate(_orders, divideSize, o => o.Cost);                   ;
            };

            //assert
            act
                .ShouldThrow<ArgumentException>()
                .WithMessage("divideSize應為大於0之正整數");
        }
    }
}
