using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private UIHandler uiHandler;
    [SerializeField] private AudioHandler audioHandler;
    [SerializeField] private CanvasHitDetector canvasHitDetector;
    
    public override void InstallBindings()
    {
        Container.Bind<UIHandler>().FromInstance(uiHandler).AsSingle().NonLazy();
        Container.Bind<AudioHandler>().FromInstance(audioHandler).AsSingle().NonLazy();
        Container.Bind<CanvasHitDetector>().FromInstance(canvasHitDetector).AsSingle().NonLazy();
    }
}