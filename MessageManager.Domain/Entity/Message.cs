

using MessageManager.Domain.ValueObject;
using System;

namespace MessageManager.Domain.Entity
{
    public class Message : IAggregateRoot
    {
        public Message(string title, string content, Contact sender, Contact recipient)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("标题不能为空");
            }
            if (title.Length > 20)
            {
                throw new ArgumentException("标题长度不能超过20");
            }
            if (string.IsNullOrEmpty(content))
            {
                throw new ArgumentException("内容不能为空");
            }
            if (content.Length > 400)
            {
                throw new ArgumentException("内容长度不能超过400");
            }
            if (sender == null)
            {
                throw new ArgumentException("发送人姓名不能为空");
            }
            if (recipient == null)
            {
                throw new ArgumentException("收件人姓名不能为空");
            }
            this.ID = Guid.NewGuid().ToString();
            this.Title = title;
            this.Content = content;
            this.SendTime = DateTime.Now;
            this.State = MessageState.Unread;
            this.DisplayType = MessageDisplayType.OutboxAndInbox;
            this.Sender = sender;
            this.Recipient = recipient;
        }
        public string ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime SendTime { get; set; }
        public MessageState State { get; set; }
        public MessageDisplayType DisplayType { get; set; }
        public virtual Contact Sender { get; set; }
        public virtual Contact Recipient { get; set; }

        public void SetState(Contact reader)
        {
            if (this.Recipient.Name.Equals(reader.Name) && this.State == MessageState.Unread)
            {
                this.State = MessageState.Read;
            }
        }

        public bool SetDisplayType(Contact reader)
        {
            switch (this.DisplayType)
            {
                case MessageDisplayType.OutboxAndInbox:
                    if (this.Sender.Name.Equals(reader.Name))
                    {
                        this.DisplayType = MessageDisplayType.Inbox;
                    }
                    else
                    {
                        this.DisplayType = MessageDisplayType.Outbox;
                    }
                    return true;
                case MessageDisplayType.Outbox:
                    break;
                case MessageDisplayType.Inbox:
                    break;
                default:
                    break;
            }
            return false;
        }
    }
}
