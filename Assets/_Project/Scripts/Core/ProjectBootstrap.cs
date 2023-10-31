using UnityEngine;
using UnityEngine.SceneManagement;

namespace BumbleUp.Core {

    public class ProjectBootstrap : MonoBehaviour {

        private void Awake () {
            Application.targetFrameRate = Screen.currentResolution.refreshRate;
            SceneManager.LoadScene(1);
        }

    }

}