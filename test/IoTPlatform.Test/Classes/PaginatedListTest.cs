using Xunit;
using Allure.Xunit.Attributes;
using IoTPlatform.Classes;

#pragma warning disable CS1998

namespace IoTPlatform.Test.Classes
{
    public class PaginatedListTest
    {
        [Fact(DisplayName = "GetListPage")]
        [AllureDescription("Проверка получения страницы списка по ее номеру с указанием списка и размера страницы")]
        public async Task GetListPage()
        {
            // Arrange
            var list = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20
            };
            var expectedResult = new List<int>()
            {
                1, 2, 3, 4, 5
            };

            // Act
            var actualResult = PaginatedList<int>.GetListPage(list, pageSize: 5, pageNumber: 0);

            //Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact(DisplayName = "GetListPageOutOfRange")]
        [AllureDescription("Проверка получения ArgumentOutOfRangeException")]
        public async Task GetListPageOutOfRange()
        {
            // Arrange
            var list = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20
            };
            var expectedResult = new List<int>();

            // Act

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => PaginatedList<int>.GetListPage(list, pageSize: 5, pageNumber: 10));
            Assert.Throws<ArgumentOutOfRangeException>(() => PaginatedList<int>.GetListPage(list, pageSize: -1, pageNumber: 2));
            Assert.Throws<ArgumentOutOfRangeException>(() => PaginatedList<int>.GetListPage(list, pageSize: 0, pageNumber: 10));
            Assert.Throws<ArgumentOutOfRangeException>(() => PaginatedList<int>.GetListPage(list, pageSize: 5, pageNumber: -1));
        }

        [Fact(DisplayName = "GetListPageByPageNumber")]
        [AllureDescription("Проверка получения страницы списка по ее номеру")]
        public async Task GetListPageByPageNumber()
        {
            // Arrange
            var list = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20
            };
            var paginatedlist = new PaginatedList<int>(list, pageSize: 5);
            var expectedResult = new List<int>()
            {
                1, 2, 3, 4, 5
            };

            // Act
            var actualResult = paginatedlist.GetListPage(0);

            //Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact(DisplayName = "GetListPageByPageNumberOutOfRangeException")]
        [AllureDescription("Проверка получения ArgumentOutOfRangeException")]
        public async Task GetListPageByPageNumberOutOfRangeException()
        {
            // Arrange
            var list = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20
            };
            var paginatedlist = new PaginatedList<int>(list, pageSize: 5);

            // Act

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => paginatedlist.GetListPage(10));
            Assert.Throws<ArgumentOutOfRangeException>(() => paginatedlist.GetListPage(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => new PaginatedList<int>(list, pageSize: 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => new PaginatedList<int>(list, pageSize: -1));
        }
    }
}