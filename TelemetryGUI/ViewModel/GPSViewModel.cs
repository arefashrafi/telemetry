using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Device.Location;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using Microsoft.EntityFrameworkCore;
using Microsoft.Maps.MapControl.WPF;
using SharpDX.Direct3D11;
using TelemetryDependencies.Models;
using TelemetryGUI.Annotations;
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
                OnPropertyChanged();
            }
        }

        public LocationCollection LocationCollectionDirect
        {
            get => _locationCollectionDirect;
            set
            {
                _locationCollectionDirect = value;
                OnPropertyChanged();
            }
        }

        public Location LocationDirect
        {
            get => _locationDirect;
            set
            {
                _locationDirect = value;
                OnPropertyChanged();
            }
        }

        public Location LocationExternal
        {
            get => _locationExternal;
            set
            {
                _locationExternal = value;
                OnPropertyChanged();
            }
        }

        public Gps GpsSourceDirect
        {
            get => _gpsDirect;
            set
            {
                _gpsDirect = value;
                OnPropertyChanged();
            }
        }

        public Gps GpsSourceExternal
        {
            get => _gpsExternal;
            set
            {
                _gpsExternal = value;
                OnPropertyChanged();
            }
        }

        public double DistanceBetweenGps
        {
            get => _distanceBetweenGps;
            set
            {
                _distanceBetweenGps = value;
                OnPropertyChanged();
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
                if (item.DeviceId == 1)
                {
                    _locationCollectionExternal.Add(new Location
                    {
                        Altitude = item.ALT,
                        Latitude = item.LAT,
                        Longitude = item.LONG
                    });
                }
                else
                {
                    _locationCollectionDirect.Add(new Location
                    {
                        Altitude = item.ALT,
                        Latitude = item.LAT,
                        Longitude = item.LONG
                    });
                }

            }

        }


        private void OnTick(object sender, EntityEventArgs e)
        {

            var x = e.Data;
            if (!(e.Data is Gps gps)) return;
            
            switch (gps.DeviceId)
            {
                case 0:
                    _gpsDirect = gps;
                    GpsSourceDirect = _gpsDirect;
                    _locationDirect.Altitude = _gpsDirect.ALT;
                    _locationDirect.Latitude = _gpsDirect.LAT;
                    _locationDirect.Longitude = _gpsDirect.LONG;
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(
                                                                                                () => _locationCollectionDirect.Add(_locationDirect)
                                                                                               ));
                    break;
                case 1:
                    _gpsExternal = gps;
                    GpsSourceExternal = _gpsExternal;
                    _locationExternal.Altitude = _gpsExternal.ALT;
                    _locationExternal.Latitude = _gpsExternal.LAT;
                    _locationExternal.Longitude = _gpsExternal.LONG;
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(
                                                                                                () => _locationCollectionExternal.Add(_locationExternal)
                                                                                               ));
                    break;
            }
            if (_locationCollectionExternal.Count > 10000) _locationCollectionExternal.RemoveAt(0);
            if (_locationCollectionDirect.Count > 10000) _locationCollectionDirect.RemoveAt(0);
            CalculateDistance();
        }

        private void CalculateDistance()
        {
            if (_gpsDirect == null) return;
            if (_gpsExternal == null) return;
            GeoCoordinate directGps = new GeoCoordinate(_gpsDirect.LAT, _gpsDirect.LONG);
            GeoCoordinate externalGps = new GeoCoordinate(_gpsExternal.LAT, _gpsExternal.LONG);

            _distanceBetweenGps = externalGps.GetDistanceTo(directGps);
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}