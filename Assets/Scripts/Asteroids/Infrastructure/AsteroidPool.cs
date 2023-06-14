using System.Threading.Tasks;
using Asteroids.Domain;
using UnityEngine;
using Zenject;

namespace Asteroids.Infrastructure {
    public class AsteroidPool : MonoBehaviourObjectPoolBase<IAsteroid> {
        [SerializeField] private AsteroidType _asteroidType;
        [Inject] private readonly IAsteroidFactory _factory;
        
        protected override Task<IAsteroid> CreateTask() => _factory.CreateAsync(_asteroidType);
    }
}