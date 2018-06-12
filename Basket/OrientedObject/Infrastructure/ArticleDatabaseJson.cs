using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace Basket.OrientedObject.Infrastructure
{
    public class ArticleDatabaseJson
    {
        public static ArticleDatabase GetArticleFromDatabase(string articleId)
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