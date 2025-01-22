namespace PingPong.Scripts.Root.Services.SaveLoadService
{
    public interface ISave
    {
        public void Save(string path, ContainerSaveData data);
        public ContainerSaveData Load(string path);
    }
}