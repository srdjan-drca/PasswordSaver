using Prism.Events;

namespace PasswordSaver.Event
{
    public enum PageId
    {
        AddCredentials = 0,
        ListCredentials
    };

    public class OpenPageEvent: PubSubEvent<PageId>
    {
    }
}
