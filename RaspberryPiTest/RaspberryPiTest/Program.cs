using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PiSharp.LibGpio;
using PiSharp.LibGpio.Entities;

namespace RaspberryPiTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LibGpio.Gpio.SetupChannel(BroadcomPinNumber.Four, Direction.Output);
            LibGpio.Gpio.SetupChannel(BroadcomPinNumber.Seventeen, Direction.Output);
            LibGpio.Gpio.SetupChannel(BroadcomPinNumber.Eighteen, Direction.Output);
            LibGpio.Gpio.SetupChannel(BroadcomPinNumber.TwentyOne, Direction.Output);
            LibGpio.Gpio.SetupChannel(BroadcomPinNumber.TwentyTwo, Direction.Output);
            LibGpio.Gpio.SetupChannel(BroadcomPinNumber.TwentyThree, Direction.Output);
            LibGpio.Gpio.SetupChannel(BroadcomPinNumber.TwentyFour, Direction.Output);
            LibGpio.Gpio.SetupChannel(BroadcomPinNumber.TwentyFive, Direction.Output);

            while (true)
            {
                LibGpio.Gpio.OutputValue(BroadcomPinNumber.Four, true);
                Thread.Sleep(200);
                LibGpio.Gpio.OutputValue(BroadcomPinNumber.Seventeen, true);
                Thread.Sleep(200);
                LibGpio.Gpio.OutputValue(BroadcomPinNumber.Eighteen, true);
                Thread.Sleep(200);
                LibGpio.Gpio.OutputValue(BroadcomPinNumber.TwentyOne, true);
                Thread.Sleep(200);
                LibGpio.Gpio.OutputValue(BroadcomPinNumber.TwentyTwo, true);
                Thread.Sleep(200);
                LibGpio.Gpio.OutputValue(BroadcomPinNumber.TwentyThree, true);
                Thread.Sleep(200);
                LibGpio.Gpio.OutputValue(BroadcomPinNumber.TwentyFour, true);
                Thread.Sleep(200);
                LibGpio.Gpio.OutputValue(BroadcomPinNumber.TwentyFive, true);
                Thread.Sleep(200);

                LibGpio.Gpio.OutputValue(BroadcomPinNumber.Four, false);
                Thread.Sleep(200);
                LibGpio.Gpio.OutputValue(BroadcomPinNumber.Seventeen, false);
                Thread.Sleep(200);
                LibGpio.Gpio.OutputValue(BroadcomPinNumber.Eighteen, false);
                Thread.Sleep(200);
                LibGpio.Gpio.OutputValue(BroadcomPinNumber.TwentyOne, false);
                Thread.Sleep(200);
                LibGpio.Gpio.OutputValue(BroadcomPinNumber.TwentyTwo, false);
                Thread.Sleep(200);
                LibGpio.Gpio.OutputValue(BroadcomPinNumber.TwentyThree, false);
                Thread.Sleep(200);
                LibGpio.Gpio.OutputValue(BroadcomPinNumber.TwentyFour, false);
                Thread.Sleep(200);
                LibGpio.Gpio.OutputValue(BroadcomPinNumber.TwentyFive, false);
                Thread.Sleep(200);
            }
        }
    }
}
