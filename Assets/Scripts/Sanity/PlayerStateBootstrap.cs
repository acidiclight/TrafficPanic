using System;
using UI;
using UnityEngine;
using UnityEngine.Assertions;

namespace Sanity
{
    public class PlayerStateBootstrap : MonoBehaviour
    {
        [Header("Holder")]
        [SerializeField]
        private PlayerHolder playerHolder;

        [Header("Prefabs")]
        [SerializeField]
        private GameObject uiRootPrefab;

        [SerializeField]
        private AboutController aboutScreenPrefab;

        [SerializeField]
        private MenuController menuPrefab;
        
        private void Awake()
        {
            Assert.IsNotNull(playerHolder);
            Assert.IsNotNull(uiRootPrefab);
            Assert.IsNotNull(menuPrefab);
            Assert.IsNotNull(aboutScreenPrefab);
        }

        private void Start()
        {
            var uiRoot = Instantiate(uiRootPrefab);
            var menu = Instantiate(menuPrefab, uiRoot.transform);
            var about = Instantiate(aboutScreenPrefab, uiRoot.transform);
            this.playerHolder.Value = new PlayerInstance(menu, about);

            menu.gameObject.SetActive(true);
            about.gameObject.SetActive(false);
        }
    }
}