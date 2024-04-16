using CSharpFunctionalExtensions;
using DeliveryApp.Core.Domain.CourierAggregate;
using DeliveryApp.Core.Domain.SharedKernel;
using Primitives;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DeliveryApp.Core.Domain.OrderAggregate
{
    public class Order : Entity<int>
    {
        /// <summary>
        /// идентификатор исполнителя(курьера)
        /// </summary>
        public int CourierId { get; private set; }

        /// <summary>
        /// местоположение, куда нужно доставить заказ
        /// </summary>
        public Location Location { get; private set; }

        /// <summary>
        /// вес заказа
        /// </summary>
        public decimal Weight { get; private set; }

        /// <summary>
        /// статус заказа
        /// </summary>
        public OrderStatus Status { get; private set; }

        /// <summary>
        /// Ctr
        /// </summary>
        [ExcludeFromCodeCoverage]
        private Order()
        {
        }

        /// <summary>
        /// Factory Method
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <param name="location">местоположение, куда нужно доставить заказ</param>
        /// <param name="weight">вес заказа</param>
        private Order(int id, Location location, decimal weight)
        {
            Id = id;
            Location = location;
            Weight = weight;
            Status = new OrderStatus().Created();
        }


        /// <summary>
        /// Factory Method
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <param name="location">местоположение, куда нужно доставить заказ</param>
        /// <param name="weight">вес заказа</param>
        /// <returns>Результат</returns>
        public static Result<Order, Error> Create(int id, Location location, decimal weight)
        {
            if (id <= 0) return GeneralErrors.ValueIsRequired(nameof(id));
            if (location == null) return GeneralErrors.ValueIsInvalid(nameof(location));
            if (weight <= 0) return GeneralErrors.ValueIsInvalid(nameof(weight));

            return new Order(id, location, weight);
        }

        /// <summary>
        /// Назначение заказа на курьера
        /// </summary>
        /// <param name="courier">курьер</param>
        /// <returns></returns>
        public Result<object, Error> AssignToCourier(Courier courier)
        {
            if (courier == null) return GeneralErrors.ValueIsRequired(nameof(courier));

            CourierId = 1;
            Status = new OrderStatus().Assigned();

            return new object();
        }

        /// <summary>
        /// Завершение заказа
        /// </summary>
        /// <returns></returns>
        public Result<object, Error> Сomplete()
        {
            if (Status.Equals(new OrderStatus().Assigned())) return GeneralErrors.ValueIsRequired(nameof(Status));
                        
            Status = new OrderStatus().Completed();

            return new object();
        }

    }
}
