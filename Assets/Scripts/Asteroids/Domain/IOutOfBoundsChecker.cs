namespace Asteroids.Domain {
    public interface IOutOfBoundsChecker {
        void Register(IOutOfBoundsHandler objectToRegister);
        void UnRegister(IOutOfBoundsHandler objectToUnRegister);
    }
}