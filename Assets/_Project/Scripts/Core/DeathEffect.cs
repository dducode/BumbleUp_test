using UnityEngine;

namespace BumbleUp.Core {

    [RequireComponent(typeof(ParticleSystem))]
    public class DeathEffect : MonoBehaviour {

        private void Awake () {
            if (Camera.main != null) {
                Vector3 distance = Camera.main.transform.position - transform.position;
                distance /= 2;
                transform.position += distance;
            }
        }

    }

}