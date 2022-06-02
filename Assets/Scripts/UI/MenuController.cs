using System;
using System.Collections;
using Core;
using Sanity;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class MenuController : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField]
        private GameStateHolder gameState;
        
        [SerializeField]
        private PlayerHolder player;
        
        [Header("UI")]
        [SerializeField]
        private Button playButton;
        
        [SerializeField]
        private Button aboutButton;
        
        [SerializeField]
        private Button quitButton;

        private void Awake()
        {
            Assert.IsNotNull(gameState);
            Assert.IsNotNull(player);
            Assert.IsNotNull(playButton);
            Assert.IsNotNull(aboutButton);
            Assert.IsNotNull(quitButton);
        }

        private void Start()
        {
            playButton.onClick.AddListener(OnPlayButtonClicked);
            aboutButton.onClick.AddListener(OnAboutButtonClicked);
            
            // Quit the game when the quit button is clicked.
            quitButton.onClick.AddListener(Application.Quit);
        }

        private void OnAboutButtonClicked()
        {
            // Enable the about screen, disable us.
            player.Value.AboutScreen.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }

        private void OnPlayButtonClicked()
        {
            StartCoroutine(PlayTheGame());
        }

        private IEnumerator PlayTheGame()
        {
            // Disable the Play button.
            playButton.enabled = false;

            // Activate the HUD
            player.Value.Hud.gameObject.SetActive(true);

            // Load into the intersection.
            var loadOperation = SceneManager.LoadSceneAsync(SceneNames.TheIntersection, LoadSceneMode.Additive);
            while (!loadOperation.isDone)
                yield return null;

            // Change to the Playing state.
            this.gameState.Value.CurrentState = CurrentGameState.Playing;
            
            // Make the play button work again, BUT, disable the menu.
            playButton.enabled = true;
            this.gameObject.SetActive(false);
        }
    }
}