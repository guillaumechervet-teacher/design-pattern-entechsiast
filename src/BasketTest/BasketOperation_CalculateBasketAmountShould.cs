using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Basket;
using Basket.OrientedObject;
using Basket.OrientedObject.Domain;
using Basket.OrientedObject.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace BasketTest
{
    [TestClass]
    public class BasketOperation_CalculateBasketAmountShould
    {
        public static ArticleDatabase GetArticleDatabaseMock(string id)
        {
            switch (id)
            {
                case "1":
                    return new ArticleDatabase
                    {
                        Id = "1",
                        Price = 1,
                        Stock =
                            35,
                        Label = "Banana",
                        Category = "food"
                    };
                case "2":
                    return new ArticleDatabase
                    {
                        Id = "2",
                        Price = 500,
                        Stock = 20,
                        Label = "Fridge electrolux",
                        Category = "electronic"
                    };
                case "3":
                    return new ArticleDatabase
                    {
                        Id = "3",
                        Price = 49,
                        Stock =
                            68,
                        Label = "Chair",
                        Category = "desktop"
                    };
                default:
                    throw new NotImplementedException();
            }
        }

        public class BasketTest
        {
            public List<BasketLineArticle> BasketLineArticles { get; set; }
            public int ExpectedPrice { get; set; }
        }

        private static IEnumerable<object[]> Baskets
        {
            get
            {
                return new[]
                {
                    new object[]
                    {
                        new BasketTest()
                        {
                            BasketLineArticles = new List<BasketLineArticle>
                            {
                                new BasketLineArticle {Id = "1", Number = 12, Label = "Banana"},
                                new BasketLineArticle
                                {
                                    Id = "2",
                                    Number = 1,
                                    Label = "Fridge electrolux"
                                },
                                new BasketLineArticle
                                {
                                    Id = "3",
                                    Number = 4,
                                    Label = "Chair"
                                }
                            },
                            ExpectedPrice = 84868
                        }
                    },
                    new object[]
                    {
                        new BasketTest()
                        {
                            BasketLineArticles = new List<BasketLineArticle>
                            {
                                new BasketLineArticle {Id = "1", Number = 20, Label = "Banana"},
                                new BasketLineArticle {Id = "3", Number = 6, Label = "Chair"}
                            },
                            ExpectedPrice = 37520
                        }
                    },
                };
            }
        }

        [TestMethod]
        [DynamicData("Baskets")]
        public void ReturnCorrectAmoutGivenBasket(BasketTest basketTest)
        {
            var basKetService = new BasketService();
            var basketOperation = new BasketOperation(basKetService);
            var amountTotal = basketOperation.CalculateAmout(basketTest.BasketLineArticles);
            Assert.AreEqual(amountTotal, basketTest.ExpectedPrice);
        }


    }
}
