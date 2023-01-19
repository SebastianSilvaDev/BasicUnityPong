using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Controllers
{
    public class BarrierController : MonoBehaviour
    {
        [SerializeField]
        private int playerIndex = 0;

        private void OnTriggerEnter2D(Collider2D col)
        {
            Debug.Log("I Received a ball collision");
        }
    }
}