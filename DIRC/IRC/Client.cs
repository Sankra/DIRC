﻿using System;
using Microsoft.AspNet.SignalR.Client;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DIRC.IRC
{
    public class Client
    {
        readonly string _platform;
        readonly HubConnection _connection;
        readonly IHubProxy _proxy;

        public event EventHandler<string> OnMessageReceived;

		public Client()
		{
			_platform = Device.OS.ToString();
		    _connection = new HubConnection("http://mildestve.it:1337");
            _proxy = _connection.CreateHubProxy("DircHub");
		}

        public async Task Connect()
        {
            await _connection.Start();
            _proxy.On("broadcastMessage", (string userName, string platform, string message) =>
            {
                if (OnMessageReceived != null)
						OnMessageReceived(this, string.Format("{0} ({1}): {2}", userName, platform, message));
            });
        }

        public Task Send(string userName, string message)
        {
            return _proxy.Invoke("send", userName, _platform, message);
        }
    }
}

