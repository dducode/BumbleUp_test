using UnityEngine;
using UnityEngine.SceneManagement;

namespace BumbleUp.Core {

    public static class Game {

        private static ReactValue<GameState> m_state;
        public static ReactValue<GameState> State => m_state;


        public static void Run () {
            m_state.Value = GameState.Run;
            Time.timeScale = 1;
        }


        public static void Stop () {
            m_state.Value = GameState.Stop;
            Time.timeScale = 0;
        }


        public static void Restart () {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Run();
        }

    }

}