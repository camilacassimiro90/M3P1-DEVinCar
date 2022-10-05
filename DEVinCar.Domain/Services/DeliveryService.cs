using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Interfaces.Services;
using DEVinCar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinCar.Domain.Services
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IDeliveryRepository _deliveryRepository;

        public DeliveryService(IDeliveryRepository deliveryRepository)
        {
            _deliveryRepository = deliveryRepository;
        }

        public void Atualizar(DeliveryDTO delivery)
        {
            var deliveryDb = _deliveryRepository.ObterPorId(delivery.Id);
            deliveryDb.Update(delivery);
            _deliveryRepository.Atualizar(deliveryDb);
        }

        public void Excluir(int id)
        {
            var delivery = _deliveryRepository.ObterPorId(id);

            _deliveryRepository.Excluir(delivery);
        }

        public void Inserir(DeliveryDTO delivery)
        {
            _deliveryRepository.Inserir(new Delivery(delivery));
        }

        public DeliveryDTO ObterPorId(int id)
        {
            return new DeliveryDTO(_deliveryRepository.ObterPorId(id));
        }

        public IList<Delivery> ObterTodos()
        {
            return _deliveryRepository.ObterTodos();
        }
    }
}
