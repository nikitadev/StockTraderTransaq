namespace StockTraderTransaq.ControlLibrary
{
	using System.Windows;
	using System.Windows.Controls;

	/// <summary>
	/// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
	///
	/// Step 1a) Using this custom control in a XAML file that exists in the current project.
	/// Add this XmlNamespace attribute to the root element of the markup file where it is 
	/// to be used:
	///
	///     xmlns:MyNamespace="clr-namespace:StockTraderTransaq.ControlLibrary"
	///
	///
	/// Step 1b) Using this custom control in a XAML file that exists in a different project.
	/// Add this XmlNamespace attribute to the root element of the markup file where it is 
	/// to be used:
	///
	///     xmlns:MyNamespace="clr-namespace:StockTraderTransaq.ControlLibrary;assembly=StockTraderTransaq.ControlLibrary"
	///
	/// You will also need to add a project reference from the project where the XAML file lives
	/// to this project and Rebuild to avoid compilation errors:
	///
	///     Right click on the target project in the Solution Explorer and
	///     "Add Reference"->"Projects"->[Select this project]
	///
	///
	/// Step 2)
	/// Go ahead and use your control in the XAML file.
	///
	///     <MyNamespace:CustomControl1/>
	///
	/// </summary>
	public class PageContentControl : HeaderedContentControl
	{
		static PageContentControl()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(PageContentControl), new FrameworkPropertyMetadata(typeof(PageContentControl)));
		}

		public object Footer
		{
			get { return GetValue(FooterProperty); }
			set { SetValue(FooterProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Footer.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty FooterProperty =
			DependencyProperty.Register("Footer", typeof(object), typeof(PageContentControl), new UIPropertyMetadata(null));
	}
}
