using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace SelectOne
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        DateTimeOffset d;
        TimeSpan time = new TimeSpan(0, 0, 4);
        Random random;
        Queue<string> history = new Queue<string>();
        int historyCount = 6;
        double frequency = 0.01;
        List<string> data = new List<string>();

        public MainWindow()
        {
            InitializeComponent();

            string text = string.Empty;
            if (File.Exists("data.txt"))
            {
                text = File.ReadAllText("data.txt");
            }
            else
            {
                MessageBox.Show("data.txt 文件不存在！", "Error");
                this.Close();
                return;
            }

            char[] separators = new char[] { '\n', ' ' };
            data.AddRange(text.Split(separators, StringSplitOptions.RemoveEmptyEntries));
            if (data.Count <= historyCount)
            {
                MessageBox.Show($"单位数量少于{historyCount}", "Error");
                this.Close();
            }
            else if (data.Count > historyCount)
            {
                for (int i = 0; i < historyCount; i++)
                {
                    history.Enqueue(data[i]);
                }
            }

            timer = new DispatcherTimer(DispatcherPriority.Send);
            timer.Interval = TimeSpan.FromSeconds(frequency);
            timer.Tick += SwitchName;
        }

        private void SwitchName(object sender, EventArgs e)
        {
            double internalTime = (DateTimeOffset.Now - d).TotalSeconds;
            double timePoint1 = time.TotalSeconds * 0.15;
            double timePoint2 = time.TotalSeconds * 0.3;
            double timePoint3 = time.TotalSeconds * 0.45;
            double timePoint4 = time.TotalSeconds * 0.6;
            double timePoint5 = time.TotalSeconds * 0.75;
            double timePoint6 = time.TotalSeconds * 0.9;

            if (internalTime > time.TotalSeconds)
            {
                timer.Stop();
                StartButton.IsEnabled = true;
                NameBoard.Foreground = Brushes.Red;
                return;
            }
            else if (internalTime > timePoint6)
            {
                timer.Interval = TimeSpan.FromSeconds(0.64);
            }
            else if (internalTime > timePoint5)
            {
                timer.Interval = TimeSpan.FromSeconds(0.32);
            }
            else if (internalTime > timePoint4)
            {
                timer.Interval = TimeSpan.FromSeconds(0.16);
            }
            else if (internalTime > timePoint3)
            {
                timer.Interval = TimeSpan.FromSeconds(0.08);
            }
            else if (internalTime > timePoint2)
            {
                timer.Interval = TimeSpan.FromSeconds(0.04);
            }
            else if (internalTime > timePoint1)
            {
                timer.Interval = TimeSpan.FromSeconds(0.02);
            }

            int selectIndex = random.Next(data.Count);

            while (CheckHaveTheSame(history, data[selectIndex]))
            {
                selectIndex = random.Next(data.Count);
            }

            history.Enqueue(data[selectIndex]);
            history.Dequeue();
            NameBoard.Text = data[selectIndex].ToString();
        }

        private bool CheckHaveTheSame(IEnumerable<string> list, string name)
        {
            foreach (var n in list)
            {
                if (n == name)
                    return true;
            }
            return false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StartButton.IsEnabled = false;
            NameBoard.Foreground = Brushes.Black;
            timer.Interval = TimeSpan.FromSeconds(frequency);

            random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);

            d = DateTimeOffset.Now;
            timer.Start();
        }
    }
}
