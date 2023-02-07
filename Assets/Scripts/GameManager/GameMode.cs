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
        [SerializeField] protected List<GameObject> playerPrefabs;

        [SerializeField] protected List<GameObject> playerControllerPrefabs;

        protected PlayerSpawnLocation[] spawnPoints;

        protected List<GameObject> players = new List<GameObject>();

        protected List<GameObject> playerControllers = new List<GameObject>();

        public virtual void InitializeGameMode(GameObject manager)
        {
            spawnPoints = FindObjectsOfType<PlayerSpawnLocation>();
            if (spawnPoints.Length <= 0) return;
            CreateNewPlayerController();
            CreateNewPlayer();
            for (int i = 0; i < playerControllers.Count; i++)
            {
                PlayerController playerControllerComponent = playerControllers[i].GetComponent<PlayerController>();
                if (!playerControllerComponent) continue;
                playerControllerComponent.PossesPlayer(players[i]);
            }
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
            GameObject newPlayer = Instantiate(playerPrefabs[0], spawnTransform);
            players.Add(newPlayer);
        }

        protected virtual void CreateNewPlayerController()
        {
            if (playerControllers.Count > 0)
            {
                playerControllers.RemoveRange(0, playerControllers.Count);
            }

            GameObject newPlayerController = Instantiate(playerControllerPrefabs[0]);
            playerControllers.Add(newPlayerController);
        }

        public GameObject GetPlayer(int index)
        {
            if (index >= players.Count) return null;
            return players[index];
        }

        public GameObject GetPlayerController(int index)
        {
            if (index >= playerControllers.Count) return null;
            return playerControllers[index];
        }
    }
}