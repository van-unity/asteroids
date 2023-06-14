using UnityEngine;
using Random = UnityEngine.Random;

namespace Asteroids.Presentation {
    public class ShipExplosion : MonoBehaviour {
        [SerializeField] private Rigidbody2D[] _parts;
        [SerializeField] private Vector2 _forceRange;
        [SerializeField] private Vector2 _torqueRange;

        private void Start() {
            Explode();
        }

        private void Explode() {
            foreach (var part in _parts) {
                var force = Random.insideUnitCircle * Random.Range(_forceRange.x, _forceRange.y);
                var torque = Random.Range(_torqueRange.x, _torqueRange.y);

                part.AddForce(force, ForceMode2D.Impulse);
                part.AddTorque(torque, ForceMode2D.Impulse);
            }
        }
    }
}