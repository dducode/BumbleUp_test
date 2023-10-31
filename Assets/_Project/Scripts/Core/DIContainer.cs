using BumbleUp.UI.MainScene;
using UnityEngine;

namespace BumbleUp.Core {

    public class DIContainer : MonoBehaviour {

        [SerializeField]
        private Player player;

        [SerializeField]
        private Character character;

        [SerializeField]
        private GameObjectsController controller;

        [SerializeField]
        private MainSceneUI mainSceneUI;

        [SerializeField]
        private EnemySpawner enemySpawner;


        private void Awake () {
            player.Construct(character);
            controller.Construct(character);
            mainSceneUI.Construct(player, character);
            enemySpawner.Construct(controller.StairsChunks, character);
        }

    }

}