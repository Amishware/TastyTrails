using Microsoft.EntityFrameworkCore.Storage;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TastyTrails.API.Business.Interfaces;
using TastyTrails.API.Business.Models.Dtos;
using TastyTrails.API.Business.Models.Requests;
using TastyTrails.API.Business.Services;
using TastyTrails.API.Repositories.Interfaces;
using TastyTrails.API.Repositories.Models;

namespace TastyTrails.API.UnitTests
{
    [TestFixture]
    public class OrderServiceTests
    {
        private Mock<IDbContextTransaction> _dbContextTransactionMock;
        private Mock<ITransactionManager> _transactionManagerMock;
        private Mock<IRestaurantRepository> _restaurantRepositoryMock;
        private Mock<IOrderRepository> _orderRepositoryMock;
        private IOrderService _orderService;

        [SetUp]
        public void Setup()
        {
            _dbContextTransactionMock = new Mock<IDbContextTransaction>();
            _dbContextTransactionMock.Setup(a => a.CommitAsync(It.IsAny<CancellationToken>()));
            _dbContextTransactionMock.Setup(a => a.RollbackAsync(It.IsAny<CancellationToken>()));

            _transactionManagerMock = new Mock<ITransactionManager>();
            _transactionManagerMock.Setup(a => a.BeginTransactionAsync()).ReturnsAsync(_dbContextTransactionMock.Object);
            _transactionManagerMock.Setup(a => a.SaveChangesAsync()).ReturnsAsync(0);


            var restaurant = Helper.CreateRestaurantAndOffer();
            _restaurantRepositoryMock = new Mock<IRestaurantRepository>();
            _restaurantRepositoryMock.Setup(a => a.GetById(It.IsAny<int>())).ReturnsAsync( restaurant );
            _orderRepositoryMock = new Mock<IOrderRepository>();
            _orderRepositoryMock.Setup(a => a.AddOrder(It.IsAny<Order>()));

            _orderService = new OrderService(
                _transactionManagerMock.Object,
                _restaurantRepositoryMock.Object,
                _orderRepositoryMock.Object);
        }

        [Test()]
        public async Task CreateOrderTest()
        {
            var now = DateTimeOffset.UtcNow;
            var status = "Ordered";
            var request = new CreateChannelOrderRequest()
            {
                RestaurantId = 1,
                CustomerId = 1,
                PartnerId = 1,
                OrderItems = new List<OrderItemDto>
                {
                    new OrderItemDto
                    {
                        MenuItemId = 1,
                        Quantity = 1
                    },
                    new OrderItemDto
                    {
                        MenuItemId = 2,
                        Quantity = 2
                    }
                }
            };

            var result = await _orderService.CreateOrder(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(status, result.Status);
            Assert.AreEqual(8d, result.Price);

            Assert.Pass();
        }
    }
}