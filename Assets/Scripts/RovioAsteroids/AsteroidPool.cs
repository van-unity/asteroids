using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace RovioAsteroids {
    public class AsteroidPool : MonoBehaviourObjectPoolBase<IAsteroid> {
        [SerializeField] private AsteroidType _asteroidType;
        [Inject] private readonly IAsteroidFactory _factory;

        protected override Task<IAsteroid> CreateTask() => _factory.CreateAsync(_asteroidType);
    }
}