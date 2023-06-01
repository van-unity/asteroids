using System.Threading.Tasks;

namespace RovioAsteroids {
    public class AsteroidPool : ObjectPoolBase<IAsteroid> {
        private readonly IAsteroidFactory _factory;
        private readonly AsteroidType _asteroidType;

        public AsteroidPool(int size, IAsteroidFactory factory, AsteroidType asteroidType) : base(size) {
            _factory = factory;
            _asteroidType = asteroidType;
        }

        protected override Task<IAsteroid> Create() => _factory.CreateAsync(_asteroidType);
    }
}