using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TempConverter.Services;

namespace TempConverter.App.Extensions
{
    public static class TempStorageExtension
    {
        public static PlotModel GetPlotModel(this ITempStorage storage)
        {
            var x = 0.0;
            var farenheitSeries = new LineSeries();
            var celsiusSeries = new LineSeries();
            storage.GetPairs().ToList().ForEach(pair  =>
            {
                farenheitSeries.Points.Add(new DataPoint(x++, pair.Farenheit));
                celsiusSeries.Points.Add(new DataPoint(x++, pair.Celsius));
            });
            var model = new PlotModel();
            model.Series.Add(farenheitSeries);
            model.Series.Add(celsiusSeries);

            return model;
        }
    }
}
