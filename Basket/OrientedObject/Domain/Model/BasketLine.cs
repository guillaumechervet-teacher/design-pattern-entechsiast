namespace Basket.OrientedObject.Domain.Model
{
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
}