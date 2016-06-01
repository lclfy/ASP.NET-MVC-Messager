

namespace MessageManager.Domain.ValueObject
{
    public class Sender : Contact
    {
        public Sender(string name)
            : base(name)
        {
        }

        public Sender(string name, string loginName, string displayName)
            : base(name, loginName, displayName)
        {
        }
    }
}
