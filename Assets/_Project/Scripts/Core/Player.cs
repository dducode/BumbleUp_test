using UnityEngine;
using UnityEngine.InputSystem;

namespace BumbleUp.Core {

    public class Player : MonoBehaviour {

        public ReactValue<int> score;

        [SerializeField]
        private InputActionAsset input;

        private InputActionMap m_gameplayMap;
        private InputAction m_jump;
        private InputAction m_sideJump;
        private Character m_controlledCharacter;

        private int m_score;


        public void Construct (Character character) {
            m_controlledCharacter = character;
            m_controlledCharacter.NextChunkLanding += AddScore;
            m_controlledCharacter.Death += () => enabled = false;
        }


        private void Awake () {
            m_gameplayMap = input.FindActionMap("gameplay");
            m_jump = m_gameplayMap.FindAction("jump");
            m_sideJump = m_gameplayMap.FindAction("sideJump");
            Disable();
        }


        public void Update () {
            if (m_jump.WasPerformedThisFrame())
                m_controlledCharacter.HoldJumping();

            if (m_jump.WasReleasedThisFrame()) {
                m_controlledCharacter.Jump();
                m_controlledCharacter.ReleaseJumping();
            }

            if (m_sideJump.WasPerformedThisFrame())
                m_controlledCharacter.SideJump(m_sideJump.ReadValue<float>());
        }


        public void Enable () {
            enabled = true;
        }


        public void Disable () {
            enabled = false;
        }


        private void OnEnable () {
            m_gameplayMap.Enable();
        }


        private void OnDisable () {
            m_gameplayMap.Disable();
        }


        private void OnDestroy () {
            m_gameplayMap.Dispose();
            m_jump.Reset();
            m_sideJump.Reset();
        }


        private void AddScore () {
            score.Value++;
        }

    }

}