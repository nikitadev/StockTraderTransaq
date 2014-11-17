namespace StockTraderTransaq.ControlLibrary
{
	using System.ComponentModel;
	using System.Windows;

	public class ShellWindow : Window
	{
		static ShellWindow()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(ShellWindow), new FrameworkPropertyMetadata(typeof(ShellWindow)));
		}

		// Using a DependencyProperty as the backing store for TitleLeftContent.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty SeparatorLineProperty =
			DependencyProperty.Register("SeparatorLine", typeof(object), typeof(ShellWindow), new UIPropertyMetadata(null));

		[Category("Content")]
		public object SeparatorLine
		{
			get { return GetValue(SeparatorLineProperty); }
			set { SetValue(SeparatorLineProperty, value); }
		}

		// Using a DependencyProperty as the backing store for TitleLeftContent.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty TitleLeftPartProperty =
			DependencyProperty.Register("TitleLeftPart", typeof(object), typeof(ShellWindow), new UIPropertyMetadata(null));

		[Category("Content")]
		public object TitleLeftPart
		{
			get { return GetValue(TitleLeftPartProperty); }
			set { SetValue(TitleLeftPartProperty, value); }
		}

		// Using a DependencyProperty as the backing store for TitleLeftContent.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty TitleRightPartProperty =
			DependencyProperty.Register("TitleRightPart", typeof(object), typeof(ShellWindow), new UIPropertyMetadata(null));

		[Category("Content")]
		public object TitleRightPart
		{
			get { return GetValue(TitleRightPartProperty); }
			set { SetValue(TitleRightPartProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Dialogs.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty NavigationProperty =
			DependencyProperty.Register("Navigation", typeof(object), typeof(ShellWindow), new UIPropertyMetadata(null));

		[Category("Content")]
		public object Navigation
		{
			get { return GetValue(NavigationProperty); }
			set { SetValue(NavigationProperty, value); }
		}
	}
}
