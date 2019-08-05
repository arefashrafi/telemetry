using System;
using System.Collections.Concurrent;
using System.Configuration;
using System.Globalization;
using System.IO.Ports;
using TelemetryConsole.Misc;
using TelemetryDependencies.Models;

namespace TelemetryConsole
{
    public class DataReader : Constants
    {
        private SerialPort SerialPort { get; set; }


        public DataReader()
        {
            InitiatePort();
            SerialPort.DataReceived += DataReceiveHandler;
        }

        private void DataReceiveHandler(object sender, SerialDataReceivedEventArgs e)
        {
            if (!SerialPort.IsOpen) return;
            try
            {
                byte[] tempBuffer = new byte[SerialPort.BytesToRead];
                SerialPort.Read(tempBuffer, 0, tempBuffer.Length);
                foreach (byte singleByte in tempBuffer) RxByteQueue.Enqueue(singleByte);
                SerialPort.DiscardInBuffer();
            }
            catch (Exception exception)
            {
                Extensions.PrintProperties(exception);
            }
        }

        private void InitiatePort()
        {
            Console.WriteLine("Trying to initiate Serial Port");
            string portName = ConfigurationManager.AppSettings["DATACOMPORT"];
            try
            {
                SerialPort = new SerialPort
                {
                    PortName = portName,
                    BaudRate = 115200,
                    Parity = Parity.None,
                    DataBits = 8,
                    StopBits = StopBits.One,
                    DtrEnable = true
                };
                SerialPort.Open();

                Console.WriteLine(
                    $"SerialPort Settings:{SerialPort.PortName}, Baudrate:{SerialPort.BaudRate}, isOpen:{SerialPort.IsOpen}");
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("Cant find open port");
                using (var context = new TelemetryContext())
                {
                    context.Errors.Add(new Error
                    {
                        ExceptionSource = e.Source,
                        Message = e.Message,
                        Time = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)
                    });
                }
            }
        }
    }
}