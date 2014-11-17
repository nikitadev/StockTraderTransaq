namespace StockTraderTransaq.Infrastructure.Behaviors
{
	using System;
	using System.Windows;
	using System.Windows.Controls;
	using System.Windows.Interactivity;

	public sealed class PasswordBehavior : Behavior<PasswordBox>
	{
		private bool skipUpdate;

		//private TextBlockAdorner adorner;
		//private WeakPropertyChangeNotifier notifier;

		public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register("Password", typeof(string), typeof(PasswordBehavior), new PropertyMetadata(default(string)));

		public string Password
		{
			get { return (string)GetValue(PasswordProperty); }
			set { SetValue(PasswordProperty, value); }
		}

		public static readonly DependencyProperty WatermarkProperty = DependencyProperty.RegisterAttached("Watermark", typeof(string), typeof(PasswordBehavior), new PropertyMetadata(default(string)));

		public string Watermark
		{
			get { return (string)GetValue(WatermarkProperty); }
			set { SetValue(WatermarkProperty, value); }
		}

		public static readonly DependencyProperty WatermarkStyleProperty = DependencyProperty.RegisterAttached("WatermarkStyle", typeof(Style), typeof(PasswordBehavior));

		public Style WatermarkStyle
		{
			get { return (Style)GetValue(WatermarkStyleProperty); }
			set { SetValue(WatermarkStyleProperty, value); }
		}

		protected override void OnAttached()
		{
			this.AssociatedObject.Loaded += this.AssociatedObjectLoaded;
			this.AssociatedObject.Unloaded += AssociatedObjectOnUnloaded;
			this.AssociatedObject.PasswordChanged += PasswordChanged;
		}

		protected override void OnDetaching()
		{
			this.AssociatedObject.Loaded -= this.AssociatedObjectLoaded;
			this.AssociatedObject.Unloaded -= AssociatedObjectOnUnloaded;
			this.AssociatedObject.PasswordChanged -= PasswordChanged;
		}

		private void AssociatedObjectLoaded(object sender, RoutedEventArgs e)
		{
			//this.adorner = new TextBlockAdorner(this.AssociatedObject, this.Watermark, this.WatermarkStyle);

			this.UpdateAdorner();

			// AddValueChanged for IsFocused in a weak manner
			//this.notifier = new WeakPropertyChangeNotifier(this.AssociatedObject, UIElement.IsFocusedProperty);
			//this.notifier.ValueChanged += (s,a) => this.UpdateAdorner();
		}

		private void AssociatedObjectOnUnloaded(object sender, RoutedEventArgs routedEventArgs)
		{
			//this.notifier = null;
		}

		private void UpdateAdorner()
		{
			if (!String.IsNullOrEmpty(this.AssociatedObject.Password) 
				|| this.AssociatedObject.IsFocused)
			{
				// Hide the Watermark if the adorner layer is visible
				//this.AssociatedObject.TryRemoveAdorners<TextBlockAdorner>();
			}
			else
			{
				// Show the Watermark if the adorner layer is visible
				//this.AssociatedObject.TryAddAdorner<TextBlockAdorner>(adorner);
			}
		}

		protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
		{
			base.OnPropertyChanged(e);

			if (e.Property != PasswordProperty)
			{
				return;
			}

			if (this.skipUpdate)
			{
				return;
			}

			this.skipUpdate = true;
			this.AssociatedObject.Password = e.NewValue as string;
			this.skipUpdate = false;
		}

		private void PasswordChanged(object sender, RoutedEventArgs e)
		{
			skipUpdate = true;
			Password = AssociatedObject.Password;
			skipUpdate = false;

			this.UpdateAdorner();
		}
	}

	public sealed class TextBoxWatermarkBehavior : Behavior<TextBox>
	{
		//private TextBlockAdorner adorner;
		//private WeakPropertyChangeNotifier notifier;

		#region DependencyProperty's

		public static readonly DependencyProperty WatermarkProperty = DependencyProperty.RegisterAttached("Watermark", typeof(string), typeof(TextBoxWatermarkBehavior));

		public string Watermark
		{
			get { return (string)GetValue(WatermarkProperty); }
			set { SetValue(WatermarkProperty, value); }
		}

		public static readonly DependencyProperty WatermarkStyleProperty = DependencyProperty.RegisterAttached("WatermarkStyle", typeof(Style), typeof(TextBoxWatermarkBehavior));

		public Style WatermarkStyle
		{
			get { return (Style)GetValue(WatermarkStyleProperty); }
			set { SetValue(WatermarkStyleProperty, value); }
		}

		#endregion

		protected override void OnAttached()
		{
			base.OnAttached();
			this.AssociatedObject.Loaded += this.AssociatedObjectLoaded;
			this.AssociatedObject.TextChanged += this.AssociatedObjectTextChanged;
		}

		protected override void OnDetaching()
		{
			base.OnDetaching();
			this.AssociatedObject.Loaded -= this.AssociatedObjectLoaded;
			this.AssociatedObject.TextChanged -= this.AssociatedObjectTextChanged;

		}

		private void AssociatedObjectTextChanged(object sender, TextChangedEventArgs e)
		{
			this.UpdateAdorner();
		}

		private void AssociatedObjectLoaded(object sender, RoutedEventArgs e)
		{
			//this.adorner = new TextBlockAdorner(this.AssociatedObject, this.Watermark, this.WatermarkStyle);

			this.UpdateAdorner();

			//AddValueChanged for IsFocused in a weak manner
			//this.notifier = new WeakPropertyChangeNotifier(this.AssociatedObject, UIElement.IsFocusedProperty);
			//this.notifier.ValueChanged += this.UpdateAdorner;
		}

		private void UpdateAdorner(object sender, EventArgs e)
		{
			this.UpdateAdorner();
		}


		private void UpdateAdorner()
		{
			if (!String.IsNullOrEmpty(this.AssociatedObject.Text) || this.AssociatedObject.IsFocused)
			{
				// Hide the Watermark Label if the adorner layer is visible
				//this.AssociatedObject.TryRemoveAdorners<TextBlockAdorner>();
			}
			else
			{
				// Show the Watermark Label if the adorner layer is visible
				//this.AssociatedObject.TryAddAdorner<TextBlockAdorner>(adorner);
			}
		}
	}
}
