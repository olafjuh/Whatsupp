using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Whatsupp.Models
{
    public interface IChatRepository
    {
        void AddMessage(Message message);
        IEnumerable<Message> GetLatestMessages(int accountId);
        IEnumerable<Message> GetSent(int accountId);
        IEnumerable<Message> GetReceived(int accountId);
        IEnumerable<Message> GetLatestMessagesFromSender(int currentSenderId, int currentReceiverId);
        string GetAccountName(int accountId);
        Account GetAccount(string naam);
        IEnumerable<Message> GetLatestMessagesFromReceiver(int currentSenderId, int currentReceiverId);

        //IEnumerable<Message> GetMessages(int accountId);

    }
}