using System;
using System.Windows;
using elevator_simulation.Models;

namespace elevator_simulation.Views
{
    public partial class PerformanceDashboardWindow : Window
    {
        public PerformanceDashboardWindow(PerformanceMetrics m)
        {
            InitializeComponent();
            Loaded += (_, _) => ApplyMetrics(m);
        }

        private void ApplyMetrics(PerformanceMetrics m)
        {
            // ── Energy Consumption ──────────────────────────────────────────
            double maxE = Math.Max(m.SmartTotalEnergy, m.FcfsTotalEnergy);
            if (maxE > 0)
            {
                pbEnergySmart.Maximum = maxE;
                pbEnergySmart.Value   = m.SmartTotalEnergy;
                pbEnergyFcfs.Maximum  = maxE;
                pbEnergyFcfs.Value    = m.FcfsTotalEnergy;
            }
            tbEnergySmart.Text = $"{m.SmartTotalEnergy:F1} kWh";
            tbEnergyFcfs.Text  = $"{m.FcfsTotalEnergy:F1} kWh";

            // ── Average Waiting Time ────────────────────────────────────────
            double maxW = Math.Max(m.SmartAvgWaitTime, m.FcfsAvgWaitTime);
            if (maxW > 0)
            {
                pbWaitSmart.Maximum = maxW;
                pbWaitSmart.Value   = m.SmartAvgWaitTime;
                pbWaitFcfs.Maximum  = maxW;
                pbWaitFcfs.Value    = m.FcfsAvgWaitTime;
            }
            tbWaitSmart.Text = $"{m.SmartAvgWaitTime:F1} s";
            tbWaitFcfs.Text  = $"{m.FcfsAvgWaitTime:F1} s";

            // ── Average Journey Time ────────────────────────────────────────
            double maxJ = Math.Max(m.SmartAvgJourneyTime, m.FcfsAvgJourneyTime);
            if (maxJ > 0)
            {
                pbJourneySmart.Maximum = maxJ;
                pbJourneySmart.Value   = m.SmartAvgJourneyTime;
                pbJourneyFcfs.Maximum  = maxJ;
                pbJourneyFcfs.Value    = m.FcfsAvgJourneyTime;
            }
            tbJourneySmart.Text = $"{m.SmartAvgJourneyTime:F1} s";
            tbJourneyFcfs.Text  = $"{m.FcfsAvgJourneyTime:F1} s";

            // ── Peak-Hour Waiting Time ──────────────────────────────────────
            double maxP = Math.Max(m.SmartPeakWaitTime, m.FcfsPeakWaitTime);
            if (maxP > 0)
            {
                pbPeakSmart.Maximum = maxP;
                pbPeakSmart.Value   = m.SmartPeakWaitTime;
                pbPeakFcfs.Maximum  = maxP;
                pbPeakFcfs.Value    = m.FcfsPeakWaitTime;
            }
            tbPeakSmart.Text = $"{m.SmartPeakWaitTime:F1} s";
            tbPeakFcfs.Text  = $"{m.FcfsPeakWaitTime:F1} s";

            // ── Footer Summary ──────────────────────────────────────────────
            tbFooterEnergy.Text  = $"⚡ Energy: {m.EnergyImprovement:F1}% better  |";
            tbFooterWait.Text    = $"  ⏱ Avg Wait: {m.WaitTimeImprovement:F1}% faster  |";
            tbFooterJourney.Text = $"  🚗 Journey: {m.JourneyTimeImprovement:F1}% faster  |";
            tbFooterPeak.Text    = $"  🔥 Peak Wait: {m.PeakWaitImprovement:F1}% faster";
            tbFooterTotal.Text   = $"   (Based on {m.TotalRequests} passenger requests)";
        }
    }
}
