namespace StockTraderTransaq.Converters
{
	using System;
	using System.Windows;
	using System.Windows.Data;

	[ValueConversion(typeof(Boolean), typeof(Boolean))]
	public sealed class InverterBolleanConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			var inverterValue = (bool)value;
			return !inverterValue;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return DependencyProperty.UnsetValue;
		}
	}
}
