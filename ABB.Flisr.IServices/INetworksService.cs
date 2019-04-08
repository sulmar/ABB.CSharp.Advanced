using ABB.Flisr.Models;
using System;

namespace ABB.Flisr.IServices
{
    public interface INetworksService
    {
        Network Get(int id);

        void Fault();
    }


   public static class INetworksServiceEx
    {
        public static Network Get(this INetworksService networksService, int id)
        {
            return null;
        }
    }

    //public interface IBankomat
    //{
    //    void Wyplata();
    //    void Wplata();
    //}

    public interface IWyplatomat
    {
        void Wyplata();
    }

    public interface IWplatomat
    {
        void Wplata();
    }

    public interface ILadomat
    {
        void Doladuj();
    }


    class MyBankomat : IWyplatomat, IWplatomat, ILadomat
    {
        public void Doladuj()
        {
            throw new NotImplementedException();
        }

        public void Wplata()
        {
            throw new NotImplementedException();
        }

        public void Wyplata()
        {
            // ...
        }
    }
}
