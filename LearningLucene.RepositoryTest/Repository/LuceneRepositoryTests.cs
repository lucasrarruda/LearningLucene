using Moq;
using System;
using Xunit;
using LearningLucene.Repository;

namespace LearningLucene.RepositoryTest.Repository
{
    public class LuceneRepositoryTests
    {
        private MockRepository _mockRepository;

        public LuceneRepositoryTests()
        {
            this._mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private LuceneRepository CreateLuceneRepository()
        {
            return new LuceneRepository();
        }

        [Fact]
        public void Add_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var luceneRepository = this.CreateLuceneRepository();
            string entity = null;

            // Act
            luceneRepository.Add(
                entity);

            // Assert
            Assert.True(false);
            this._mockRepository.VerifyAll();
        }

        [Fact]
        public void Update_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var luceneRepository = this.CreateLuceneRepository();
            string entity = null;

            // Act
            luceneRepository.Update(
                entity);

            // Assert
            Assert.True(false);
            this._mockRepository.VerifyAll();
        }

        [Fact]
        public void Delete_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var luceneRepository = this.CreateLuceneRepository();
            string entity = null;

            // Act
            luceneRepository.Delete(
                entity);

            // Assert
            Assert.True(false);
            this._mockRepository.VerifyAll();
        }

        [Fact]
        public void Search_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var luceneRepository = this.CreateLuceneRepository();
            string query = null;
            int maxResults = 0;

            // Act
            var result = luceneRepository.Search(
                query,
                maxResults);

            // Assert
            Assert.True(false);
            this._mockRepository.VerifyAll();
        }
    }
}
