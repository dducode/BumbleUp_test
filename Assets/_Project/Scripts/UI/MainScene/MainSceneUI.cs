using System.Collections;
using BumbleUp.Core;
using TMPro;
using UnityEngine;

namespace BumbleUp.UI.MainScene {

    public class MainSceneUI : MonoBehaviour {

        [SerializeField]
        private TextMeshProUGUI score;

        [SerializeField]
        private PauseMenu pauseMenu;

        [SerializeField]
        private DeathWindow deathWindow;


        public void Construct (Player player, Character character) {
            player.score.OnValueChanged += UpdateScoreView;
            character.Death += () => StartCoroutine(ShowDeathMenu());
        }


        public void OnPause () {
            pauseMenu.Show();
        }


        private void UpdateScoreView (int value) {
            score.text = value.ToString();
        }


        private IEnumerator ShowDeathMenu () {
            yield return new WaitForSeconds(2);
            deathWindow.Show();
        }

    }

}