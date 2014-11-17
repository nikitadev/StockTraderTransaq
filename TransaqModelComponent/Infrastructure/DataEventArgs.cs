using System;

namespace TransaqModelComponent.Infrastructure
{
    public class DataEventArgs : EventArgs
    {
        public string Data { get; private set; }

		public DataEventArgs(String data)
		{
            Data = data;
		}		
    }
}
