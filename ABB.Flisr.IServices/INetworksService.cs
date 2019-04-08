using ABB.Flisr.Models;
using System;

namespace ABB.Flisr.IServices
{
    public interface INetworksService
    {
        Network Get(int id);

        void Fault();
    }
}
