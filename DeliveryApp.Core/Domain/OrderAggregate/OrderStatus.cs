using CSharpFunctionalExtensions;
using DeliveryApp.Core.Domain.CourierAggregate;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Core.Domain.OrderAggregate
{
    public class OrderStatus : ValueObject
    {
        /// <summary>
        /// Значение
        /// </summary>
        public string Value { get; protected set; }

        [ExcludeFromCodeCoverage]
        public OrderStatus() { }

        protected OrderStatus(string status)
        {
            Value = status;
        }

        /// <summary>
        /// Статус создан
        /// </summary>
        /// <returns></returns>
        public OrderStatus Created()
        {
            return new OrderStatus("создан");
        }

        /// <summary>
        /// Статус назначен на курьера
        /// </summary>
        /// <returns></returns>
        public OrderStatus Assigned()
        {
            return new OrderStatus("назначен на курьера");
        }

        /// <summary>
        /// Статус завершен
        /// </summary>
        /// <returns></returns>
        public OrderStatus Completed()
        {
            return new OrderStatus("завершен");
        }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
