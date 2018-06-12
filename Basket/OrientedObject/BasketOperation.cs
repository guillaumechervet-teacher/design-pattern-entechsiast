using System;
using System.Collections.Generic;
using System.Text;
using Basket.OrientedObject.Domain;

namespace Basket.OrientedObject
{
    public class BasketOperation
    {
        private readonly Infrastructure.BasketService _basketService;

        public BasketOperation(Infrastructure.BasketService basketService)
        {
            _basketService = basketService;
        }

        public int CalculateAmout(List<BasketLineArticle> basketLineArticles)
        {
            var basket = _basketService.GetBasket(basketLineArticles);
            return basket.Calculate();
        }
    }
}
