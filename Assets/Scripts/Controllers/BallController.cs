using Spawners;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Controllers
{
    public class BallController : MonoBehaviour, ISpawnedControllerInterface
    {
        [SerializeField] private Rigidbody2D ballRigidBody;

        [SerializeField] private float initialForce = 20.0f;

        private Vector2 _currentForce = Vector2.zero;

        public Vector2 CurrentForce => _currentForce;

        private BaseSpawnerComponent _spawner;

        public void IRequestReespawn()
        {
            _spawner.Spawn();
        }

        public void ISetSpawner(BaseSpawnerComponent spawner)
        {
            _spawner = spawner;
        }

        // Start is called before the first frame update
        private void Start()
        {
            Assert.IsTrue(ballRigidBody, "Ball RigidBody is not valid");
            if (!ballRigidBody) return;
            Vector2 direction = new Vector2(-0.5f, 0.5f);
            direction.Normalize();
            _currentForce = direction * initialForce;
            ballRigidBody.AddForce(_currentForce);
        }
    }
}