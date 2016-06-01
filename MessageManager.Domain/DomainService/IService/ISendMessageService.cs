
using MessageManager.Domain.Entity;
namespace MessageManager.Domain.DomainService
{
    public interface ISendMessageService
    {
        bool SendMessage(Message message);
    }
}
