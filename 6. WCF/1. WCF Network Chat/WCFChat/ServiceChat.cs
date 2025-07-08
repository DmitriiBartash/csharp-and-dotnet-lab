using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace WCFChat
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ServiceChat : IServiceChat
    {
        private readonly object syncRoot = new object();
        readonly List<ServerUser> users = new List<ServerUser>();
        int nextId = 1;

        public int Connect(string name)
        {
            ServerUser user;

            lock (syncRoot)
            {
                user = new ServerUser
                {
                    Id = nextId++,
                    Name = name,
                    OperationContext = OperationContext.Current
                };

                users.Add(user);
            }

            SendMessage($"{user.Name} has joined the chat!", user.Id);
            return user.Id;
        }

        public void Disconnect(int id)
        {
            ServerUser user;

            lock (syncRoot)
            {
                user = users.FirstOrDefault(u => u.Id == id);
                if (user != null)
                {
                    users.Remove(user);
                }
            }

            if (user != null)
            {
                SendMessage($"{user.Name} has left the chat!", id);
            }
        }

        public void SendMessage(string message, int senderId)
        {
            var sender = users.FirstOrDefault(u => u.Id == senderId);
            string prefix = DateTime.Now.ToShortTimeString();

            if (sender != null)
            {
                prefix += ": " + sender.Name + " ";
            }

            string finalMessage = prefix + message;

            foreach (var user in users.ToList())
            {
                try
                {
                    var callback = user.OperationContext.GetCallbackChannel<IServerChatCallBack>();
                    callback.MessageCallBack(finalMessage);
                }
                catch
                {
                    users.Remove(user);
                }
            }
        }
    }
}
