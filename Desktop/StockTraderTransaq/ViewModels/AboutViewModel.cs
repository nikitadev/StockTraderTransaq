namespace StockTraderTransaq
{
	using System.Reflection;

    using StockTraderTransaq.Properties;
    using Microsoft.Practices.Prism.ViewModel;
    using Microsoft.Practices.Prism.Mvvm;
    using System.ComponentModel.Composition;

    [Export]
    public sealed class AboutViewModel : BindableBase
	{
		private readonly AssemblyName assemblyName;

		public string Version
		{
			get
			{
				return assemblyName.Version.ToString();
			}
		}

		public string ProcessorArchitecture
		{
			get
			{
				return assemblyName.ProcessorArchitecture.ToString();
			}
		}

        [ImportingConstructor]
		public AboutViewModel()
		{
			//this.Question = Resources.AboutLink;

			assemblyName = Assembly.GetExecutingAssembly().GetName();
		}
	}
}
