using System.Threading.Tasks;
using RovioAsteroids.Domain;
using UnityEngine;
using Zenject;

namespace RovioAsteroids.Infrastructure {
    public class AsteroidPool : MonoBehaviourObjectPoolBase<IAsteroid> {
        [SerializeField] private AsteroidType _asteroidType;
        [Inject] private readonly IAsteroidFactory _factory;
        
        protected override Task<IAsteroid> CreateTask() => _factory.CreateAsync(_asteroidType);
    }
}