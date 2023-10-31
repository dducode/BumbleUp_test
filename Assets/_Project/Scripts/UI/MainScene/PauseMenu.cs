using BumbleUp.Core;
using BumbleUp.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BumbleUp.UI.MainScene {

    public class PauseMenu : MonoBehaviour {

        [SerializeField]
        private Canvas pauseMenu;

        private CanvasGroup m_pauseMenuGroup;


        private void Awake () {
            m_pauseMenuGroup = pauseMenu.GetComponent<CanvasGroup>();
        }


        public void Show () {
            pauseMenu.Show(m_pauseMenuGroup, this, Game.Stop);
        }


        public void OnContinue () {
            pauseMenu.Hide(m_pauseMenuGroup, this);
            Game.Run();
        }


        public void OnExit () {
            SceneManager.LoadScene(1);
        }

    }

}