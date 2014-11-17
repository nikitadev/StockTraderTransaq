using System;
using System.Diagnostics;
using System.IO;
using System.Xml;
using TransaqModelComponent.Helpers;
using TransaqModelComponent.Models;
using TransaqModelComponent.Models.Events;

namespace TransaqModelComponent.Infrastructure
{
    internal class EventCallbackImpl : IEventCallback
    {
        private readonly Action<ServerStatus> readyHandler;

        public EventCallbackImpl(Action<ServerStatus> readyHandler)
        {
            this.readyHandler = readyHandler;
        }

        public Settings Settings { get; private set; }

        public void Callback(string args)
        {
            try
            {
                using (var reader = XmlReader.Create(new StringReader(args)))
                {
                    reader.MoveToContent();

                    if (reader.Name.Contains(EventNames.Markets))
                    {
                        var markets = args.ToObject<Markets>();
                    }

                    if (reader.Name.Contains(EventNames.Boards))
                    {
                        var boards = args.ToObject<Boards>();
                    }

                    if (reader.Name.Contains(EventNames.Candlekinds))
                    {
                        var candlekinds = args.ToObject<Candlekinds>();
                    }

                    if (reader.Name.Contains(EventNames.ClientInfo))
                    {
                        var clientInfo = args.ToObject<ClientInfo>();
                    }

                    if (reader.Name.Contains(EventNames.Securities))
                    {
                        var securities = args.ToObject<Securities>();
                    }

                    if (reader.Name.Contains(EventNames.SecurityInfoUpdate))
                    {
                        var securityInfoUpdate = args.ToObject<SecurityInfoUpdate>();
                    }

                    if (reader.Name.Contains(EventNames.Pits))
                    {
                        var pits = args.ToObject<Pits>();
                    }

                    if (reader.Name.Contains(EventNames.Messages))
                    {
                        var messages = args.ToObject<Messages>();
                    }

                    if (reader.Name.Contains(EventNames.ServerStatus))
                    {
                        if (readyHandler != null)
                        {
                            readyHandler(args.ToObject<ServerStatus>());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine(ex.Message);
#else
                throw ex;
#endif
            }
        }
    }
}
