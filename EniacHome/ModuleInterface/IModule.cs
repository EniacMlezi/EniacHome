using PluginInterface;

namespace ModuleInterface
{
    public interface IModule
    {
        string Name { get; set; }
        string Address { get; set; }
        bool IsConnected { get; }

        void Disconnect();
        IPlugin Plugin { get; set; }
    }
}
