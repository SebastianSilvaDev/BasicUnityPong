using UnityEngine;

namespace GameManager.GameModes
{
    [CreateAssetMenu(fileName = "TwoPlayersGameMode", menuName = "ScriptableObject/TwoPlayerGameModeObject")]
    public class TwoPlayersGameMode : GameMode
    {
        public override void InitializeGameMode(GameObject manager)
        {
            base.InitializeGameMode(manager);
        }

        public override void FinishGameMode()
        {
            base.FinishGameMode();
        }

        protected override void CreateNewPlayer()
        {
            if (players.Count > 1)
            {
                players.RemoveRange(0, players.Count);
            }

            for (int i = 0; i < 2; i++)
            {
                Transform spawnTransform = spawnPoints[i].gameObject.transform;
                GameObject newPlayer = Instantiate(playerPrefabs[i], spawnTransform);
                players.Add(newPlayer);
            }
        }

        protected override void CreateNewPlayerController()
        {
            if (playerControllers.Count > 1)
            {
                playerControllers.RemoveRange(0, playerControllers.Count);
            }

            for (int i = 0; i < 2; i++)
            {
                GameObject newPlayerController = Instantiate(playerControllerPrefabs[i]);
                playerControllers.Add(newPlayerController);
            }
        }
    }
}