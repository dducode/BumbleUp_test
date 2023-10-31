using BumbleUp.Core;
using BumbleUp.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BumbleUp.UI.MainScene {

    public class DeathWindow : MonoBehaviour {

        [SerializeField]
        private Canvas deathWindow;

        private CanvasGroup m_deathWindowGroup;


        private void Awake () {
            m_deathWindowGroup = deathWindow.GetComponent<CanvasGroup>();
        }


        public void Show () {
            deathWindow.Show(m_deathWindowGroup, this, Game.Stop);
        }


        public void RestartGame () {
            Game.Restart();
        }


        public void OnExit () {
            SceneManager.LoadScene(1);
        }

    }

}