using CSharpFunctionalExtensions;
using DeliveryApp.Core.Domain.OrderAggregate;
using DeliveryApp.Core.Domain.SharedKernel;
using Primitives;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Core.Domain.CourierAggregate
{
    public class Courier
    {
        /// <summary>
        /// имя курьера
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// транспорт курьера
        /// </summary>
        public Transport Transport { get; private set; }

        /// <summary>
        /// местоположение курьера
        /// </summary>
        public Location Location { get; private set; }

        /// <summary>
        /// статус курьера
        /// </summary>
        public CourierStatus Status { get; private set; }

        /// <summary>
        /// Ctr
        /// </summary>
        [ExcludeFromCodeCoverage]
        private Courier()
        {
        }

        /// <summary>
        /// Factory Method
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <param name="location">местоположение, куда нужно доставить заказ</param>
        /// <param name="weight">вес заказа</param>
        private Courier(string name, Transport transport)
        {
            Name = name;
            Transport = transport;
            Location = Location.Create(1,1);
            Status = new CourierStatus().NotAvailable();
        }


        /// <summary>
        /// Factory Method
        /// </summary>
        /// <param name="name">имя</param>
        /// <param name="transport">транспорт</param>
        /// <returns>Результат</returns>
        public static Result<Courier, Error> Create(string name, Transport transport)
        {
            if (name == "") return GeneralErrors.ValueIsRequired(nameof(name));
            if (transport == null) return GeneralErrors.ValueIsInvalid(nameof(transport));
            
            return new Courier(name, transport);
        }
    }
}
