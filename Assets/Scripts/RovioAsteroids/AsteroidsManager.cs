using System;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace RovioAsteroids {
    public class AsteroidsManager : MonoBehaviour {
        private IPool<IAsteroid> _bigAsteroidPool;
        private IPool<IAsteroid> _mediumAsteroidPool;
        private IPool<IAsteroid> _smallAsteroidPool;

        [Inject] private readonly IMainCamera _mainCamera;

        private void Awake() {
            _bigAsteroidPool = GameObject.FindGameObjectWithTag("BigAsteroidPool")
                .GetComponent<IPool<IAsteroid>>();
            _mediumAsteroidPool = GameObject.FindGameObjectWithTag("MediumAsteroidPool")
                .GetComponent<IPool<IAsteroid>>();
            _smallAsteroidPool = GameObject.FindGameObjectWithTag("SmallAsteroidPool")
                .GetComponent<IPool<IAsteroid>>();
        }

        private async void Update() {
            if (Input.GetKeyDown(KeyCode.A)) {
                var asteroid = await _bigAsteroidPool.SpawnAsync();
                var x = Random.Range(0, Screen.width);
                var y = 0; //on bottom
                if (Random.Range(0f, 1f) > .5f) {
                    //generate on top
                    y = Screen.height;
                }

                var screenPosition = new Vector3(x, y, _mainCamera.NearClipPlane());
                asteroid.SetPosition(_mainCamera.ScreenToWorldPoint(screenPosition));
                asteroid.SetVelocity(new Vector2(Random.Range(-2f, 2),
                    y == 0 ? Random.Range(.5f, 2.5f) : Random.Range(-2.5f, .5f)));
            }
        }
    }
}