using RovioAsteroids;
using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller<GameplayInstaller> {
    [SerializeField] private AsteroidAddressableCatalog _asteroidAddressableCatalog;
    [SerializeField] private GameSettings _gameSettings;

    public override void InstallBindings() {
        Container.BindInterfacesAndSelfTo<GameSettings>()
            .FromInstance(_gameSettings)
            .AsSingle();

        Container.BindInterfacesAndSelfTo<AsteroidAddressableCatalog>()
            .FromInstance(_asteroidAddressableCatalog)
            .AsSingle();

        Container.BindInterfacesAndSelfTo<AsteroidFactory>()
            .AsSingle();

        Container.BindInterfacesAndSelfTo<MainCamera>()
            .FromComponentInHierarchy()
            .AsSingle();
        
        Container.BindInterfacesAndSelfTo<OutOfBoundsChecker>()
            .FromComponentInHierarchy()
            .AsSingle()
            .NonLazy();

        Container.BindInterfacesAndSelfTo<BulletFactory>()
            .FromComponentInHierarchy()
            .AsSingle();
    }
}