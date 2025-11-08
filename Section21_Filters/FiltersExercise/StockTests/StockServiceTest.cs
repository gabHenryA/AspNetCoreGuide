using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceContracts.DTO;
using ServiceContracts;
using Services;
using Xunit.Abstractions;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace StockTests
{
    public class StockServiceTest
    {
        private readonly IStockService _stockService;
        private readonly ITestOutputHelper _testOutputHelper;

        public StockServiceTest(ITestOutputHelper testOutputHelper)
        {
            _stockService = new StockService(null); //to fix
            _testOutputHelper = testOutputHelper;
        }

        #region CreateBuyOrder

        [Fact]
        public async Task CreateBuyOrder_BuyOrderIsNull()
        {
            //Arrange
            BuyOrderRequest? request = null;

            //Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                //Act
                await _stockService.CreateBuyOrder(request);
            });
        }

        [Fact]
        public async Task CreateBuyOrder_QuantityAsZero()
        {
            //Arrange
            BuyOrderRequest? request = new BuyOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft Corporation",
                DateAndTimeOfOrder = DateTime.Parse("2002-06-25"),
                Quantity = 0,
                Price = 20
            };

            //Assert
            await Assert.ThrowsAsync<ArgumentException>(async() =>
            {
                //Act
                await _stockService.CreateBuyOrder(request);
            });
        }

        [Fact]
        public async Task CreateBuyOrder_QuantityAs100001()
        {
            //Arrange
            BuyOrderRequest? request = new BuyOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft Corporation",
                DateAndTimeOfOrder = DateTime.Parse("2002-06-25"),
                Quantity = 100001,
                Price = 20
            };

            //Assert
            await Assert.ThrowsAsync<ArgumentException>(async() =>
            {
                //Act
                await _stockService.CreateBuyOrder(request);
            });
        }

        [Fact]
        public async Task CreateBuyOrder_OrderPriceAsZero()
        {
            //Arrange
            BuyOrderRequest? request = new BuyOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft Corporation",
                DateAndTimeOfOrder = DateTime.Parse("2002-06-25"),
                Quantity = 12,
                Price = 0
            };

            //Assert
            await Assert.ThrowsAsync<ArgumentException>(async() =>
            {
                //Act
                await _stockService.CreateBuyOrder(request);
            });
        }

        [Fact]
        public async Task CreateBuyOrder_OrderPriceAs10001()
        {
            //Arrange
            BuyOrderRequest? request = new BuyOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft Corporation",
                DateAndTimeOfOrder = DateTime.Parse("2002-06-25"),
                Quantity = 12,
                Price = 10001
            };

            //Assert
            await Assert.ThrowsAsync<ArgumentException>(async() =>
            {
                //Act
                await _stockService.CreateBuyOrder(request);
            });
        }

        [Fact]
        public async Task CreateBuyOrder_StockSymbolIsNull()
        {
            //Arrange
            BuyOrderRequest? request = new BuyOrderRequest()
            {
                StockSymbol = null,
                StockName = "Microsoft Corporation",
                DateAndTimeOfOrder = DateTime.Parse("2002-06-25"),
                Quantity = 12,
                Price = 20
            };

            //Assert
            await Assert.ThrowsAsync<ArgumentException>(async() =>
            {
                //Act
                await _stockService.CreateBuyOrder(request);
            });
        }

        [Fact]
        public async Task CreateBuyOrder_DateAndTimeOfOrderTooOld()
        {
            //Arrange
            BuyOrderRequest? request = new BuyOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft Corporation",
                DateAndTimeOfOrder = DateTime.Parse("1970-06-25"),
                Quantity = 12,
                Price = 20
            };

            //Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                //Act
                BuyOrderResponse response = await _stockService.CreateBuyOrder(request);
                _testOutputHelper.WriteLine(response.ToString());
            });
        }

        [Fact]
        public async Task CreateBuyOrder_Details()
        {
            //Arrange
            BuyOrderRequest? request = new BuyOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft Corporation",
                DateAndTimeOfOrder = DateTime.Parse("2002-06-25"),
                Quantity = 12,
                Price = 20
            };

            //Act
            BuyOrderResponse? response = await _stockService.CreateBuyOrder(request);

            //Assert
            Assert.NotEqual(Guid.Empty, response.BuyOrderID);
        }

        #endregion

        #region CreateSellOrder

        [Fact]
        public async Task CreateSellOrder_BuyOrderIsNull()
        {
            //Arrange
            SellOrderRequest? request = null;

            //Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async() =>
            {
                //Act
                await _stockService.CreateSellOrder(request);
            });
        }

        [Fact]
        public async Task CreateSellOrder_QuantityAsZero()
        {
            //Arrange
            SellOrderRequest? request = new SellOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft Corporation",
                DateAndTimeOfOrder = DateTime.Parse("2002-06-25"),
                Quantity = 0,
                Price = 20
            };

            //Assert
            await Assert.ThrowsAsync<ArgumentException>(async() =>
            {
                //Act
                await _stockService.CreateSellOrder(request);
            });
        }

        [Fact]
        public async Task CreateSellOrder_QuantityAs100001()
        {
            //Arrange
            SellOrderRequest? request = new SellOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft Corporation",
                DateAndTimeOfOrder = DateTime.Parse("2002-06-25"),
                Quantity = 100001,
                Price = 20
            };

            //Assert
            await Assert.ThrowsAsync<ArgumentException>(async() =>
            {
                //Act
                await _stockService.CreateSellOrder(request);
            });
        }

        [Fact]
        public async Task CreateSellOrder_OrderPriceAsZero()
        {
            //Arrange
            SellOrderRequest? request = new SellOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft Corporation",
                DateAndTimeOfOrder = DateTime.Parse("2002-06-25"),
                Quantity = 12,
                Price = 0
            };

            //Assert
            await Assert.ThrowsAsync<ArgumentException>(async() =>
            {
                //Act
                await _stockService.CreateSellOrder(request);
            });
        }

        [Fact]
        public async Task CreateSellOrder_OrderPriceAs10001()
        {
            //Arrange
            SellOrderRequest? request = new SellOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft Corporation",
                DateAndTimeOfOrder = DateTime.Parse("2002-06-25"),
                Quantity = 12,
                Price = 10001
            };

            //Assert
            await Assert.ThrowsAsync<ArgumentException>(async() =>
            {
                //Act
                await _stockService.CreateSellOrder(request);
            });
        }

        [Fact]
        public async Task CreateSellOrder_StockSymbolIsNull()
        {
            //Arrange
            SellOrderRequest? request = new SellOrderRequest()
            {
                StockSymbol = null,
                StockName = "Microsoft Corporation",
                DateAndTimeOfOrder = DateTime.Parse("2002-06-25"),
                Quantity = 12,
                Price = 20
            };

            //Assert
            await Assert.ThrowsAsync<ArgumentException>(async() =>
            {
                //Act
                await _stockService.CreateSellOrder(request);
            });
        }

        [Fact]
        public async Task CreateSellOrder_DateAndTimeOfOrderTooOld()
        {
            //Arrange
            SellOrderRequest? request = new SellOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft Corporation",
                DateAndTimeOfOrder = DateTime.Parse("1998-06-25"),
                Quantity = 12,
                Price = 20
            };

            //Assert
            await Assert.ThrowsAsync<ArgumentException>(async() =>
            {
                //Act
                await _stockService.CreateSellOrder(request);
            });
        }

        [Fact]
        public async Task CreateSellOrder_Details()
        {
            //Arrange
            SellOrderRequest? request = new SellOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft Corporation",
                DateAndTimeOfOrder = DateTime.Parse("2002-06-25"),
                Quantity = 12,
                Price = 20
            };

            //Act
            SellOrderResponse? response = await _stockService.CreateSellOrder(request);

            //Assert
            Assert.NotEqual(Guid.Empty, response.SellOrderID);
        }

        #endregion

        #region GetAllBuyOrders

        [Fact]
        public async Task GetBuyOrders_GetEmptyList()
        {
            //Act
            List<BuyOrderResponse> listResponse = await _stockService.GetBuyOrders();

            //Assert
            Assert.Empty(listResponse);
        }

        [Fact]
        public async Task GetBuyOrders_GetList()
        {
            //Arrange
            BuyOrderRequest? requestBuyOrder1 = new BuyOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft Corporation",
                DateAndTimeOfOrder = DateTime.Parse("2002-06-25"),
                Quantity = 12,
                Price = 20
            };

            BuyOrderRequest? requestBuyOrder2 = new BuyOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft Corporation",
                DateAndTimeOfOrder = DateTime.Parse("2002-06-25"),
                Quantity = 12,
                Price = 20
            };

            List<BuyOrderRequest> listRequestBuyOrder = new List<BuyOrderRequest>()
            {
                requestBuyOrder1,
                requestBuyOrder2
            };

            List<BuyOrderResponse> listResponseBuyOrderFromAdd = new List<BuyOrderResponse>();

            foreach (BuyOrderRequest buyOrderRequest in listRequestBuyOrder)
            {
                BuyOrderResponse buyOrderReponse = await _stockService.CreateBuyOrder(buyOrderRequest);
                listResponseBuyOrderFromAdd.Add(buyOrderReponse);
            }

            
            //Act
            List<BuyOrderResponse> listResponseFromGet = await _stockService.GetBuyOrders();

            //Assert
            foreach(BuyOrderResponse buyOrderOrderResponse in listResponseFromGet)
            {
                Assert.Contains(buyOrderOrderResponse, listResponseBuyOrderFromAdd);
            }
        }

        #endregion

        #region GetAllSellOrders

        [Fact]
        public async Task GetSellOrders_GetEmptyList()
        {
            //Act
            List<SellOrderResponse> listResponse = await _stockService.GetSellOrders();

            //Assert
            Assert.Empty(listResponse);
        }

        [Fact]
        public async Task GetSellOrders_GetList()
        {
            //Arrange
            SellOrderRequest? requestSellOrder1 = new SellOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft Corporation",
                DateAndTimeOfOrder = DateTime.Parse("2002-06-25"),
                Quantity = 12,
                Price = 20
            };

            SellOrderRequest? requestSellOrder2 = new SellOrderRequest()
            {
                StockSymbol = "MSFT",
                StockName = "Microsoft Corporation",
                DateAndTimeOfOrder = DateTime.Parse("2002-06-25"),
                Quantity = 32,
                Price = 60
            };

            List<SellOrderRequest> listRequestSellOrder = new List<SellOrderRequest>()
            {
                requestSellOrder1,
                requestSellOrder2
            };

            List<SellOrderResponse> listResponseSellOrderFromAdd = new List<SellOrderResponse>();

            foreach (SellOrderRequest sellOrderRequest in listRequestSellOrder)
            {
                SellOrderResponse sellOrderReponse = await _stockService.CreateSellOrder(sellOrderRequest);
                listResponseSellOrderFromAdd.Add(sellOrderReponse);
            }


            //Act
            List<SellOrderResponse> listResponseFromGet = await _stockService.GetSellOrders();

            //Assert
            foreach (SellOrderResponse sellOrderOrderResponse in listResponseFromGet)
            {
                Assert.Contains(sellOrderOrderResponse, listResponseSellOrderFromAdd);
            }
        }


        #endregion
    }
}
