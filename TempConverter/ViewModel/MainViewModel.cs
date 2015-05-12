using GalaSoft.MvvmLight;
using TempConverter.Services;

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
        private double? _celsius;
        private double? _farenheit;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(ITempConverter converter)
        {
            this._converter = converter;
            _celsius = 0;
        }

        public double FarenheitValue 
        {
            get
            {
                return _farenheit.HasValue 
                    ? _farenheit.Value
                    : _converter.Convert(_celsius.Value, ConversionType.CelsiusToFarenheit);
            }
            set
            {
                _farenheit = value;
                _celsius = null;
                this.RaisePropertyChanged("CelsiusValue");
            }
        }

        public double CelsiusValue
        {
            get
            {
                return _celsius.HasValue 
                    ? _celsius.Value 
                    : _converter.Convert(_farenheit.Value, ConversionType.FarenheitToCelsius);
            }
            set
            {
                _celsius = value;
                _farenheit = null;
                this.RaisePropertyChanged("FarenheitValue");
            }
        }
        
    }
}