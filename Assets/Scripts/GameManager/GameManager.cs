using System;
using UnityEngine;

namespace GameManager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        
        [SerializeField]
        private GameMode gameMode;
        
        public GameMode GameMode => gameMode;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
                return;
            }

            Instance = this;
        }

        private void Start()
        {
            InitializeGame();
        }

        public void OverrideGameMode(GameMode newGameMode)
        {
            gameMode.FinishGameMode();
            gameMode = newGameMode;
            gameMode.InitializeGameMode(gameObject);
        }

        public void InitializeGame()
        {
            gameMode.InitializeGameMode(gameObject);
        }
    }
}