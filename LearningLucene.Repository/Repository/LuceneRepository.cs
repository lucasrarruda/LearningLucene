using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.QueryParsers.Classic;
using Lucene.Net.Util;
using LearningLucene.Repository.Interfaces;
using Lucene.Net.Analysis;
using System;
using static Lucene.Net.Util.Packed.PackedInt32s;
using static Lucene.Net.Util.PagedBytes;
using System.IO;


namespace LearningLucene.Repository
{
    public class LuceneRepository : IRepository<string>
    {
        private StandardAnalyzer? _analyzer;
        private readonly FSDirectory _directory;

        public LuceneRepository()
        {
            _directory = CreateDirectory("repository");
            CreateAnalyzers();
        }

        #region Public Methods

        public void Add(string entity)
        {
            var config = new IndexWriterConfig(LuceneVersion.LUCENE_48, _analyzer);
            using var indexWriter = new IndexWriter(_directory, config);

            var doc = new Document
            {
                new TextField("title", "Learning Lucene in C#", Field.Store.YES),
                new TextField("content", "Lucene.NET 3.0 able optimized search query.", Field.Store.YES)
            };

            indexWriter?.AddDocument(doc);
            indexWriter?.Commit();
        }

        public void Update(string entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string entity)
        {
            var config = new IndexWriterConfig(LuceneVersion.LUCENE_48, _analyzer);
            using var writer = new IndexWriter(_directory, config);

            writer.DeleteDocuments(new Term("Id", entity));
            writer.Commit();
        }

        public IEnumerable<string> Search(string query, int maxResults = 10)
        {
            using var reader = DirectoryReader.Open(_directory);
            var indexSearcher = new IndexSearcher(reader);

            var parser = new MultiFieldQueryParser(LuceneVersion.LUCENE_48, new[] { "title", "content" }, _analyzer);
            //QueryParser parser = new QueryParser(LuceneVersion.LUCENE_48, "content", _analyzer);
            Query searchQuery = parser.Parse(query);

            TopDocs result = indexSearcher?.Search(searchQuery, maxResults) ?? throw new InvalidOperationException("IndexSearcher is not initialized.");

            foreach (var scoreDoc in result.ScoreDocs)
            {
                var doc = indexSearcher.Doc(scoreDoc.Doc);
                yield return doc.Get("content") ?? string.Empty;
            }
        }
        #endregion

        #region Private Methods
        private static FSDirectory CreateDirectory(string path)
        {
            string indexPath = Path.Combine(AppContext.BaseDirectory, path);

            if (!System.IO.Directory.Exists(indexPath))
                System.IO.Directory.CreateDirectory(indexPath);

            var directory = FSDirectory.Open(indexPath);
            return directory;
        }

        private void CreateAnalyzers()
        {
            _analyzer = new StandardAnalyzer(LuceneVersion.LUCENE_48);
        }
        #endregion
    }
}
