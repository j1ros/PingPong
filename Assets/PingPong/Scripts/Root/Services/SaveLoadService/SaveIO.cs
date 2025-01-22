using UnityEngine;

namespace PingPong.Scripts.Root.Services.SaveLoadService
{
    public class SaveIO : ISave
    {
        private string _baseSavePath = Application.persistentDataPath;

        public void Save(string fileName, ContainerSaveData data)
        {
            FileReadWrite.WriteToBinaryFile<ContainerSaveData>(_baseSavePath + "/" + fileName + ".dat", data);
        }

        public ContainerSaveData Load(string fileName)
        {
            string filePath = _baseSavePath + "/" + fileName + ".dat";
            if (System.IO.File.Exists(filePath))
            {
                return FileReadWrite.ReadFromBinaryFile<ContainerSaveData>(filePath);
            }
            return new ContainerSaveData(0,0,0,0);
        }
    }
}