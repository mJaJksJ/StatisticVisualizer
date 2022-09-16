namespace StatisticVisualizerLib.Exceptions
{

    /// <summary>
    /// Класс Iris ошибок
    /// </summary>
    internal abstract class StatisticVisualizerException : Exception
    {
        /// <summary>
        /// Сообщение ошибки (рус)
        /// </summary>
        public string RussianMessage { get; }

        /// <summary>
        /// .ctor
        /// </summary>
        protected StatisticVisualizerException(string russianMessage = null) : base()
        {
            RussianMessage = russianMessage;
        }

        /// <inheritdoc/>
        public override string Message => $"StatisticVisualizer process error:\n ({RussianMessage})";
    }
}
