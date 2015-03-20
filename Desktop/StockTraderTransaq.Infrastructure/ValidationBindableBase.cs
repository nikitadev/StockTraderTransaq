using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StockTraderTransaq.Infrastructure
{
	public abstract class ValidationBindableBase : BindableBase, INotifyDataErrorInfo, IDisposable
	{
		private readonly ConcurrentDictionary<string, List<string>> errors;

		public bool HasErrors
		{
			get { return errors.Any(kv => kv.Value != null && kv.Value.Count > 0); }
		}

		protected ValidationBindableBase()
		{
			this.errors = new ConcurrentDictionary<string, List<string>>();

            this.PropertyChanged += OnValidationPropertyChanged;
		}

        private async void OnValidationPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (!e.PropertyName.Equals("HasErrors"))
			{
				await this.ValidateAsync();
			}
		}

		public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
		protected virtual void OnErrorsChanged(string propertyName)
		{
			if (ErrorsChanged != null)
			{
				ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
			}
		}

		public IEnumerable GetErrors(string propertyName)
		{
			if (String.IsNullOrEmpty(propertyName)) 
                return String.Empty;

			List<string> errorsForName;
            errors.TryGetValue(propertyName, out errorsForName);
                
            return errorsForName;
		}

		public async Task ValidateAsync()
		{
			var validationContext = new ValidationContext(this);
			var validationResults = new List<ValidationResult>();
			Validator.TryValidateObject(this, validationContext, validationResults, true);

			foreach (var kv in this.errors.Where(kv => validationResults.All(r => r.MemberNames.All(m => m != kv.Key))))
			{
				await Task.Yield();

				List<string> outList;
				this.errors.TryRemove(kv.Key, out outList);

				this.OnErrorsChanged(kv.Key);
			}

			var query = validationResults
				.SelectMany(r => r.MemberNames, (result, m) => new { ValidationResult = result, MemberName = m })
				.GroupBy(it => it.MemberName, arg => arg.ValidationResult);

			foreach (var prop in query)
			{
				await Task.Yield();

				var messages = prop.Select(r => r.ErrorMessage).ToList();

				if (errors.ContainsKey(prop.Key))
				{
					List<string> outList;
					this.errors.TryRemove(prop.Key, out outList);
				}
				else
				{
					this.errors.TryAdd(prop.Key, messages);
				}

				this.OnErrorsChanged(prop.Key);
			}

			this.OnPropertyChanged(() => HasErrors);
		}

		public void Dispose()
		{
			this.errors.Clear();
            this.PropertyChanged -= OnValidationPropertyChanged;
		}
	}
}
