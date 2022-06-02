using System;
using Sanity;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace UI
{
    public class AboutController : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField]
        private PlayerHolder playerHolder;
        
        [Header("UI")]
        [SerializeField]
        private Button backButton;

        private void Awake()
        {
            Assert.IsNotNull(playerHolder);
            Assert.IsNotNull(backButton);
        }

        private void Start()
        {
            backButton.onClick.AddListener(GoBack);
        }

        private void GoBack()
        {
            // Re-enable the Main Menu
            playerHolder.Value.MainMenu.gameObject.SetActive(true);
            
            // Disable ourselves.
            this.gameObject.SetActive(false);
        }
    }
}