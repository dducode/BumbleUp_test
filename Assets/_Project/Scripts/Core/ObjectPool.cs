using System;
using System.Collections.Generic;
using Object = UnityEngine.Object;

namespace BumbleUp.Core {

    public class ObjectPool<T> where T : Object {

        private readonly Stack<T> m_objects;
        private readonly Func<T> m_createFunc;
        private readonly Action<T> m_onGet;
        private readonly Action<T> m_onRelease;


        public ObjectPool (Func<T> createFunc, Action<T> onGet, Action<T> onRelease) {
            m_objects = new Stack<T>();
            m_createFunc = createFunc;
            m_onGet = onGet;
            m_onRelease = onRelease;
        }


        public T Get () {
            T obj = m_objects.Count > 0 ? m_objects.Pop() : m_createFunc();
            m_onGet?.Invoke(obj);
            return obj;
        }


        public void Release (T obj) {
            m_onRelease?.Invoke(obj);
            m_objects.Push(obj);
        }

    }

}