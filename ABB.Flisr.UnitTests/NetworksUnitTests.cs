using System;
using System.Collections.Generic;
using System.Linq;
using ABB.Flisr.FakeServices;
using ABB.Flisr.IServices;
using ABB.Flisr.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABB.Flisr.UnitTests
{
    [TestClass]
    public class NetworksUnitTests
    {
        [TestMethod]
        public void GetTest()
        {
            // Arrange
            int networkId = 1;

            INetworksService networksService = new FakeNetworksService();


            // Acts
            Network network = networksService.Get(networkId);

            // Asserts
            Assert.IsNotNull(network);
            Assert.AreEqual(networkId, network.Id);
            Assert.IsFalse(string.IsNullOrEmpty(network.Name));
            Assert.IsTrue(network.VoltageLevel > 0);

        }


        [TestMethod]
        public void TopologyTest()
        {
            // Arrange
            int networkId = 1;

            INetworksService networksService = new FakeNetworksService();
            Network network = networksService.Get(networkId);
            IEnumerable<Item> items = network.GetItems();

            // Acts


            // Asserts

            var devices = items.OfType<Device>();

            Assert.IsTrue(devices.All(d => d.Terminal1 != null && d.Terminal2 != null), "Devices");

            var substations = items.OfType<SubStation>();

            Assert.AreEqual(2, substations.Count());

            Assert.IsTrue(substations.All(s => s.Terminal != null), "Substations");






        }
    }
}
