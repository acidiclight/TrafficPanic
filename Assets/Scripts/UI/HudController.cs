using System.Collections;
using Core;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

namespace UI
{
    public class HudController : MonoBehaviour
    {
        private Coroutine flashCoroutine;
        
        [Header("dependencies")]
        [SerializeField]
        private GameStateHolder gameState;
        
        [Header("Prefabs")]
        [SerializeField]
        private TrafficLightController trafficLightPrefab;
        
        [Header("UI")]
        [SerializeField]
        private Color negativeScoreColor;
        
        [SerializeField]
        private Color positiveScoreColor;

        [SerializeField]
        private TextMeshProUGUI scoreText;

        private void Awake()
        {
            Assert.IsNotNull(gameState);
            Assert.IsNotNull(trafficLightPrefab);
            Assert.IsNotNull(scoreText);
        }

        private void OnEnable()
        {
            gameState.Value.ScoreUpdated += UpdateScore;
        }

        private void UpdateScore(long score, bool isRemovingPoints)
        {
            this.scoreText.text = $"Score: {score}";

            if (flashCoroutine != null)
                StopCoroutine(flashCoroutine);

            flashCoroutine = StartCoroutine(FlashScore(isRemovingPoints));
        }

        private IEnumerator FlashScore(bool isRed)
        {
            var color = isRed ? negativeScoreColor : positiveScoreColor;

            for (var i = 0; i <= 15; i++)
            {
                var alpha = (float)(i % 2);
                this.scoreText.color = color * alpha;

                yield return new WaitForSeconds(0.05f);
            }

            this.scoreText.color = Color.white;
            this.flashCoroutine = null;
        }
    }
}