using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace GUI
{
    public class StateEventArgs : EventArgs
    {
        public string passed;
    }
    public class State
    {
        public delegate void StateChanged(object sender, StateEventArgs e);
        public event StateChanged OnStateChanged;

        public delegate void SequenceFinished(object sender, StateEventArgs e);
        public event SequenceFinished OnSequenceFinished;

        public string Finish_Text;
        private string start_text = "Idle";
        public string Start_Text
        {
            get { return start_text; }
            set {
                    StateEventArgs e = new StateEventArgs();
                    start_text = value;
                    e.passed = value;
                    RaiseStateChange(e);
                }
        }
        public class textTemplate
        {
            public TextBlock Block = new TextBlock();
            public textTemplate(string text, double font_size )
            {
                Block.FontSize = font_size;
                Block.Text = text;
                Block.TextWrapping = TextWrapping.Wrap;
                Block.Background = System.Windows.Media.Brushes.White;
                Block.HorizontalAlignment = HorizontalAlignment.Center;
                Block.Width = 220;
                Block.TextAlignment = TextAlignment.Center;
                Block.VerticalAlignment = VerticalAlignment.Center;
                Block.Margin = new Thickness(10, 10, 10, 10);
                Grid.SetColumn(Block, 0);
            }

        }
        public class checkboxTemplate
        {
            public CheckBox checkbox = new CheckBox();
            public checkboxTemplate()
            {
                checkbox.IsEnabled = false;
                checkbox.HorizontalAlignment = HorizontalAlignment.Right;
                checkbox.VerticalAlignment = VerticalAlignment.Center;
                checkbox.Margin = new Thickness(10, 10, 10, 10);
                Grid.SetColumn(checkbox, 1);
            }

        }
        public class stackPanelTemplate
        {
            public DockPanel stackpanel = new DockPanel();
            public stackPanelTemplate(textTemplate text, checkboxTemplate checkbox, double width)
            {
                stackpanel.Children.Add(text.Block);
                stackpanel.Children.Add(checkbox.checkbox);
                stackpanel.Width = width-20;

            }

        }
        public class gridTemplate
        {
            public Grid grid = new Grid();
            public gridTemplate(textTemplate text, checkboxTemplate checkbox, double width)
            {
                ColumnDefinition textCol = new ColumnDefinition();
                textCol.Width = new GridLength(240);
                ColumnDefinition checkCol = new ColumnDefinition();
                checkCol.Width = new GridLength(30);
                grid.HorizontalAlignment = HorizontalAlignment.Center;
                grid.ColumnDefinitions.Add(textCol);
                grid.ColumnDefinitions.Add(checkCol);
                grid.Children.Add(text.Block);
                grid.Children.Add(checkbox.checkbox);
                grid.Width = width;
            }

        }

        public textTemplate[] text;
        public checkboxTemplate[] checkbox;
        public stackPanelTemplate[] stackPanels;
        public gridTemplate[] grids;
        private Button button;

        public int text_count;

        public State(string _start_text, string _finish_text,string[] passed, Button _button, double font_size, double width)
        {
            button = _button;
            Start_Text = _start_text;
            Finish_Text = _finish_text;
            text_count = passed.Length;
            text = new textTemplate[text_count];
            checkbox = new checkboxTemplate[text_count];
            stackPanels = new stackPanelTemplate[text_count];
            grids = new gridTemplate[text_count];

            for (int i = 0; i < text_count; i++)
            {
                text[i] = new textTemplate(passed[i], font_size);
                checkbox[i] = new checkboxTemplate();
                stackPanels[i] = new stackPanelTemplate(text[i], checkbox[i], width);
            }

        }
        private int Sequence_Number = 0;
        public void UpdateState(string update)
        {
            if (Start_Text != "Idle")
            {
                if (update == "Increment")
                {
                    text[Sequence_Number].Block.Foreground = Brushes.Green;
                    checkbox[Sequence_Number].checkbox.IsChecked = true;
                    if (Sequence_Number < text_count - 1) { Sequence_Number++; }
                    else
                    {
                        StateEventArgs e = new StateEventArgs();
                        e.passed = Finish_Text;
                        button.Background = Brushes.Green;
                        RaiseSequenceFinished(e);
                    }
                }
                else if (update == "Failure")
                {
                    text[Sequence_Number].Block.Foreground = Brushes.Red;
                    checkbox[Sequence_Number].checkbox.IsChecked = false;
                    button.Background = Brushes.Red;
                }
            }
        }
        public void Reset()
        {
            if (Start_Text != "Idle") {
                for (int i = 0; i <= Sequence_Number; i++)
                {
                    text[i].Block.Foreground = Brushes.Black;
                    checkbox[i].checkbox.IsChecked = false;
                }
                Sequence_Number = 0;
            }
        }

        protected virtual void RaiseStateChange(StateEventArgs e)
        {
            if (OnStateChanged != null) { OnStateChanged(this, e); }
        }

        protected virtual void RaiseSequenceFinished(StateEventArgs e)
        {
            if (OnSequenceFinished != null) { OnSequenceFinished(this, e); }
        }
        

    }
}
