using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private UIHandler uiHandler;
    
    public override void InstallBindings()
    {
        Container.Bind<UIHandler>().FromInstance(uiHandler).AsSingle().NonLazy();
    }
}