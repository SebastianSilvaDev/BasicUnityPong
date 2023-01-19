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

        private bool _hasFinishedInitializing = false;

        public bool HasFinishedInitializing => _hasFinishedInitializing;
        
        public delegate void OnFinishInitializing();

        public OnFinishInitializing finishInitializing;
        
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
            _hasFinishedInitializing = true;
            finishInitializing();
        }

        public void OverrideGameMode(GameMode newGameMode)
        {
            gameMode.FinishGameMode();
            gameMode = newGameMode;
            gameMode.InitializeGameMode(gameObject);
            _hasFinishedInitializing = true;
            finishInitializing();
        }

        public void InitializeGame()
        {
            gameMode.InitializeGameMode(gameObject);
        }
    }
}