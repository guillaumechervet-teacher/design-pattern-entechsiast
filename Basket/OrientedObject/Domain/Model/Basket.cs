using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.OrientedObject.Domain.Model
{
    public class Basket
    {
        private readonly List<BasketLine2> _basketLine2S;

        public Basket(List<BasketLine2> basketLine2s)
        {
            _basketLine2S = basketLine2s;
        }

        int Calulate()
        {
            var total = 0;
            foreach (var basketLine2 in _basketLine2S)
            {
                total += basketLine2.Calculate();
            }

            return total;
        }

    }

    public class BasketLine2    
    {
        private readonly Article _article;
        private readonly int _number;

        public BasketLine2(Article article, int number)
        {
            _article = article;
            _number = number;
        }

        public int Calculate()
        {
            return _number * _article.Calulate();
        }
    }

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
