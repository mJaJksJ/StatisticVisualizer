using StatisticVisualizerLib.Database;

namespace StatisticVisualizer.Database
{
    /// <inheritdoc/>
    public class Database : DatabaseContext
    {
        /// <summary>
        /// .ctor
        /// </summary>
        public Database(string connectionString) : base(connectionString) { }
    }
}
