namespace Library.Bll.Settings.Interfaces
{
    public interface IAppSettings
    {
        string PrivateKey { get; }
        int TokenExpiresIn { get; }
    }
}
