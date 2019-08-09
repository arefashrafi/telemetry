﻿using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.EntityFrameworkCore;
using Telemetry.App;
using TelemetryConsole.Misc;
using TelemetryDependencies.Models;

namespace TelemetryConsole
{
    public class DataReader : Constants
    {
        private static SerialPort SerialPort { get; set; }
        private static System.Timers.Timer _messageTimer = new System.Timers.Timer();
        private static Message _message = new Message();
        public DataReader()
        {
            

        }

        private static void StartTimer()
        {
            _messageTimer.Interval = 1000;
            _messageTimer.Enabled = true;
            _messageTimer.Start();
            _messageTimer.Elapsed += MessageTimerOnElapsed;
        }

        private static void MessageTimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                using (var context = new TelemetryContext())
                {
                    var message = context.Messages.LastOrDefault();
                    if(message != null && DateTime.Now>message.DateTime.AddSeconds(1)) return;
                    if (message == _message || message==null) return;
                    _message = message;
                }

                List<byte> byteArray = new List<byte>();

                //Check if command or text message
                if (_message.Prefix == "$#!T")
                {
                    byte[] valueBytes = Encoding.GetEncoding("ASCII").GetBytes(_message.Text);
                    byte[] prefixBytes = Encoding.GetEncoding("ASCII").GetBytes(_message.Prefix);
                    byteArray.AddRange(prefixBytes);
                    byteArray.Add((byte)_message.MessageId);
                    byteArray.Add((byte)_message.Length);
                    byteArray.AddRange(valueBytes);
                    byteArray.AddRange(new byte[]{0x0D,0x0A});
                    foreach (byte data in byteArray)
                    {
                        //Keep sleep, otherwise the data is corrupted on otherside. This is a baudrate issue
                        Thread.Sleep(1);
                        SerialPort.Write(new byte[]{data},0,1); 
                    }
                }
                else
                {

                    byte[] prefixBytes = Encoding.GetEncoding("ASCII").GetBytes(_message.Prefix);
                    byteArray.AddRange(prefixBytes);
                    byteArray.AddRange(Encoding.GetEncoding("ASCII").GetBytes(_message.Text));
                    byteArray.AddRange(new byte[]{0x0D,0x0A});
                    foreach (byte data in byteArray)
                    {
                        //Keep sleep, otherwise the data is corrupted on otherside. This is a baudrate issue
                        Thread.Sleep(1);
                        SerialPort.Write(new byte[]{data},0,1); 
                    }
                    
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
                byte[] tempBuffer = new byte[SerialPort.BytesToRead];
                SerialPort.Read(tempBuffer, 0, tempBuffer.Length);
                foreach (byte singleByte in tempBuffer) RxByteQueue.Enqueue(singleByte);
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
            if (SerialPort.GetPortNames().Any(x => x != portName))
            {
                Console.WriteLine("Failed to open serial port");
                return;
            }
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
                SerialPort.DataReceived += DataReceiveHandler;

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
                    context.SaveChanges();
                }
            }
        }
    }
}