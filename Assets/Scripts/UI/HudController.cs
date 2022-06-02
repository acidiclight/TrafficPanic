using System;
using System.Collections;
using Core;
using Sanity;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

namespace UI
{
    public class HudController : MonoBehaviour
    {
        private Coroutine flashCoroutine;
        private Coroutine hsFlashCoroutine;
        
        
        [Header("dependencies")]
        [SerializeField]
        private GameStateHolder gameState;

        [SerializeField]
        private PlayerHolder player;
        
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

        [SerializeField]
        private TextMeshProUGUI highScoreText;

        private void Awake()
        {
            Assert.IsNotNull(gameState);
            Assert.IsNotNull(player);
            Assert.IsNotNull(trafficLightPrefab);
            Assert.IsNotNull(scoreText);
            Assert.IsNotNull(highScoreText);
        }

        private void OnEnable()
        {
            this.scoreText.text = $"Score: {gameState.Value.Score}";
            scoreText.color = Color.white;
            
            this.highScoreText.text = $"High Score: {gameState.Value.HighScore}";
            highScoreText.color = Color.white;

            gameState.Value.ScoreUpdated += UpdateScore;
            gameState.Value.HighScoreUpdated += OnHighScoreUpdated;
            gameState.Value.CurrentStateChanged += HandleCurrentStateChanged;
        }

        private void OnHighScoreUpdated(long newHighScore)
        {
            highScoreText.text = $"High Score: {newHighScore}";
            
            if (hsFlashCoroutine != null)
                StopCoroutine(hsFlashCoroutine);

            hsFlashCoroutine = StartCoroutine(FlashHighScore());
        }

        private void OnDisable()
        {
            gameState.Value.ScoreUpdated -= UpdateScore;
            gameState.Value.CurrentStateChanged -= HandleCurrentStateChanged;
            gameState.Value.HighScoreUpdated -= OnHighScoreUpdated;
        }

        private void HandleCurrentStateChanged(CurrentGameState newState)
        {
            switch (newState)
            {
                case CurrentGameState.GameOver:
                    ShowGameOverScreen();
                    break;
            }
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
        
        private IEnumerator FlashHighScore()
        {
            var color = this.positiveScoreColor;

            for (var i = 0; i <= 15; i++)
            {
                var alpha = (float)(i % 2);
                this.highScoreText.color = color * alpha;

                yield return new WaitForSeconds(0.05f);
            }

            this.highScoreText.color = Color.white;
            this.hsFlashCoroutine = null;
        }


        public TrafficLightController SpawnTrafficLightHud(Transform levelArea)
        {
            var trafficLight = Instantiate(trafficLightPrefab, this.transform);
            trafficLight.AssociateWithLevelObject(levelArea);
            return trafficLight;
        }

        private void ShowGameOverScreen()
        {
            player.Value.GameOverScreen.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}