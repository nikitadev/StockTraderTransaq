using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransaqModelComponent.Helpers;

namespace TransaqModelComponent.Infrastructure
{
    public sealed class TXmlConnectorEventManager : IEventManager
    {
        private readonly IDictionary<string, IEventCallback> callbacks;
        
        private TXmlConnectorCallback connectorCallback;
        private TXmlConnectorCallbackEx connectorCallbackEx;

        public TXmlConnectorEventManager()
        {
            callbacks = new Dictionary<string, IEventCallback>();

            SetTXmlConnectorCallbacks();
        }

        private void SetTXmlConnectorCallbacks()
        {
            connectorCallback = new TXmlConnectorCallback(RaiseEvent);
            connectorCallbackEx = new TXmlConnectorCallbackEx((pData, userData) => RaiseEvent(pData));
        }

        public void Subscribe(string tagEvent, IEventCallback eventCallback)
        {
            if (!TXmlConnectorHelper.SetCallback(connectorCallback))
            {
                throw (new TransaqConnectorException());
            }

            if (!TXmlConnectorHelper.SetCallbackEx(connectorCallbackEx, IntPtr.Zero))
            {
                throw (new TransaqConnectorException());
            }

            callbacks.Add(tagEvent, eventCallback);
        }

        public void Unsubscribe(string tagEvent)
        {
            callbacks.Remove(tagEvent);
        }

        private bool RaiseEvent(IntPtr pData)
        {
            var task = RaiseEventAsync(pData);
            task.Wait();

            // TODO: ???
            return true;
        }

        private async Task RaiseEventAsync(IntPtr pData)
        {
            string arg = pData.ToStringUTF8();

            await Task.Run(() => TXmlConnectorHelper.FreeMemory(pData));

            foreach (var @event in callbacks.Values)
            {
                @event.Callback(arg);

                await Task.Yield();
            }
        }
    }
}
