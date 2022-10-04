using CardShop.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage ="Отсутствует название видеокарты")]
        [MinLength(5, ErrorMessage ="Название должно состоять минимум из 5 символов")]
        [MaxLength(50, ErrorMessage ="Название должно состоять максимум из 50 символов")]
        public string Title { get; set; }

        /// <summary>
        /// Производитель
        /// </summary>
        [Required(ErrorMessage ="Отсутствует производитель видеокарты")]
        public Manufacturer Manufacturer { get; set; }

        /// <summary>
        /// Модель
        /// </summary>
        [Required(ErrorMessage = "Отсутствует модель видеокарты")]
        [MinLength(3, ErrorMessage = "Модель должна состоять минимум из 3 символов")]
        [MaxLength(50, ErrorMessage = "Модель должна состоять максимум из 50 символов")]
        public string Model { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        [MinLength(5, ErrorMessage = "Описание должно состоять минимум из 5 символов")]
        [MaxLength(256, ErrorMessage = "Описание должно состоять максимум из 256 символов")]
        public string? Description { get; set; }

        /// <summary>
        /// Частота графического ядра
        /// </summary>
        [Required(ErrorMessage = "Отсутствует частота графического ядра видеокарты")]
        [Range(1000,10000,ErrorMessage ="Частота графического ядра должна быть в пределе от 1000 до 10000 МГц")]
        public double FrequencyGPU { get; set; }

        /// <summary>
        /// Количество видеопамяти
        /// </summary>
        [Required(ErrorMessage = "Отсутствует объем видеопамяти")]
        [Range(1,100, ErrorMessage = "Объем видеопамяти должен быть в пределе от 1 до 100 ГБ")]
        public double MemoryCapacity { get; set; }

        /// <summary>
        /// Тип видеопамяти
        /// </summary>
        [Required(ErrorMessage = "Отсутствует тип видеопамяти")]
        [MinLength(3, ErrorMessage = "Тип видеопамяти должен состоять минимум из 3 символов")]
        [MaxLength(50, ErrorMessage = "Тип видеопамяти должен состоять максимум из 50 символов")]
        public string MemoryType { get; set; }

        /// <summary>
        /// Частота видеопамяти
        /// </summary>
        [Required(ErrorMessage = "Отсутствует частота видеопамяти видеокарты")]
        [Range(1000, 100000, ErrorMessage = "Частота видеопамяти должна быть в пределе от 1000 до 100000 МГц")]
        public double FrequencyMemory { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        [Required(ErrorMessage = "Отсутствует цена видеокарты")]
        [Range(0, 1000000, ErrorMessage = "Цена видеокарты должна быть в пределе от 0 до 1.000.000 ₽")]
        public decimal Price { get; set; }

        public byte[]? Avatar { get; set; }

    }

}
