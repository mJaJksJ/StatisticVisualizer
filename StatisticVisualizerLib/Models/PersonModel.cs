namespace StatisticVisualizer.Models
{
    /// <summary>
    /// Модель человека
    /// </summary>
    public class PersonModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Город
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Пол: <br/> <i>true - мужчина</i> <br/> <i>false - женщина</i>
        /// </summary>
        public bool IsMale { get; set; }

        /// <summary>
        /// Возраст
        /// </summary>
        public int Age { get; set; }
    }
}
