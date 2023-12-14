using Allure.Xunit.Attributes;

namespace IoTPlatform.Test.Classes
{
    public class PaginatedListTest
    {
        [Fact(DisplayName = "GetListPage")]
        [AllureDescription("Проверка получения страницы списка по ее номеру с указанием списка и размера страницы")]
        public async Task GetListPage()
        {
            // Arrange

            // Act

            //Assert
            Assert.True(true);
        }

        [Fact(DisplayName = "GetListPageByPageNumber")]
        [AllureDescription("Проверка получения страницы списка по ее номеру")]
        public async Task GetListPageByPageNumber()
        {
            // Arrange

            // Act

            //Assert
            Assert.True(true);
        }
    }
}