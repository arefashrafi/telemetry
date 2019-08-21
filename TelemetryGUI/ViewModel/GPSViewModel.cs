using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Device.Location;
using System.Diagnostics;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Maps.MapControl.WPF;
using Telemetry.App;
using TelemetryDependencies.Models;
using TelemetryGUI.Util;

namespace TelemetryGUI.ViewModel
{
    public class GpsViewModel : INotifyPropertyChanged
    {
        private double _distanceBetweenGps;
        private Gps _gpsDirect = new Gps();
        private Gps _gpsExternal = new Gps();
        private LocationCollection _locationCollectionDirect = new LocationCollection();
        private LocationCollection _locationCollectionExternal = new LocationCollection();
        private Location _locationDirect = new Location();
        private Location _locationExternal = new Location();

        public GpsViewModel()
        {
            WeakEventManager<EventSource, EntityEventArgs>.AddHandler(null, nameof(EventSource.EventGps), OnTick);
            LoadPreviousData();
        }

        public LocationCollection LocationCollectionExternal
        {
            get => _locationCollectionExternal;
            set
            {
                _locationCollectionExternal = value;
                OnPropertyChanged("LocationCollectionExternal");
            }
        }

        public LocationCollection LocationCollectionDirect
        {
            get => _locationCollectionDirect;
            set
            {
                _locationCollectionDirect = value;
                OnPropertyChanged("LocationCollectionDirect");
            }
        }

        public Location LocationDirect
        {
            get => _locationDirect;
            set
            {
                _locationDirect = value;
                OnPropertyChanged("LocationDirect");
            }
        }

        public Location LocationExternal
        {
            get => _locationExternal;
            set
            {
                _locationExternal = value;
                OnPropertyChanged("LocationExternal");
            }
        }

        public Gps GpsSourceDirect
        {
            get => _gpsDirect;
            set
            {
                _gpsDirect = value;
                OnPropertyChanged("GpsSourceDirect");
            }
        }

        public Gps GpsSourceExternal
        {
            get => _gpsExternal;
            set
            {
                _gpsExternal = value;
                OnPropertyChanged("GpsSourceExternal");
            }
        }

        public double DistanceBetweenGps
        {
            get => _distanceBetweenGps;
            set
            {
                _distanceBetweenGps = value;
                OnPropertyChanged("DistanceBetweenGps");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private async void LoadPreviousData()
        {
            List<Gps> gpsCollection;
            try
            {
                using (TelemetryContext context = new TelemetryContext())
                {
                    gpsCollection = await context.GPSs.ToListAsync();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }

            foreach (Gps item in gpsCollection)
            {
                switch (item.DeviceId)
                {
                    case 0:
                        _locationCollectionDirect.Add(new Location
                        {
                            Altitude = item.Alt,
                            Latitude = item.Lat,
                            Longitude = item.Long
                        });
                        break;
                    case 1:
                        _locationCollectionExternal.Add(new Location
                        {
                            Altitude = item.Alt,
                            Latitude = item.Lat,
                            Longitude = item.Long
                        });
                        break;
                }
            }
        }


        private void OnTick(object sender, EntityEventArgs e)
        {
            if (!(e.Data is Gps gps)) return;

            switch (gps.DeviceId)
            {
                case 0:
                    _gpsDirect = gps;
                    GpsSourceDirect = _gpsDirect;
                    _locationDirect.Altitude = _gpsDirect.Alt;
                    _locationDirect.Latitude = _gpsDirect.Lat;
                    _locationDirect.Longitude = _gpsDirect.Long;
                    Application.Current.Dispatcher.Invoke(() => { _locationCollectionDirect.Add(_locationDirect); });
                    break;
                case 1:
                    _gpsExternal = gps;
                    GpsSourceExternal = _gpsExternal;
                    _locationExternal.Altitude = _gpsExternal.Alt;
                    _locationExternal.Latitude = _gpsExternal.Lat;
                    _locationExternal.Longitude = _gpsExternal.Long;
                    Application.Current.Dispatcher.Invoke(() => { _locationCollectionExternal.Add(_locationExternal); });
                    break;
            }

            Application.Current.Dispatcher.Invoke(() =>
            {
                if (_locationCollectionExternal.Count > 1000) _locationCollectionExternal.RemoveAt(0);
                if (_locationCollectionDirect.Count > 1000) _locationCollectionDirect.RemoveAt(0);
            });

            CalculateDistance();
        }

        private void CalculateDistance()
        {
            try
            {
                GeoCoordinate directGps = new GeoCoordinate(_gpsDirect.Lat, _gpsDirect.Long);
                GeoCoordinate externalGps = new GeoCoordinate(_gpsExternal.Lat, _gpsExternal.Long);

                _distanceBetweenGps = externalGps.GetDistanceTo(directGps);
            }
            catch (ArgumentNullException e)
            {
                Trace.WriteLine(e);
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}