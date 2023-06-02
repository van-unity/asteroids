using RovioAsteroids;
using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller<GameplayInstaller> {
    [SerializeField] private AsteroidAddressableCatalog _asteroidAddressableCatalog;

    public override void InstallBindings() {
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

        // Container.Bind(typeof(IInitializable), typeof(ITickable), typeof(ILateTickable))
        //     .To<TestClass>()
        //     .AsSingle()
        //     .NonLazy();
    }
}