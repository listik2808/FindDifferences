using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scripts.Services
{
    public class AllServices
    {
        private static AllServices _instance;

        public static AllServices Continer => _instance ?? (_instance = new AllServices());

        public void RegisterSingle<TService>(TService implementation) where TService : IService => 
            Implementation<TService>.ServiceInstance = implementation;

        public TService Single<TService>() where TService : IService =>
            Implementation<TService>.ServiceInstance;

        private static class Implementation<TService> where TService : IService
        {
            public static TService ServiceInstance;
        }
    }
}
