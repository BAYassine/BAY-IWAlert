using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Presentation.Hubs
{
    public class Notifier
    {
        private readonly static Lazy<Notifier> _instance = new Lazy<Notifier>(
            () => new Notifier(GlobalHost.ConnectionManager.GetHubContext<NotificationHub>()));
        private IHubContext _context;

        public static Lazy<Notifier> getInstance()
        {
            return _instance;
        }

        private Notifier(IHubContext context)
        {
            _context = context;
        }

        public void NotifyAll(string Message)
        {
            _context.Clients.All.showNotification(Message);
        }
    }
}