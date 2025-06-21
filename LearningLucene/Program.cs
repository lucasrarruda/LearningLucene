using LearningLucene.Repository;
using LearningLucene.Repository.Interfaces;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers.Classic;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.Util;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        IRepository<string> repository = new LuceneRepository();

        repository.Add("Learning Lucene in C#");

        var results = repository.Search("Lucene");

        foreach (var result in results)
        {
            Console.WriteLine(result);
        }
    }
}
