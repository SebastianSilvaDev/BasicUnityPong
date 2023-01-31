using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameManager
{
    public class ScoreManager : MonoBehaviour
    {
        private List<int> _playerScores = new List<int> { 0, 0 };
        
        private TMPro.TextMeshProUGUI player1TextComponent;

        private TMPro.TextMeshProUGUI player2TextComponent;

        [SerializeField]
        private GameObject Player1TextObject;

        [SerializeField]
        private GameObject Player2TextObject;

        private void Start()
        {
            player1TextComponent = Player1TextObject.GetComponent<TMPro.TextMeshProUGUI>();
            player2TextComponent = Player2TextObject.GetComponent<TMPro.TextMeshProUGUI>();

            // TODO: refactor this so it uses a List
            if (player1TextComponent)
            {
                player1TextComponent.SetText(GetPlayersScoreById(0).ToString());
            }
            if (player2TextComponent)
            {
                player2TextComponent.SetText(GetPlayersScoreById(1).ToString());
            }
        }

        public int GetPlayersScoreById(int playerId)
        {
            if (_playerScores.Count <= playerId) return 0;
            return _playerScores[playerId];
        }

        public void AddScoreToPlayer(int playerId, int scoreToAdd = 1)
        {
            if (_playerScores.Count <= playerId) return;
            _playerScores[playerId] += scoreToAdd;
            player1TextComponent.SetText(_playerScores[playerId].ToString());
        }
    }

}
