using UnityEngine;

namespace Models
{
    public class PlayerScore
    {
        public int Score { get; set; }

        public GameObject TextObject;

        private TMPro.TextMeshProUGUI _textComponent;

        public PlayerScore(GameObject textObject)
        {
            TextObject = textObject;
            Score = 0;
            _textComponent = TextObject.GetComponent<TMPro.TextMeshProUGUI>();
        }

        public void AddScore(int scoreToAdd = 1)
        {
            if (_textComponent == null) return;
            Score += scoreToAdd;
            _textComponent.SetText(Score.ToString());
        }
    }
}