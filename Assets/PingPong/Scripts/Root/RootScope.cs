using PingPong.Scripts.Gameplay;
using PingPong.Scripts.Root.Services;
using PingPong.Scripts.Root.Services.SaveLoadService;
using PingPong.Scripts.Root.Services.Skin;
using VContainer;
using VContainer.Unity;

namespace PingPong.Scripts.Root
{
    public class RootScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<SaveIO>(Lifetime.Singleton).As<ISave>();
            builder.Register<SaveLoadService>(Lifetime.Singleton);
            builder.Register<LoadSceneService>(Lifetime.Singleton);
            builder.RegisterEntryPoint<ProgressService>().AsSelf();
            builder.RegisterEntryPoint<SkinService>().AsSelf();
            builder.RegisterEntryPoint<ScoreService>().AsSelf();
        }
    }
}