﻿namespace Basket.OrientedObject.Domain.Model
{
    public class Article
    {
        private readonly int _price;
        private readonly string _category;

        public Article(int price, string category)
        {
            _price = price;
            _category = category;
        }

        public int Calulate()
        {
            var amount = 0;
            var articlePrice = _price;
            switch (_category)
            {
                case "food":
                    amount += articlePrice * 100 + articlePrice * 12;
                    break;
                case "electronic":
                    amount += articlePrice * 100 + articlePrice * 20 + 4;
                    break;
                case "desktop":
                    amount += articlePrice * 100 + articlePrice * 20;
                    break;
            }

            return amount;
        }
    }
}