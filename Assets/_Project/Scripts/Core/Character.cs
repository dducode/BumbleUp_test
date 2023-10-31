using System;
using System.Collections;
using BumbleUp.Core.Data;
using UnityEngine;

namespace BumbleUp.Core {

    public class Character : MonoBehaviour {

        public event Action NextChunkLanding;
        public event Action Death;

        [SerializeField]
        private CharacterData data;

        [SerializeField]
        private Transform view;

        [SerializeField]
        private DeathEffect deathEffect;

        private bool m_isGrounded;
        private bool m_holdJumping;


        private void Awake () {
            m_isGrounded = true;
        }


        private void Update () {
            if (m_holdJumping)
                Jump();
        }


        private void OnCollisionEnter (Collision collision) {
            if (collision.body.CompareTag("Enemy")) {
                Death?.Invoke();
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }


        public void HoldJumping () {
            m_holdJumping = true;
        }


        public void ReleaseJumping () {
            m_holdJumping = false;
        }


        public void Jump () {
            if (m_isGrounded)
                StartCoroutine(Jumping(0, 2, () => NextChunkLanding?.Invoke()));
        }


        public void SideJump (float value) {
            if (m_isGrounded) {
                float normalizedValue = value / Mathf.Abs(value);
                if (Mathf.Abs(transform.position.x + normalizedValue) - 5 < 0)
                    StartCoroutine(Jumping(normalizedValue * 2, 0));
            }
        }


        private IEnumerator Jumping (float side, float forward, Action onComplete = null) {
            m_isGrounded = false;
            Vector3 startPosition = transform.position;
            var targetPosition = new Vector3(
                startPosition.x + side, startPosition.y + forward, startPosition.z + forward
            );
            Vector3 viewPosition = view.transform.localPosition;
            float step = 0;

            while (step < 1) {
                float smoothStep = Mathf.SmoothStep(0, 1, step);
                transform.position = Vector3.Lerp(startPosition, targetPosition, smoothStep);
                viewPosition.y = Mathf.Sin(smoothStep * Mathf.PI) * data.jumpHeight;
                view.transform.localPosition = viewPosition;

                step += Time.deltaTime * data.jumpSpeed;
                yield return null;
            }

            transform.position = targetPosition;
            view.transform.localPosition = Vector3.zero;
            m_isGrounded = true;
            onComplete?.Invoke();
        }

    }

}