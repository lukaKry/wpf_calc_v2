using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp_Calc
{
    public enum State { Initial, NumberEdition, FloatingNumberEdition, SymbolEdition, Evaluation }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MyApplication MyApplication { get; set; } = new();

        private State AppState = State.Initial;

        private bool FloatingState = false;

        private bool AtLeastOneSymbolInTheEquation = false;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }


        private void On_MemoryButton_Clicked(object sender, RoutedEventArgs e)
        {
            // only shows the last successfull equation
            MyApplication.MemoryButtonIsClicked();
            AppState = State.Evaluation;
            FloatingState = false;
        }

        private void On_ClearButton_Clicked(object sender, RoutedEventArgs e)
        {
            MyApplication.ClearButtonIsClicked();
            FloatingState = false;
        }

        private void On_NumberButton_Clicked(object sender, RoutedEventArgs e)
        {
            // If Clicked after evaluation
            if (AppState == State.Evaluation)
            {
                MyApplication.ClearButtonIsClicked();
                AtLeastOneSymbolInTheEquation = false;
            }

            // Change App State
            if (AppState != State.NumberEdition) AppState = State.NumberEdition;


            // Trigger the button
            if (AppState == State.NumberEdition)
            {
                Button button = (Button)sender;
                MyApplication.NumberButtonIsClicked(button.Uid);
            }

        }

        private void On_SymbolButton_Clicked(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            // Change App State
            if (AppState == State.NumberEdition)
            {
                FloatingState = false;
                AppState = State.SymbolEdition;
                AtLeastOneSymbolInTheEquation = true;
                MyApplication.SymbolButtonIsClicked(button.Uid);
            }

            // No App state Change; only Symbol change
            else if (AppState == State.SymbolEdition) MyApplication.SymbolChange(button.Uid);

        }

        private void On_EqualSignButton_Clicked(object sender, RoutedEventArgs e)
        {
            // Change App State only if NumberEdition State is on
            // In order to disable evoking calculations directly from symbol edition state
            if (AppState == State.NumberEdition)
            {
                FloatingState = false;
                AppState = State.Evaluation;

                try
                {
                    MyApplication.EqualSignIsClicked();

                    // Send current equation to the long term memory
                    MyApplication.SaveCurrentEquationToTheLongTermMemory();
                }
                catch (DivideByZeroException)
                {
                    MessageBox.Show("nastąpiła próba dzielenia przez 0");
                    MyApplication.ClearButtonIsClicked();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ups, coś poszło nie tak");
                }

            }
        }

        private void On_CommaButton_Clicked(object sender, RoutedEventArgs e)
        {
            if (FloatingState == false && AppState != State.Evaluation)
            {
                FloatingState = true;
                MyApplication.CommaButtonIsClicked();
            }
        }
    }
}
