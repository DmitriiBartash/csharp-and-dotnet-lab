using System.ServiceModel;

namespace WCFChat
{
    public class ServerUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public OperationContext OperationContext { get; set; }
    }
}
