using GalaSoft.MvvmLight;
using System.Collections.Generic;
using TempConverter.Services;
using TempConverter.App.Extensions;
using OxyPlot;
using System;
using System.Linq;

namespace TempConverter.App.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly ITempConverter _converter;
        private readonly ITempStorage _storage;

        private double? _celsius;
        private double? _farenheit;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(ITempConverter converter, ITempStorage storage)
        {
            _converter = converter;
            _storage = storage;
            //_celsius = 36.6; //body temp


            // quick graph fill-up
            foreach(double i in Enumerable.Range(-40, 100)) {
                _celsius = Math.Sin(i / 10.0) * 10.0;
                _farenheit = _converter.Convert(_celsius.Value, ConversionType.CelsiusToFarenheit);
                _storage.AddCelsius(_celsius.Value);
                _storage.AddFarenheit(_farenheit.Value);
            }
        }

        public double FarenheitValue 
        {
            get
            {
                var val =_farenheit.HasValue 
                    ? _farenheit.Value
                    : _converter.Convert(_celsius.Value, ConversionType.CelsiusToFarenheit);
                _storage.AddFarenheit(val);
                return val;
            }
            set
            {
                _farenheit = value;
                _celsius = null;
                this.RaisePropertyChanged("CelsiusValue");
                this.RaisePropertyChanged("PlotModel");
            }
        }

        public double CelsiusValue
        {
            get
            {
                var val = _celsius.HasValue 
                    ? _celsius.Value 
                    : _converter.Convert(_farenheit.Value, ConversionType.FarenheitToCelsius);
                _storage.AddCelsius(val);
                return val;
            }
            set
            {
                _celsius = value;
                _farenheit = null;
                this.RaisePropertyChanged("FarenheitValue");
                this.RaisePropertyChanged("PlotModel");
            }
        }

        public PlotModel PlotModel
        {
            get
            {
                return _storage.GetPlotModel();
            }
        }
        
    }
}