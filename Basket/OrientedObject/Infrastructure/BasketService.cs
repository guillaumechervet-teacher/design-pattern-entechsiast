using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Basket;
using Basket.OrientedObject.Domain;
using Basket.OrientedObject.Domain.Model;
using Newtonsoft.Json;


namespace Basket.OrientedObject.Infrastructure
{
    public class BasketService
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

        public Domain.Model.Basket GetBasket(IList<BasketLineArticle> basketLineArticles)
        {

            var list = new List<Domain.Model.BasketLine>();
            foreach (var basketLineArticle in basketLineArticles)
            {
                var articleId = basketLineArticle.Id;
                var articleDatabase = GetFromDatabase(articleId);
                list.Add(new BasketLine(new Article(articleDatabase.Price, articleDatabase.Category),basketLineArticle.Number));

            }

            return new Domain.Model.Basket(list); 
        }


        private static ArticleDatabase GetFromDatabase(string articleId)
        {
            // Retreive article from database
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            var assemblyDirectory = Path.GetDirectoryName(path);
            //TODO : Pourquoi aller récupérer l'assembly path pour trouver le fichier json ? récupérer dynamiquement le chemin du fichier si on change d'assembly ?
            var jsonPath = Path.Combine(assemblyDirectory, "article-database.json");
            IList<ArticleDatabase> articleDatabases = JsonConvert.DeserializeObject<List<ArticleDatabase>>(File.ReadAllText(jsonPath));
            var article = articleDatabases.First(articleDatabase => articleDatabase.Id == articleId);
            return article;
        }
    }
}
