using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Presentation.Models;

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

        public void NotifyAllNearBy(string message, string country, string uid)
        { 
            IWContext context = new IWContext();
            List<ApplicationUser> users = context.Users.Where(u => u.Place.Country.Equals(country) && !u.Id.Equals(uid)).ToList();
            foreach (var user in users)
            {
                foreach (var connectionId in NotificationHub._connections.GetConnections(user.UserName))
                {
                    _context.Clients.Client(connectionId).showNotification(message);
                }
            }
        }
    }
}