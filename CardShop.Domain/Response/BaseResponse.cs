using CardShop.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardShop.Domain.Responce
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Статус код
        /// </summary>
        public StatusCode StatusCode { get; set; }

        /// <summary>
        /// Результат запроса
        /// </summary>
        public T Data { get; set; }

    }

    public interface IBaseResponse<T>
    {
        string Description { get;}
        T Data { get; }
        StatusCode StatusCode { get; }
    }
}
