using BumbleUp.Extensions;
using UnityEngine;

namespace BumbleUp.Core {

    public class GameObjectsController : MonoBehaviour {

        [SerializeField]
        private Transform[] stairsChunks;

        [SerializeField]
        private Transform worldFloor;

        [SerializeField]
        private Transform wall;

        public Transform[] StairsChunks => stairsChunks;


        public void Construct (Character character) {
            character.NextChunkLanding += MoveObjects;
        }


        private void MoveObjects () {
            MoveChunks();
            MoveWall();
            MoveFloor();
        }


        private void MoveChunks () {
            Vector3 lastChunkPosition = stairsChunks[stairsChunks.Length - 1].position;
            lastChunkPosition += WorldConstants.CommonOffset;
            stairsChunks[0].position = lastChunkPosition;
            stairsChunks.MoveForward();
        }


        private void MoveWall () {
            wall.position += WorldConstants.CommonOffset;
        }


        private void MoveFloor () {
            worldFloor.position += WorldConstants.CommonOffset;
        }

    }

}