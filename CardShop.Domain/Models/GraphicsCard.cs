using CardShop.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardShop.Domain.Models
{
    public class GraphicsCard
    {
        public int Id { get; set; }

        /// <summary>
        /// Название видеокарты
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Производитель
        /// </summary>
        public Manufacturer Manufacturer { get; set; }

        /// <summary>
        /// Модель
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Частота графического ядра
        /// </summary>
        public double FrequencyGPU { get; set; }

        /// <summary>
        /// Количество видеопамяти
        /// </summary>
        public double MemoryCapacity { get; set; }

        /// <summary>
        /// Тип видеопамяти
        /// </summary>
        public string MemoryType { get; set; }

        /// <summary>
        /// Частота видеопамяти
        /// </summary>
        public double FrequencyMemory { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { get; set; }

    }
}
