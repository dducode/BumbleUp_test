using BumbleUp.Core;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BumbleUp.UI.StartScene {

    public class StartSceneUI : MonoBehaviour {

        [SerializeField]
        private Button startGameButton;

        [SerializeField]
        private Button exitGameButton;
        
        
        private void Awake () {
            startGameButton.onClick.AddListener(OnStartGame);
            exitGameButton.onClick.AddListener(OnExitGame);
        }
        
        
        private void OnStartGame () {
            SceneManager.LoadScene(2);
            Game.Run();
        }
        
        
        private void OnExitGame () {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
        }

    }

}