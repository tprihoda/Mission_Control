using System.Windows;
using System.Windows.Media;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static State Current;
        private State Idle_State;
        private State Fill_State;
        private State Fill_Disconnect_State;
        private State Door_Close_State;
        private State Launch_State;

        void initStates()
        {
            string[] Idle_state_text = { };
            Idle_State = new State("Idle", "Idle", Idle_state_text, null, 30, Sequence_Stack.Width);
            string[] Fill_state_text = { "This text should wrap", "Lets see how this works", "State 3", "State 4" };
            Fill_State = new State("Filling Tank", "Tank Filled", Fill_state_text, Fill_Button, 30, Sequence_Stack.Width);
            string[] Fill_Disconnect_state_text = { "State 1", "State 2", "State 3", "State 4" };
            Fill_Disconnect_State = new State("Disconnecting Fill Arm", "Fill Arm Disconnected", Fill_Disconnect_state_text, Fill_Disconnect_Button, 30, Sequence_Stack.Width);
            string[] Door_Close_state_text = { "State 1", "State 2", "State 3", "State 4" };
            Door_Close_State = new State("Closing Fill Door", "Fill Door Closed", Door_Close_state_text, Door_Button, 30, Sequence_Stack.Width);
            string[] Launch_state_text = { "Burn Wire Check", "Ignition", "Open Valve", "Take Off" };
            Launch_State = new State("Launching", "Launch Complete", Launch_state_text, Launch_Button, 30, Sequence_Stack.Width);

            Current = Idle_State;
            State_Display.Text = Current.Start_Text;

            Fill_State.OnSequenceFinished += new State.SequenceFinished(OnSequenceFinshed_Handler);
            Fill_Disconnect_State.OnSequenceFinished += new State.SequenceFinished(OnSequenceFinshed_Handler);
            Door_Close_State.OnSequenceFinished += new State.SequenceFinished(OnSequenceFinshed_Handler);
            Launch_State.OnSequenceFinished += new State.SequenceFinished(OnSequenceFinshed_Handler);
        }

        public void OnSequenceFinshed_Handler(object sender, StateEventArgs e)
        {
            State_Display.Text = e.passed;
        }
    }
}