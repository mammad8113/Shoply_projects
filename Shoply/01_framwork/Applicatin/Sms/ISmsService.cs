namespace _01_framwork.Applicatin.Sms
{
    public interface ISmsService
    {
        void Send(string number, string message);
        void OnGetPassword(object source, GetPasswordEventArgs args);
    }
}