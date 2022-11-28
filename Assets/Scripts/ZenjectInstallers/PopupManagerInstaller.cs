using Managers;
using UnityEngine;
using Zenject;

public class PopupManagerInstaller : MonoInstaller
{
    [SerializeField] private PopupManager popupManager;
        
    public override void InstallBindings()
    {
        Container.Bind<PopupManager>().FromInstance(popupManager).AsSingle().NonLazy();
        Container.QueueForInject(popupManager);
    }
}