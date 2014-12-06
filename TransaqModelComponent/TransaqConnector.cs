using System;
using System.Threading.Tasks;
using TransaqModelComponent.Helpers;
using TransaqModelComponent.Infrastructure;
using TransaqModelComponent.Models;
using TransaqModelComponent.Models.Events;

namespace TransaqModelComponent
{
    public sealed class TransaqConnector : IDisposable
    {
        private const string EventCallbackNameSettings = "settings";

        private readonly TXmlConnectorEventManager eventManager;

        private bool isConnected, isInitialized;

        private string error;

        public bool IsConnected { get { return isConnected; } }

        public TransaqConnector()
        {
            this.isConnected = false;
            this.error = String.Empty;
            this.eventManager = new TXmlConnectorEventManager();
        }

        public async Task Initialize(string path, short logLevel)
        {
            eventManager.Subscribe(EventCallbackNameSettings, new EventCallbackImpl(s => SetConnected(s)));

            using (var connector = new TXmlConnectorWrapper())
            {
                string result = await Task.Run(() => connector.Initialize(path, logLevel));

                isInitialized = true;
            }
        }

        private void SetConnected(ServerStatus status)
        {
            bool state;
            if (!Boolean.TryParse(status.StatusConnect, out state))
            {
                error = "Some errors";
            } 
            else if (!isConnected && !state)
            {
                error = "Can not connected";
            }
            else if (isConnected && state)
            {
                error = "Can not disconnected";
            }

            isConnected = !isConnected;
        }

        private async Task<T> SendCommand<T>(Command command)
		{
            using (var connector = new TXmlConnectorWrapper())
            {
                string cmd = command.ToXml();

                string result = await Task.Run(() => connector.SendCommand(cmd));

                return result.ToObject<T>();
            }
		}

        private async Task CommandProgress()
        { 
            while (isConnected)
            {
                if (String.IsNullOrEmpty(error))
                {
                    await Task.Yield();
                }
                else
                {
                    throw new TransaqConnectorException(error);
                }
            }
        }

        public async Task Connect(string userId, string password, string host, int port, string logPath)
        {
            var command = new Connection
            {
                UserId = userId,
                Password = password,
                Host = host,
                Port = port,
                PathForLogs = logPath
            };

            var result = await SendCommand<Result>(command);
            if (result.Success)
            {
                //await CommandProgress();
            }
        }

        public async Task Disconect()
        {
            eventManager.Unsubscribe(EventCallbackNameSettings);

            var result = await SendCommand<Result>(new Command(CommandNames.Disconnection));
            if (result.Success)
            {
                //await CommandProgress();
            }
        }

        public async Task<string> GetConnectedStatus()
        {
            var status = await SendCommand<ServerStatus>(new Command(CommandNames.Status));

            return status.StatusConnect;
        }        

        /// <summary>
        /// 
        /// </summary>
        /// <see cref="Dispose"/>
        /// <returns></returns>
        public void Clean()
        { 
            using (var connector = new TXmlConnectorWrapper())
            {
                connector.Finalize();
            }
        }

        public void Dispose()
        {
            if (!isInitialized)
                return;

            if (isConnected)
            {
                Disconect().Wait();                
            }

            Clean();
        }
    }
}
