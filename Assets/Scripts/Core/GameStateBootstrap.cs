using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

namespace Core
{
    public class GameStateBootstrap : MonoBehaviour
    {
        [SerializeField]
        private GameStateHolder gameState;

        private void Awake()
        {
            Assert.IsNotNull(gameState);

            Debug.Log("Initializing game state...");
            gameState.Value = new GameState();
        }

        private void Start()
        {
            // TODO: Move this to a loading system eventually.
            SceneManager.LoadSceneAsync(SceneNames.TheIntersection, LoadSceneMode.Additive);
        }
    }
}