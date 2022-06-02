using System;
using Core;
using Sanity;
using UnityEngine;
using UnityEngine.Assertions;

namespace UI
{
    public class GameOverController : MonoBehaviour
    {
        [Header("dependencies")]
        [SerializeField]
        private GameStateHolder gameState;

        [SerializeField]
        private PlayerHolder player;

        private void Awake()
        {
            Assert.IsNotNull(gameState);
            Assert.IsNotNull(player);
        }
    }
}