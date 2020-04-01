using System.Windows;
using System.Windows.Media;
using System.Speech.Synthesis;
namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SpeechSynthesizer synth = new SpeechSynthesizer();
        private double Caution_count = 0;
        public void OnDataCaution_Handler(object sender, DataEventArgs e)
        {
            Caution_count += e.passed;
            if (Caution_count > 0)
            {
                Caution_Button.Background = Brushes.Yellow;
                if(Warning_Acknowledged || Warning_count < 1)
                {
                    synth.SpeakAsync("Caution");
                }
            }

            else
            {
                Caution_Button.Background = Brushes.LightGray;
            }
            Caution_Acknowledged = false;
        }
        private double Warning_count = 0;
        public void OnDataWarning_Handler(object sender, DataEventArgs e)
        {
            Warning_count += e.passed;
            if (Warning_count > 0)
            {
                Warning_Button.Background = Brushes.Red;
                synth.SpeakAsyncCancelAll();
                synth.SpeakAsync("Warning");
            }
            else
            {
                Warning_Button.Background = Brushes.LightGray;
            }
            Warning_Acknowledged = false;

        }
        void initWarnings()
        {
            synth.SetOutputToDefaultAudioDevice();
        }
        void CautionWarningTick()
        {
            if (Warning_count > 0 && !Warning_Acknowledged)
            {
                if (synth.State == SynthesizerState.Ready)
                {
                    synth.SpeakAsyncCancelAll();
                    synth.SpeakAsync("Warning");
                }
            }
            else if (Caution_count > 0 && !Caution_Acknowledged)
            {
                if (synth.State == SynthesizerState.Ready)
                {
                    synth.SpeakAsyncCancelAll();
                    synth.SpeakAsync("Caution");
                }
            }
        }
    }
}