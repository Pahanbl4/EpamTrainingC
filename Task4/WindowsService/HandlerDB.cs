using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Repository;

namespace WindowsService
{
   public class HandlerDB
    {
        private IRepository<DAL.Models.Manager, Modell.Manager> _managerRepository;
        private IRepository<DAL.Models.Client, Modell.Client> _clientRepository;
        private IRepository<DAL.Models.Product, Modell.Product> _productRepository;
        private IRepository<DAL.Models.SaleInfo, Modell.SaleInfo> _saleInfoRepository;
        private object obj = new object();
        public HandlerDB()
        {
            _managerRepository = new ManagerRepository();
            _clientRepository = new ClientRepository();
            _productRepository = new ProductRepository();
            _saleInfoRepository = new SaleInfoRepository();
        }

        public void AddToDatabase(InfoList infoList)
        {
            lock (obj)
            {
                var newManager = new DAL.Models.Manager
                {
                    ManagerName = infoList.ManagerName
                };
                var manager = _managerRepository.GetEntity(newManager);
                if (manager == null)
                {
                    _managerRepository.Add(newManager);
                    _managerRepository.SaveChanges();
                    manager = _managerRepository.GetEntity(newManager);
                }

                var newClient = new DAL.Models.Client
                {
                    ClientName = infoList.ClientName
                };
                _clientRepository.Add(newClient);
                _clientRepository.SaveChanges();
                var client = _clientRepository.GetEntity(newClient);

                var newProduct = new DAL.Models.Product
                {
                    ProductName = infoList.ProductName, ProductCost = infoList.ProductCost
                };
                _productRepository.Add(newProduct);
                _productRepository.SaveChanges();
                var product = _productRepository.GetEntity(newProduct);

                var saleInfo = new DAL.Models.SaleInfo
                {
                    SaleDate = infoList.SaleDate,
                    ID_Manager = manager.ID_Manager,
                    ID_Client = client.ID_Client,
                    ID_Product = product.ID_Product
                };
                _saleInfoRepository.Add(saleInfo);
                _saleInfoRepository.SaveChanges();
            }
        }
    }
}
