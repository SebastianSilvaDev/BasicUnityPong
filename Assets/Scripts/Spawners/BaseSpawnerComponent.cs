using System;
using UnityEngine;

namespace Spawners
{
    public class BaseSpawnerComponent : MonoBehaviour
    {
        [SerializeField]
        protected GameObject gameObjectToSpawn;
        
        private GameManager.GameManager _gameManager;
        
        protected GameObject spawnedObject;
        
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

        public void Spawn()
        {
            // Default Pooling of Objects for spawner
            if (!spawnedObject)
            {
                spawnedObject = Instantiate(gameObjectToSpawn, transform);
                ISpawnedControllerInterface spawnedControllerInterface = spawnedObject.GetComponent(typeof(ISpawnedControllerInterface)) as ISpawnedControllerInterface;
                spawnedControllerInterface.ISetSpawner(this);
                return;
            }
            spawnedObject.transform.position = transform.position;
        }
    }
}