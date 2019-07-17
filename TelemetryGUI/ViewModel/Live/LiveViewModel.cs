// *************************************************************************************
// SCICHART� Copyright SciChart Ltd. 2011-2018. All rights reserved.
//  
// Web: http://www.scichart.com
//   Support: support@scichart.com
//   Sales:   sales@scichart.com
// 
// EEGExampleViewModel.cs is part of the SCICHART� Examples. Permission is hereby granted
// to modify, create derivative works, distribute and publish any part of this source
// code whether for commercial, private or personal use. 
// 
// The SCICHART� examples are distributed in the hope that they will be useful, but
// without any warranty. It is provided "AS IS" without warranty of any kind, either
// expressed or implied. 
// *************************************************************************************

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using SciChart.Charting.Common.Helpers;
using SciChart.Charting.Model.DataSeries;
using SciChart.Core.Extensions;
using SciChart.Examples.ExternalDependencies.Common;
using TelemetryDependencies.Models;
using TelemetryGUI.Util;

namespace TelemetryGUI.ViewModel.Live
{
    public class LiveViewModel : BaseViewModel
    {
        private const int Size = 1000000; // Size of each channel in points (FIFO Buffer)

        private readonly IList<Color> _colors = new[]
        {
            Colors.White, Colors.Yellow, Color.FromArgb(255, 0, 128, 128), Color.FromArgb(255, 176, 196, 222),
            Color.FromArgb(255, 255, 182, 193), Colors.Purple, Color.FromArgb(255, 245, 222, 179),
            Color.FromArgb(255, 173, 216, 230),
            Color.FromArgb(255, 250, 128, 114), Color.FromArgb(255, 144, 238, 144), Colors.Orange,
            Color.FromArgb(255, 192, 192, 192),
            Color.FromArgb(255, 255, 99, 71), Color.FromArgb(255, 205, 133, 63), Color.FromArgb(255, 64, 224, 208),
            Color.FromArgb(255, 244, 164, 96)
        };

        private readonly ActionCommand _resetCommand;
        private readonly ActionCommand _startCommand;
        private readonly ActionCommand _stopCommand;
        private string _bmsProperty;
        private ObservableCollection<LiveChannelViewModel> _channelViewModels;
        private volatile int _currentSize;
        private bool _isReset;

        // X, Y buffers used to buffer data into the Scichart instances in blocks of BufferSize

        private bool _running;
        private readonly object _syncRoot = new object();
        private bool _firstRead;

        public LiveViewModel()
        {
            _startCommand = new ActionCommand(Start, () => !IsRunning);
            _stopCommand = new ActionCommand(Stop, () => IsRunning);
            _resetCommand = new ActionCommand(Reset, () => !IsRunning && !IsReset);
        }

        public ObservableCollection<LiveChannelViewModel> ChannelViewModels
        {
            get => _channelViewModels;
            set
            {
                _channelViewModels = value;
                OnPropertyChanged("ChannelViewModels");
            }
        }

        public string BmsProperty
        {
            get => _bmsProperty;
            set
            {
                _bmsProperty = value;
                AddToChannelViewModels(value);
                OnPropertyChanged("BmsProperty");
            }
        }


        public ICommand StartCommand => _startCommand;

        public ICommand StopCommand => _stopCommand;

        public ICommand ResetCommand => _resetCommand;


        public bool IsReset
        {
            get => _isReset;
            set
            {
                _isReset = value;

                _startCommand.RaiseCanExecuteChanged();
                _stopCommand.RaiseCanExecuteChanged();
                _resetCommand.RaiseCanExecuteChanged();

                OnPropertyChanged("IsReset");
            }
        }

        public bool IsRunning
        {
            get => _running;
            set
            {
                _running = value;

                _startCommand.RaiseCanExecuteChanged();
                _stopCommand.RaiseCanExecuteChanged();
                _resetCommand.RaiseCanExecuteChanged();

                OnPropertyChanged("IsRunning");
            }
        }

        private void Start()
        {
            if (_channelViewModels == null || _channelViewModels.Count == 0) Reset();

            if (!IsRunning)
            {
                IsRunning = true;
                IsReset = false;
                WeakEventManager<EventSource, EntityEventArgs>.AddHandler(null, nameof(EventSource.EventBms), OnTick);


                WeakEventManager<EventSource, EntityEventArgs>.AddHandler(null, nameof(EventSource.EventMotor), OnTick);
            }
        }

        private void Stop()
        {
            if (IsRunning)
            {
                WeakEventManager<EventSource, EntityEventArgs>.RemoveHandler(null, nameof(EventSource.EventBms),
                    OnTick);
                WeakEventManager<EventSource, EntityEventArgs>.RemoveHandler(null, nameof(EventSource.EventMotor),
                    OnTick);
                IsRunning = false;
            }
        }

        private void Reset()
        {
            Stop();
            ChannelViewModels = new ObservableCollection<LiveChannelViewModel>();
            IsReset = true;
        }

        private void OnTick(object sender, EntityEventArgs e)
        {
            if (_channelViewModels.IsEmpty()) return;

            lock (_syncRoot)
            {
                foreach (LiveChannelViewModel channel in _channelViewModels)
                {
                    if (e.Data.GetType().GetProperty(channel.ChannelName).CanRead == false) return;

                    IXyDataSeries<DateTime, double> dataSeries = channel.ChannelDataSeries;
                    DateTime dateTime = DateTime.ParseExact(e.Time, "yyyy-MM-dd HH:mm:ss.fff",
                        CultureInfo.InvariantCulture);
                    try
                    {
                        if (dateTime > dataSeries.XValues.LastOrDefault().AddSeconds(20) || !_firstRead)
                        {
                            dataSeries.Append(dateTime, double.NaN);
                            _firstRead = true;
                        }
                        else
                        {
                            var yValue =
                                Convert.ToDouble(e.Data.GetType().GetProperty(channel.ChannelName)
                                    ?.GetValue(e.Data, null));
                            // Append block of values

                            dataSeries.Append(dateTime, yValue);
                            // For reporting current size to GUI
                            _currentSize = dataSeries.Count;
                        }
                    }
                    catch (Exception exception)
                    {
                        throw;
                    }
                }
            }
        }

        private void AddToChannelViewModels(string channelName)
        {


            _channelViewModels.Add(new LiveChannelViewModel(Size, _colors[4])
            {
                ChannelName = channelName
            });
        }
    }
}