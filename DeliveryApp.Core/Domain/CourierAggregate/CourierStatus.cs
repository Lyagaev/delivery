using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Core.Domain.CourierAggregate
{
    public class CourierStatus : ValueObject
    {
        /// <summary>
        /// Значение
        /// </summary>
        public string Value { get; protected set; }

        [ExcludeFromCodeCoverage]
        public CourierStatus() { }
                
        protected CourierStatus(string status)
        {
            Value = status;
        }

        /// <summary>
        /// Статус недоступен
        /// </summary>
        /// <returns></returns>
        public CourierStatus NotAvailable()
        {
            return new CourierStatus("NotAvailable");
        }

        /// <summary>
        /// Статус готов к работе
        /// </summary>
        /// <returns></returns>
        public CourierStatus Ready()
        {
            return new CourierStatus("Ready");
        }

        /// <summary>
        /// Статус выполняет заказ, занят
        /// </summary>
        /// <returns></returns>
        public CourierStatus Busy()
        {
            return new CourierStatus("Busy");
        }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
