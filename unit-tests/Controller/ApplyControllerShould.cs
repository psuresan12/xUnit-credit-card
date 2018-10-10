using System.Threading.Tasks;
using TestCards.Controllers;
using TestCards.Services;
using TestCards.Models;
using Microsoft.AspNetCore.Mvc;
using TestCards.ViewModels;
using Moq;
using Xunit;

namespace unittests.Controller
{
    public class ApplyControllerShould
    {
        private readonly Mock<ICreditCardData> _mockData;
        private readonly ApplyController _sut;

        public ApplyControllerShould()
        {
            _mockData = new Mock<ICreditCardData>();
            _sut = new ApplyController(_mockData.Object);
        }

        [Fact]
        public void ReturnViewForIndex()
        {
            IActionResult result = _sut.Index();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task ReturnViewWhenInvalidModelState()
        {
            _sut.ModelState.AddModelError("x", "Test Error");

            var application = new NewCreditCardApplicationDetails
            {
                FirstName = "John"
            };

            IActionResult result = await _sut.Index(application);

            ViewResult viewResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsType<NewCreditCardApplicationDetails>(viewResult.Model);

            Assert.Equal(application.FirstName, model.FirstName);


        }

    }
}
