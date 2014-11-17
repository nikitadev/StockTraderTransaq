namespace Tmobis.ProvisioningTool.Common.WPF
{
	using System;
	using System.Linq;
	using System.Windows.Data;

	public sealed class BooleanOrConverter : IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return values.Any(value => value.Equals(true));
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
