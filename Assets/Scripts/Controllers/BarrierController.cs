using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Controllers
{
    public class BarrierController : MonoBehaviour
    {
        [SerializeField]
        private int playerIndex = 1;

        private void OnTriggerEnter2D(Collider2D col)
        {
            BallController ballController = col.gameObject.GetComponent<BallController>();
            if (ballController == null) return;
            GameManager.GameManager.Instance.ScoreManager.AddScoreToPlayer(playerIndex);
            ballController.IRequestReespawn();
        }
    }
}