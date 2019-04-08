using ABB.Flisr.IServices;
using ABB.Flisr.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ABB.Flisr.FakeServices
{
    public class FakeNetworksService : INetworksService
    {
        private IList<Network> networks;


        public FakeNetworksService()
        {
            networks = new List<Network>();
     
            Network network = new Network(1, "Network 1", 10);

            SubStation substation1 = new SubStation(2, "Substation A");
         
            Device switch1 = new Switch(3, "Switch A");
         
            Line line1 = new Line(4, "Line A", 100);
            line1.Terminal1 = substation1;
            line1.Terminal2 = switch1;

            substation1.Terminal = line1;
            switch1.Terminal1 = line1;

            SubStation subStation2 = new SubStation(10, "Substation B");
            subStation2.Terminal = line1;

            switch1.Terminal2 = subStation2;


            Load load1 = new Load(5, "Load 1");
            line1.Connect(load1);

            Load load2 = new Load(7, "Load 2");
            line1.Connect(load2);

            network.Add(substation1);
            network.Add(subStation2);
            network.Add(switch1);
            network.Add(line1);

            networks.Add(network);



            
           
        }


        public void Hello()
        {

        }


        public void Fault()
        {
            throw new NotImplementedException();
        }

        public Network Get(int id)
        {
            return networks.SingleOrDefault(n => n.Id == id);
        }
    }
}
