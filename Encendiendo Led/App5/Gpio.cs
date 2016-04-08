using Windows.Devices.Gpio;

namespace App5
{
    internal class Gpio
    {
        public GpioPin pin { get; set; }
        public GpioPinValue pinValue { get; set; }

        public Gpio(int ledPin)
        {
            pin = GpioController.GetDefault().OpenPin(ledPin);
            pinValue = GpioPinValue.High;
            pin.Write(pinValue);
            pin.SetDriveMode(GpioPinDriveMode.Output);
        }
    }
}