using System.ServiceModel;

namespace WCFChat
{
    [ServiceContract(CallbackContract = typeof(IServerChatCallBack))]
    public interface IServiceChat
    {
        [OperationContract]
        int Connect(string name);

        [OperationContract]
        void Disconnect(int id);

        [OperationContract(IsOneWay = true)]
        void SendMessage(string message, int id);

    }


    public interface IServerChatCallBack
    {
        [OperationContract(IsOneWay = true)]
        void MessageCallBack(string message);
    }
}
