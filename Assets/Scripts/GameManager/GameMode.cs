using System.Collections;
using System.Collections.Generic;
using System.Runtime.Versioning;
using Controllers;
using UnityEngine;

namespace GameManager
{
    // This is the base class for Game Modes created with single player
    [CreateAssetMenu(fileName = "GameMode", menuName = "ScriptableObject/GameModeObject")]
    public class GameMode : ScriptableObject
    {
        [SerializeField]
        protected GameObject playerPrefab;

        [SerializeField]
        protected GameObject playerControllerPrefab;
        
        protected PlayerSpawnLocation[] spawnPoints;

        protected List<GameObject> players;

        protected List<GameObject> playerControllers;

        public virtual void InitializeGameMode(GameObject manager)
        {
            spawnPoints = FindObjectsOfType<PlayerSpawnLocation>();
            if (spawnPoints.Length <= 0) return;
            CreateNewPlayerController();
            CreateNewPlayer();
            PlayerController playerControllerComponent = playerControllers[0].GetComponent<PlayerController>();
            if (!playerControllerComponent) return;
            playerControllerComponent.PossesPlayer(players[0]);
        }

        public virtual void FinishGameMode()
        {
            
        }

        // This could be changed by something other than Inheritance
        protected virtual void CreateNewPlayer()
        {
            if (players.Count > 0)
            {
                players.RemoveRange(0, players.Count);
            }
            Transform spawnTransform = spawnPoints[0].gameObject.transform;
            GameObject newPlayer = Instantiate(playerPrefab, spawnTransform);
            players.Add(newPlayer);
        }

        protected virtual void CreateNewPlayerController()
        {
            if (playerControllers.Count > 0)
            {
                playerControllers.RemoveRange(0, playerControllers.Count);
            }
            GameObject newPlayerController = Instantiate(playerControllerPrefab);
            playerControllers.Add(newPlayerController);
        }
    }
}
