using System;
using Xamarin.Forms;

namespace VRCalculator
{
    public partial class Home : ContentPage
    {
        long number1 = 0;
        long number2 = 0;
        string operation = "";

        public delegate ContentPage GetEditorInstance(string InitialEditorText);
        static public GetEditorInstance EditorFactory;
        static ISpeechToText speechRecognitionInstnace;


        public Home()
        {
            InitializeComponent();

            speechRecognitionInstnace = DependencyService.Get<ISpeechToText>();
            speechRecognitionInstnace.textChanged += OnTextChange;
        }

        public void OnStart(Object sender, EventArgs args)
        {
            speechRecognitionInstnace.Start();
            ButtonStart.BackgroundColor = Color.FromHex("EF3D38");
        }
        public void OnStop(Object sender, EventArgs args)
        {
            speechRecognitionInstnace.Stop();
            ButtonStart.BackgroundColor = Color.FromHex("#96ca2d");
        }
        public void OnTextChange(object sender, EventArgsVoiceRecognition e)
        {
            Display.Text = e.Text;
            if (Display.Text.Contains("equals"))
            {
                speechRecognitionInstnace.Stop();
                var result = MathEvaluator.Evaluate(Display.Text);
                Display.Text = result.ToString();
            }

        }

        void Handle_Clicked1(object sender, System.EventArgs e)
        {
            if (operation == "")
            {
                number1 = (number1 * 10) + 1;
                Display.Text = number1.ToString();
            }
            else
            {
                number2 = (number2 * 10) + 1;
                Display.Text = number2.ToString();

            }
        }


        void Handle_Clicked2(object sender, System.EventArgs e)
        {
            if (operation == "")
            {
                number1 = (number1 * 10) + 2;
                Display.Text = number1.ToString();
            }
            else
            {
                number2 = (number2 * 10) + 2;
                Display.Text = number2.ToString();
            }

        }

        void Handle_Clicked3(object sender, System.EventArgs e)
        {
            if (operation == "")
            {
                number1 = (number1 * 10) + 3;
                Display.Text = number1.ToString();
            }
            else
            {
                number2 = (number2 * 10) + 3;
                Display.Text = number2.ToString();
            }
        }

        void Handle_Clicked4(object sender, System.EventArgs e)
        {
            if (operation == "")
            {
                number1 = (number1 * 10) + 4;
                Display.Text = number1.ToString();
            }
            else
            {
                number2 = (number2 * 10) + 4;
                Display.Text = number2.ToString();
            }
        }

        void Handle_Clicked5(object sender, System.EventArgs e)
        {
            if (operation == "")
            {
                number1 = (number1 * 10) + 5;
                Display.Text = number1.ToString();
            }
            else
            {
                number2 = (number2 * 10) + 5;
                Display.Text = number2.ToString();
            }
        }

        void Handle_Clicked6(object sender, System.EventArgs e)
        {
            if (operation == "")
            {
                number1 = (number1 * 10) + 6;
                Display.Text = number1.ToString();
            }
            else
            {
                number2 = (number2 * 10) + 6;
                Display.Text = number2.ToString();
            }
        }

        void Handle_Clicked7(object sender, System.EventArgs e)
        {
            if (operation == "")
            {
                number1 = (number1 * 10) + 7;
                Display.Text = number1.ToString();
            }
            else
            {
                number2 = (number2 * 10) + 7;
                Display.Text = number2.ToString();
            }
        }

        void Handle_Clicked8(object sender, System.EventArgs e)
        {
            if (operation == "")
            {
                number1 = (number1 * 10) + 8;
                Display.Text = number1.ToString();
            }
            else
            {
                number2 = (number2 * 10) + 8;
                Display.Text = number2.ToString();
            }
        }

        void Handle_Clicked9(object sender, System.EventArgs e)
        {
            if (operation == "")
            {
                number1 = (number1 * 10) + 9;
                Display.Text = number1.ToString();
            }
            else
            {
                number2 = (number2 * 10) + 9;
                Display.Text = number2.ToString();
            }
        }

        void Handle_Clicked0(object sender, System.EventArgs e)
        {
            if (operation == "")
            {
                number1 = number1 * 10;
                Display.Text = number1.ToString();
            }
            else
            {
                number2 = number2 * 10;
                Display.Text = number2.ToString();
            }
        }

        void Handle_Clicked_divide(object sender, System.EventArgs e)
        {
            operation = "/";
            Display.Text = "";
        }

        void Handle_Clicked_times(object sender, System.EventArgs e)
        {
            operation = "*";
            Display.Text = "";
        }

        void Handle_Clicked_plus(object sender, System.EventArgs e)
        {
            operation = "+";
            Display.Text = "";
        }

        void Handle_Clicked_minus(object sender, System.EventArgs e)
        {
            operation = "-";
            Display.Text = "";
        }

        void Handle_Clicked_equal(object sender, System.EventArgs e)
        {

            var result = MathEvaluator.Evaluate(Display.Text);
            Display.Text = result.ToString();

            switch (operation)
            {
                case "+":
                    Display.Text = (number1 + number2).ToString();
                    break;

                case "-":
                    Display.Text = (number1 - number2).ToString();
                    break;

                case "*":
                    Display.Text = (number1 * number2).ToString();
                    break;

                case "/":
                    Display.Text = (number1 / number2).ToString();
                    break;
            }
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            operation = "";
            number1 = 0;
            number2 = 0;
            Display.Text = "";

            speechRecognitionInstnace.Stop();
            ButtonStart.BackgroundColor = Color.FromHex("#96ca2d");
        }





    }
}
