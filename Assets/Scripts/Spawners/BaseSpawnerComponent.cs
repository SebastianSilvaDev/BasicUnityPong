using System;
using UnityEngine;

namespace Spawners
{
    public class BaseSpawnerComponent : MonoBehaviour
    {
        [SerializeField]
        protected GameObject gameObjectToSpawn;
        
        private GameManager.GameManager _gameManager;
        
        protected GameObject spawnedBall;
        
        private void Start()
        {
            _gameManager = GameManager.GameManager.Instance;
            _gameManager.finishInitializing = OnFinishInitializing;
            if (_gameManager.HasFinishedInitializing) OnFinishInitializing();
        }

        void OnFinishInitializing()
        {
            Spawn();
        }

        void Spawn()
        {
            // Default Pooling of Objects for spawner
            if (!spawnedBall)
            {
                spawnedBall = Instantiate(gameObjectToSpawn, transform);
                return;
            }
            spawnedBall.transform.position = transform.position;
        }
    }
}