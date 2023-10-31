using UnityEngine;

namespace BumbleUp.Core {

    public class CameraController : MonoBehaviour {

        [SerializeField]
        private Transform target;

        private Vector3 m_offset;


        private void Awake () {
            m_offset = transform.position - target.position;
            Game.State.OnValueChanged += state => enabled = state == GameState.Run;
        }


        private void LateUpdate () {
            if (target == null)
                return;

            Vector3 targetPosition = target.position;
            targetPosition.x = 0;
            transform.position = targetPosition + m_offset;
        }

    }

}