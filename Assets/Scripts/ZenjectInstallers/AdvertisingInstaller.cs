using Ads;
using UnityEngine;
using Zenject;

namespace ZenjectInstallers
{
    public class AdvertisingInstaller : MonoInstaller
    {
        [SerializeField] private Advertising advertising;
        
        public override void InstallBindings()
        {
            Container.Bind<Advertising>().FromInstance(advertising).AsSingle().NonLazy();
            Container.QueueForInject(advertising);
        }
    }
}