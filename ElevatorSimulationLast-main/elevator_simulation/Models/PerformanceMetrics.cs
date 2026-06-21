namespace elevator_simulation.Models
{
    /// <summary>
    /// Smart Elevator ve FCFS Baseline karşılaştırma metrikleri
    /// </summary>
    public class PerformanceMetrics
    {
        public int TotalRequests { get; set; }

        // Smart Elevator System
        public double SmartTotalEnergy    { get; set; }
        public double SmartAvgWaitTime    { get; set; }
        public double SmartAvgJourneyTime { get; set; }
        public double SmartPeakWaitTime   { get; set; }

        // FCFS Baseline System
        public double FcfsTotalEnergy     { get; set; }
        public double FcfsAvgWaitTime     { get; set; }
        public double FcfsAvgJourneyTime  { get; set; }
        public double FcfsPeakWaitTime    { get; set; }

        // Improvement percentages
        public double EnergyImprovement
            => FcfsTotalEnergy    > 0 ? (FcfsTotalEnergy    - SmartTotalEnergy)    / FcfsTotalEnergy    * 100 : 0;
        public double WaitTimeImprovement
            => FcfsAvgWaitTime    > 0 ? (FcfsAvgWaitTime    - SmartAvgWaitTime)    / FcfsAvgWaitTime    * 100 : 0;
        public double JourneyTimeImprovement
            => FcfsAvgJourneyTime > 0 ? (FcfsAvgJourneyTime - SmartAvgJourneyTime) / FcfsAvgJourneyTime * 100 : 0;
        public double PeakWaitImprovement
            => FcfsPeakWaitTime   > 0 ? (FcfsPeakWaitTime   - SmartPeakWaitTime)   / FcfsPeakWaitTime   * 100 : 0;
    }
}
