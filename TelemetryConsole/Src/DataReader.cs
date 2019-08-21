using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using Telemetry.App;
using TelemetryConsole.Misc;
using TelemetryConsole.Wifi;
using TelemetryDependencies.Models;
using Timer = System.Timers.Timer;

namespace TelemetryConsole
{
    public static class DataReader
    {
        private static readonly Timer MessageTimer = new Timer();
        private static Message _message = new Message();

        private static SerialPort SerialPort { get; set; }

        private static void StartTimer()
        {
            MessageTimer.Interval = 1000;
            MessageTimer.Enabled = true;
            MessageTimer.Start();
            MessageTimer.Elapsed += MessageTimerOnElapsed;
        }

        private static void MessageTimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                using (TelemetryContext context = new TelemetryContext())
                {
                    Message message = context.Messages.LastOrDefault();
                    if (message != null && DateTime.Now > message.DateTime.AddSeconds(1)) return;
                    if (message == _message || message == null) return;
                    _message = message;
                }

                var byteArray = new List<byte>();

                //Check if command or text message
                if (_message.Prefix == "$#!T")
                {
                    byte[] valueBytes = Encoding.GetEncoding("ASCII").GetBytes(_message.Text);
                    byte[] prefixBytes = Encoding.GetEncoding("ASCII").GetBytes(_message.Prefix);
                    byteArray.AddRange(prefixBytes);
                    byteArray.Add((byte) _message.MessageId);
                    byteArray.Add((byte) _message.Length);
                    byteArray.AddRange(valueBytes);
                    byteArray.AddRange(new byte[] {0x0D, 0x0A});
                    if (SerialPort.IsOpen)
                        foreach (byte data in byteArray)
                        {
                            //Keep sleep, otherwise the data is corrupted on otherside. This is a baudrate issue
                            Thread.Sleep(1);
                            if (!SerialPort.IsOpen) SerialPort.Write(new[] {data}, 0, 1);
                        }
                    else
                        AsynchronousSocketListener.Send(byteArray.ToArray());
                }
                else
                {
                    byte[] prefixBytes = Encoding.GetEncoding("ASCII").GetBytes(_message.Prefix);
                    byteArray.AddRange(prefixBytes);
                    byteArray.AddRange(Encoding.GetEncoding("ASCII").GetBytes(_message.Text));
                    byteArray.AddRange(new byte[] {0x0D, 0x0A});
                    if (SerialPort.IsOpen)
                        foreach (byte data in byteArray)
                        {
                            //Keep sleep, otherwise the data is corrupted on otherside. This is a baudrate issue
                            Thread.Sleep(1);
                            SerialPort.Write(new[] {data}, 0, 1);
                        }
                    else
                        AsynchronousSocketListener.Send(byteArray.ToArray());
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private static void DataReceiveHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                var tempBuffer = new byte[SerialPort.BytesToRead];
                SerialPort.Read(tempBuffer, 0, tempBuffer.Length);
                foreach (byte singleByte in tempBuffer)
                {
                    Constants.RxByteQueue.Enqueue(singleByte);
                }
            }
            catch (Exception exception)
            {
                Extensions.PrintProperties(exception);
            }
        }


        public static void StartListener()
        {
            StartTimer();
            Console.WriteLine("Trying to initiate Serial Port");
            string portName = ConfigurationManager.AppSettings["DATACOMPORT"];
            if (SerialPort.GetPortNames().Any(x => x == portName)) Console.WriteLine("trying to open port");

            SerialPort = new SerialPort
            {
                PortName = portName,
                BaudRate = 115200,
                Parity = Parity.None,
                DataBits = 8,
                StopBits = StopBits.One,
                DtrEnable = true
            };
            try
            {
                SerialPort.Open();
                SerialPort.DataReceived += DataReceiveHandler;

                Console.WriteLine(
                    $"SerialPort Opened: Settings:{SerialPort.PortName}, Baudrate:{SerialPort.BaudRate}, isOpen:{SerialPort.IsOpen}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}