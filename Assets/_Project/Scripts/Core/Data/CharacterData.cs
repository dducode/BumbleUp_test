using UnityEngine;

namespace BumbleUp.Core.Data {

    [CreateAssetMenu(fileName = nameof(CharacterData), menuName = "Data/" + nameof(CharacterData))]
    public class CharacterData : ScriptableObject {

        public float jumpSpeed = 3;
        public float jumpHeight = 2;

    }

}