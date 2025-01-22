using PingPong.Scripts.Root.Services.Skin;
using UnityEngine;
using VContainer;

namespace PingPong.Scripts.Gameplay.Ball
{
    public class BallSkin : MonoBehaviour
    {
        private static readonly int MainTexture = Shader.PropertyToID("_mainTexture");
        private static readonly int Color = Shader.PropertyToID("_color");
        [Inject] private SkinService _skinService;
        private MeshFilter _meshFilter;
        private MeshRenderer _meshRenderer;

        private void Awake()
        {
            _meshFilter = GetComponent<MeshFilter>();
            _meshRenderer = GetComponent<MeshRenderer>();
            
            Material material = _meshRenderer.material;
            if (_skinService.ActiveSkin != null)
            {
                material.SetColor(Color, _skinService.ActiveSkin.Color);
                material.SetTexture(MainTexture, _skinService.ActiveSkin.Texture);
                _meshFilter.mesh = _skinService.ActiveSkin.Mesh;
            }
        }
    }
}