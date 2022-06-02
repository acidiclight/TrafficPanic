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
    public class GameOverController : MonoBehaviour
    {
        [Header("dependencies")]
        [SerializeField]
        private GameStateHolder gameState;

        [SerializeField]
        private PlayerHolder player;

        [Header("UI")]
        [SerializeField]
        private Button tryAgainButton;
        
        [SerializeField]
        private Button mainMenuButton;
        
        [SerializeField]
        private Button quitButton;

        private void Awake()
        {
            Assert.IsNotNull(gameState);
            Assert.IsNotNull(player);
            
            Assert.IsNotNull(tryAgainButton);
            Assert.IsNotNull(mainMenuButton);
            Assert.IsNotNull(quitButton);
        }

        private void Start()
        {
            quitButton.onClick.AddListener(Application.Quit);
            
            tryAgainButton.onClick.AddListener(HandleTryAgainButton);
            mainMenuButton.onClick.AddListener(HandleMainMenuButton);
        }

        private void HandleMainMenuButton()
        {
            DisableAllButtons();

            StartCoroutine(ReturnToMainMenu());
        }

        private void DisableAllButtons()
        {
            tryAgainButton.enabled = false;
            mainMenuButton.enabled = false;
            quitButton.enabled = false;
        }
        
        private void EnableAllButtons()
        {
            tryAgainButton.enabled = true;
            mainMenuButton.enabled = true;
            quitButton.enabled = true;
        }
        
        private void HandleTryAgainButton()
        {
            DisableAllButtons();

            StartCoroutine(ReloadGame());
        }

        private IEnumerator UnloadCurrentLevel()
        {
            // Reset all of the game's state.
            this.gameState.Value.Nuke();

            // Unload the intersection scene and wait for that to happen.
            var unload = SceneManager.UnloadSceneAsync(SceneNames.TheIntersection,
                UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
            while (!unload.isDone)
                yield return null;
        }

        private IEnumerator ReturnToMainMenu()
        {
            // This will unload the current level.
            yield return StartCoroutine(UnloadCurrentLevel());
            
            // Open the main menu.
            player.Value.MainMenu.gameObject.SetActive(true);
            
            //  Disable ourselves after re-enabling our buttons.
            EnableAllButtons();
            this.gameObject.SetActive(false);
        }
        
        private IEnumerator ReloadGame()
        {
            // This will unload the current level.
            yield return StartCoroutine(UnloadCurrentLevel());
            
            // Set the game state.
            gameState.Value.CurrentState = CurrentGameState.Playing;
            
            // Enable the HUD.
            player.Value.Hud.gameObject.SetActive(true);
            
            // Reload the intersection scene and  wait for that to happen.
            var reload = SceneManager.LoadSceneAsync(SceneNames.TheIntersection, LoadSceneMode.Additive);
            while (!reload.isDone)
                yield return null;
            
            //  Disable ourselves after re-enabling our buttons.
            EnableAllButtons();
            this.gameObject.SetActive(false);
        }
    }
}