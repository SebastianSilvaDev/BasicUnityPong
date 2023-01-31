using System.Collections;
using System.Collections.Generic;
using Models;
using UnityEngine;

namespace GameManager
{
    public class ScoreManager : MonoBehaviour
    {
        private List<PlayerScore> _playerScores;

        [SerializeField]
        private List<GameObject> textPlayerObjects;

        private void Start()
        {
            _playerScores = new List<PlayerScore>();
            foreach (GameObject textObject in textPlayerObjects)
            {
                PlayerScore newPlayerScore = new PlayerScore(textObject);
                _playerScores.Add(newPlayerScore);
            }
        }

        public int GetPlayersScoreById(int playerId)
        {
            if (_playerScores.Count <= playerId) return 0;
            return _playerScores[playerId].Score;
        }

        public void AddScoreToPlayer(int playerId, int scoreToAdd = 1)
        {
            if (_playerScores.Count <= playerId) return;
            _playerScores[playerId].AddScore(scoreToAdd);
        }
    }

}
