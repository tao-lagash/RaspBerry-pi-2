using System;
using System.Diagnostics;
using Windows.Devices.Gpio;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace App5
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Gpio gpio;
        private DispatcherTimer timer;

        public MainPage()
        {
            this.InitializeComponent();
            gpio = new Gpio(21);
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(300);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, object e)
        {
            Debug.WriteLine("start, pinvalue => " + gpio.pinValue.ToString());
            if (gpio.pinValue == GpioPinValue.High)
            {
                gpio.pinValue = GpioPinValue.Low;
                gpio.pin.Write(gpio.pinValue);
            }
            else
            {
                gpio.pinValue = GpioPinValue.High;
                gpio.pin.Write(gpio.pinValue);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            gpio.pin.Write(GpioPinValue.High);
            gpio.pinValue = GpioPinValue.High;
            timer.Stop();
        }
    }
}