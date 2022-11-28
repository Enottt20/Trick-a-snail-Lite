using Managers;
using UnityEngine;
using Zenject;

namespace ZenjectInstallers
{
    
    public class AudioInstaller : MonoInstaller
    {
        [SerializeField] private Audio audio;
        
        public override void InstallBindings()
        {
            Container.Bind<Audio>().FromInstance(audio).AsSingle().NonLazy();
            Container.QueueForInject(audio);
        }
    }
}
