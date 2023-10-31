using UnityEngine;

namespace BumbleUp.Core {

    [RequireComponent(typeof(Rigidbody))]
    public class Enemy : MonoBehaviour {

        private ObjectPool<Enemy> m_pool;
        private Rigidbody m_rb;


        public void Construct (ObjectPool<Enemy> pool) {
            m_pool = pool;
        }


        private void Awake () {
            m_rb = GetComponent<Rigidbody>();
            Transform character = GameObject.FindWithTag("Character").transform;
            m_rb.AddForce((character.position - transform.position).normalized, ForceMode.VelocityChange);
        }


        private void OnTriggerEnter (Collider other) {
            if (other.CompareTag("WorldBound")) {
                m_rb.velocity = Vector3.zero;
                m_rb.angularVelocity = Vector3.zero;
                m_pool.Release(this);
            }
        }

    }

}