using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Weather
{
    public enum Weather
    {
        Clear,
        Cloudy,
        Overcast
    }
    public partial class Form1 : Form
    {
        private Weather State = Weather.Clear;
        private int HourCount = 0;
        private int t = 0;
        private int countClear = 0;
        private int countCloudy = 0;
        private int countOvercast = 0;

        private Random rand = new Random();
        private double[,] qMatrix = new double[3, 3] { { -0.4, 0.3, 0.1 }, { 0.4, -0.8, 0.4 }, { 0.1, 0.4, -0.5 } };

        public Form1()
        {
            InitializeComponent();
        }

        private void start_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var q = rand.NextDouble() * (1 - (-1)) - 1;
            randomNumber.Text = q.ToString();
            Text = (HourCount / 24).ToString();
            var currentDay = (int)State;
            for(int i = 0; i < 3; i++)
            {
                if (i == currentDay)
                    continue;

                if (q > qMatrix[currentDay, i])
                {
                    State = (Weather)i;
                    break;
                }
                else
                {
                    State = (Weather)currentDay;
                }

            }
            switch (State)
            {
                case Weather.Clear:
                    countClear++;
                    label1.Text = $"Ясно {countClear}";
                    break;
                case Weather.Cloudy:
                    countCloudy++;
                    label2.Text = $"Облачно {countCloudy}";
                    break;
                case Weather.Overcast:
                    countOvercast++;
                    label3.Text = $"Пасмурно {countOvercast}";
                    break;
            }
            HourCount++;
            weatherState.Text = State.ToString();
        }
    }
}
