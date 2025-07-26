using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfigurationExercise2.ServiceContracts.DTO;
using ConfigurationExercise2.ServiceContracts;
using ConfigurationExercise2.Service;
using Xunit.Abstractions;

namespace StockTests
{
    public class StockServiceTest
    {
        private readonly IStockService _stockService;
        private readonly ITestOutputHelper _testOutputHelper;

        public StockServiceTest(ITestOutputHelper testOutputHelper)
        {
            _stockService = new StockService();
            _testOutputHelper = testOutputHelper;
        }

        #region CreateBuyOrder

        [Fact]
        public void CreateBuyOrder_BuyOrderIsNull()
        {
            //Arrange
            BuyOrderRequest? request = null;

            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                //Act
                _stockService.CreateBuyOrder(request);
            });
        }

        [Fact]
        public void CreateBuyOrder_QuantityAsZero()
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
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                _stockService.CreateBuyOrder(request);
            });
        }

        [Fact]
        public void CreateBuyOrder_QuantityAs100001()
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
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                _stockService.CreateBuyOrder(request);
            });
        }

        [Fact]
        public void CreateBuyOrder_OrderPriceAsZero()
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
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                _stockService.CreateBuyOrder(request);
            });
        }

        [Fact]
        public void CreateBuyOrder_OrderPriceAs10001()
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
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                _stockService.CreateBuyOrder(request);
            });
        }

        [Fact]
        public void CreateBuyOrder_StockSymbolIsNull()
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
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                _stockService.CreateBuyOrder(request);
            });
        }

        [Fact]
        public void CreateBuyOrder_DateAndTimeOfOrderTooOld()
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
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                BuyOrderResponse response = _stockService.CreateBuyOrder(request);
                _testOutputHelper.WriteLine(response.ToString());
            });
        }

        [Fact]
        public void CreateBuyOrder_Details()
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
            BuyOrderResponse? response = _stockService.CreateBuyOrder(request);

            //Assert
            Assert.NotEqual(Guid.Empty, response.BuyOrderID);
        }

        #endregion

        #region CreateSellOrder

        [Fact]
        public void CreateSellOrder_BuyOrderIsNull()
        {
            //Arrange
            SellOrderRequest? request = null;

            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                //Act
                _stockService.CreateSellOrder(request);
            });
        }

        [Fact]
        public void CreateSellOrder_QuantityAsZero()
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
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                _stockService.CreateSellOrder(request);
            });
        }

        [Fact]
        public void CreateSellOrder_QuantityAs100001()
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
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                _stockService.CreateSellOrder(request);
            });
        }

        [Fact]
        public void CreateSellOrder_OrderPriceAsZero()
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
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                _stockService.CreateSellOrder(request);
            });
        }

        [Fact]
        public void CreateSellOrder_OrderPriceAs10001()
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
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                _stockService.CreateSellOrder(request);
            });
        }

        [Fact]
        public void CreateSellOrder_StockSymbolIsNull()
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
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                _stockService.CreateSellOrder(request);
            });
        }

        [Fact]
        public void CreateSellOrder_DateAndTimeOfOrderTooOld()
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
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                _stockService.CreateSellOrder(request);
            });
        }

        [Fact]
        public void CreateSellOrder_Details()
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
            SellOrderResponse? response = _stockService.CreateSellOrder(request);

            //Assert
            Assert.NotEqual(Guid.Empty, response.SellOrderID);
        }

        #endregion

        #region GetAllBuyOrders

        [Fact]
        public void GetBuyOrders_GetEmptyList()
        {
            //Act
            List<BuyOrderResponse> listResponse = _stockService.GetBuyOrders();

            //Assert
            Assert.Empty(listResponse);
        }

        [Fact]
        public void GetBuyOrders_GetList()
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
                BuyOrderResponse buyOrderReponse = _stockService.CreateBuyOrder(buyOrderRequest);
                listResponseBuyOrderFromAdd.Add(buyOrderReponse);
            }

            
            //Act
            List<BuyOrderResponse> listResponseFromGet = _stockService.GetBuyOrders();

            //Assert
            foreach(BuyOrderResponse buyOrderOrderResponse in listResponseFromGet)
            {
                Assert.Contains(buyOrderOrderResponse, listResponseBuyOrderFromAdd);
            }
        }

        #endregion

        #region GetAllSellOrders

        [Fact]
        public void GetSellOrders_GetEmptyList()
        {
            //Act
            List<SellOrderResponse> listResponse = _stockService.GetSellOrders();

            //Assert
            Assert.Empty(listResponse);
        }

        [Fact]
        public void GetSellOrders_GetList()
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
                SellOrderResponse sellOrderReponse = _stockService.CreateSellOrder(sellOrderRequest);
                listResponseSellOrderFromAdd.Add(sellOrderReponse);
            }


            //Act
            List<SellOrderResponse> listResponseFromGet = _stockService.GetSellOrders();

            //Assert
            foreach (SellOrderResponse sellOrderOrderResponse in listResponseFromGet)
            {
                Assert.Contains(sellOrderOrderResponse, listResponseSellOrderFromAdd);
            }
        }


        #endregion
    }
}
