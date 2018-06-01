using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.OrientedObject.Domain.Model
{
    public class Basket
    {
        private readonly List<BasketLine> _basketLine;

        public Basket(List<BasketLine> basketLine)
        {
            _basketLine = basketLine;
        }

        public int Calculate()
        {
            var total = 0;
            foreach (var basketLine2 in _basketLine)
            {
                total += basketLine2.Calculate();
            }

            return total;
        }

    }
}
