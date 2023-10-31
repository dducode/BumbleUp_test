using System;

namespace BumbleUp.Core {

    public struct ReactValue<T> where T : unmanaged {

        public T Value {
            get => m_value;
            set {
                m_value = value;
                OnValueChanged?.Invoke(m_value);
            }
        }

        public event Action<T> OnValueChanged;

        private T m_value;

    }

}