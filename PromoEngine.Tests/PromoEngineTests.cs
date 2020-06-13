using System;
using Xunit;
using System.Collections.Generic;
using PromoEngine.Core;

namespace PromoEngine.Tests
{
    public class PromoEngineTests
    {
        public PromoEngineTests()
        {

        }
        [Fact]
        public void ScenarioA()
        {
            //Arrange
            List<CartItem> cart = SeedCartScenarioA();
            int expectedTotalPaymentScenario1 = 100;

            //Act

            Shop shop = new Shop();
            int totalPayment = shop.Checkout(cart);

            //Assert

            Assert.Equal(totalPayment, expectedTotalPaymentScenario1);            

        }

        [Fact]
        public void ScenarioB()
        {
            //Arrange
            List<CartItem> cart = SeedCartScenarioB();
            int expectedTotalPaymentScenario1 = 370;

            //Act

            Shop shop = new Shop();
            int totalPayment = shop.Checkout(cart);

            //Assert

            Assert.Equal(totalPayment, expectedTotalPaymentScenario1);

        }

        [Fact]
        public void ScenarioC()
        {
            //Arrange
            List<CartItem> cart = SeedCartScenarioC();
            int expectedTotalPaymentScenario1 = 280;

            //Act

            Shop shop = new Shop();
            int totalPayment = shop.Checkout(cart);

            //Assert

            Assert.Equal(totalPayment, expectedTotalPaymentScenario1);

        }

        public List<CartItem> SeedCartScenarioA()
        {
            List<CartItem> cart = new List<CartItem>();

            cart.Add(new CartItem { SKU = 'A', Quantity = 1 });
            cart.Add(new CartItem { SKU = 'B', Quantity = 1 });
            cart.Add(new CartItem { SKU = 'C', Quantity = 1 });

            return cart;
        }

        public List<CartItem> SeedCartScenarioB()
        {
            List<CartItem> cart = new List<CartItem>();

            cart.Add(new CartItem { SKU = 'A', Quantity = 5 });
            cart.Add(new CartItem { SKU = 'B', Quantity = 5 });
            cart.Add(new CartItem { SKU = 'C', Quantity = 1 });

            return cart;
        }

        public List<CartItem> SeedCartScenarioC()
        {
            List<CartItem> cart = new List<CartItem>();

            cart.Add(new CartItem { SKU = 'A', Quantity = 3 });
            cart.Add(new CartItem { SKU = 'B', Quantity = 5 });
            cart.Add(new CartItem { SKU = 'C', Quantity = 1 });
            cart.Add(new CartItem { SKU = 'D', Quantity = 1 });

            return cart;
        }
    }
}
