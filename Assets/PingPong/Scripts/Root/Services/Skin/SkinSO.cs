using System;
using UnityEngine;

namespace PingPong.Scripts.Root.Services.Skin
{
    [Serializable, CreateAssetMenu(fileName = "Skin", menuName = "Skins/Skin")]
    public class SkinSO : ScriptableObject
    {
        [field: SerializeField]
        public int Id { get; private set; }
        [field: SerializeField]
        public Color Color { get; private set; }
        [field: SerializeField]
        public Mesh Mesh { get; private set; }
        [field: SerializeField]
        public Texture Texture { get; private set; }
        [field: SerializeField]
        public int ProgressLevel { get; private set; }
    }
}