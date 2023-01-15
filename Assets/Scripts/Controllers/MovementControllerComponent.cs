using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Controllers
{
    [RequireComponent(typeof(PlayerController))]
    public class MovementControllerComponent : MonoBehaviour, IControllerComponent
    {

        [SerializeField]
        private float movementSpeed = 1.0f;
        
        protected GameObject player;

        protected PlayerController playerController;

        protected Rigidbody2D playerRigidbody;

        private float direction = 0.0f;
        
        public void Move(InputAction.CallbackContext context)
        {
            if (!player || !playerRigidbody) return;
            direction = context.ReadValue<float>();
            
        }

        private void FixedUpdate()
        {
            if (direction == 0.0f) return;
            Vector2 currentPosition = player.transform.position;
            Vector2 nextPosition = Vector2.up * (movementSpeed * direction) + currentPosition;
            playerRigidbody.MovePosition(Vector2.Lerp(currentPosition, nextPosition, 0.1f));
        }

        public void IOnPossesPlayer(GameObject newPlayer, PlayerController newPlayerController)
        {
            player = newPlayer;
            playerController = newPlayerController;
            playerRigidbody = player.GetComponent<Rigidbody2D>();
        }

        public void IOnUnPossesPlayer()
        {
            player = null;
            playerRigidbody = null;
        }
    }
}