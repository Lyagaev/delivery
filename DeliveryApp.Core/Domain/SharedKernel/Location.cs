using CSharpFunctionalExtensions;
using Primitives;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Core.Domain.SharedKernel
{
    public class Location : ValueObject
    {

        /// <summary>
        /// Координата по x
        /// </summary>
        public int X { get; protected set; }

        /// <summary>
        /// Координата по y
        /// </summary>
        public int Y { get; protected set; }

        /// <summary>
        /// Ctr
        /// </summary>
        [ExcludeFromCodeCoverage]
        protected Location()
        {

        }

        /// <summary>
        /// Координаты на доске
        /// </summary>
        /// <param name="x"> Координата x </param>
        /// <param name="y"> Координата y </param>
        protected Location(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"> Координата x </param>
        /// <param name="y"> Координата y </param>
        /// <returns> Результат </returns>
        public static Result<Location, Error> Create(int x, int y)
        {
            if (x <= 0 || x > 10) return GeneralErrors.ValueIsInvalid(nameof(x));
            if (y <= 0 || y > 10) return GeneralErrors.ValueIsInvalid(nameof(y));

            return new Location(x, y);
        }

        /// <summary>
        /// Растояние между 2 локациями
        /// </summary>
        /// <param name="x"> Координата x </param>
        /// <param name="y"> Координата y </param>
        /// <returns> Результат </returns>
        public int CalculateDistance(Location second)
        {
            int distanceX = Math.Abs(X - second.X);
            int distanceY = Math.Abs(Y - second.Y);

            return distanceX + distanceY;
        }

        /// <summary>
        /// Перегрузка для определения идентичности
        /// </summary>
        /// <returns>Результат</returns>
        /// <remarks>Идентичность будет происходить по совокупности полей указанных в методе</remarks>
        [ExcludeFromCodeCoverage]
        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return X;
            yield return Y;
        }

    }
}
