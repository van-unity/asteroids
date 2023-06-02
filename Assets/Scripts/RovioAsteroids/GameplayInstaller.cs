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
            .AsSingle()
            .NonLazy();

        Container.BindInterfacesAndSelfTo<AsteroidFactory>()
            .AsSingle()
            .NonLazy();

        Container.BindInterfacesAndSelfTo<MainCamera>()
            .FromComponentInHierarchy()
            .AsSingle()
            .NonLazy();

        Container.BindInterfacesAndSelfTo<OutOfBoundsChecker>()
            .FromComponentInHierarchy()
            .AsSingle()
            .NonLazy();
    }
}