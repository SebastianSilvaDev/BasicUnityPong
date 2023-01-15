using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Controllers
{
    public class BallController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D ballRigidBody;

        [SerializeField] private float initialForce = 20.0f;

        private Vector2 _currentVelocity = Vector2.zero;

        public Vector2 CurrentVelocity => _currentVelocity;
        
        // Start is called before the first frame update
        private void Start()
        {
            Assert.IsTrue(ballRigidBody, "Ball RigidBody is not valid");
            if (!ballRigidBody) return;
            Vector2 direction = Vector2.left;
            _currentVelocity = direction * initialForce;
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            _currentVelocity *= -1;
        }

        private void Update()
        {
            ballRigidBody.velocity = _currentVelocity;
        }
    }
}