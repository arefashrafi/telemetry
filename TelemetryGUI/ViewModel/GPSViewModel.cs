using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Device.Location;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using TelemetryDependencies.Models;
using TelemetryGUI.Util;
using Microsoft.Maps.MapControl.WPF;
using System.Windows.Threading;
using System;

namespace TelemetryGUI.ViewModel
{
    public class GPSViewModel
    {
        public PropertyChangedEventHandler PropertyChanged;
        private double _distanceBetweenGps;
        private Gps _gpsDirect = new Gps();
        private Gps _gpsExternal = new Gps();
        private Location _locationDirect=new Location();
        private Location _locationExternal=new Location();
        private LocationCollection _locationCollectionDirect = new LocationCollection();
        private LocationCollection _locationCollectionExternal = new LocationCollection();
        public GPSViewModel()
        {
            WeakEventManager<EventSource, EntityEventArgs>.AddHandler(null, nameof(EventSource.Event), OnTick);
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
                OnPropertyChanged("DistanceBetweenGPS");
            }
        }

       

        private void OnTick(object sender, EntityEventArgs e)
        {
            if (!(e.Data is Gps gps)) return;
            if (gps.DeviceId == 0)
            {
                _gpsDirect = gps;
                _locationDirect.Altitude = _gpsDirect.ALT;
                _locationDirect.Latitude = _gpsDirect.LAT;
                _locationDirect.Longitude = _gpsDirect.LONG;
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(

                    () => _locationCollectionDirect.Add(_locationDirect)
                ));

            }
            else if (gps.DeviceId == 1)
            {
                _gpsExternal = gps;
                _locationExternal.Altitude = _gpsExternal.ALT;
                _locationExternal.Latitude = _gpsExternal.LAT;
                _locationExternal.Longitude = _gpsExternal.LONG;
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(

                            () => _locationCollectionExternal.Add(_locationExternal)
                            ));
               
            }
            CalculateDistance();
            
        }

        private void CalculateDistance()
        {
            if (_gpsDirect == null) return;
            if (_gpsExternal == null) return;
            var directGps = new GeoCoordinate(_gpsDirect.LAT, _gpsDirect.LONG);
            var externalGps = new GeoCoordinate(_gpsExternal.LAT, _gpsExternal.LONG);

            _distanceBetweenGps = externalGps.GetDistanceTo(directGps);
        }
       
        // Create the OnPropertyChanged method to raise the event
        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}