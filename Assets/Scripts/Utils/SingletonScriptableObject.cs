using UnityEngine;

namespace Utils
{
    public abstract class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject, new() {
        static T _instance;

        public static T Instance {
            get {
                _instance = NullableInstance;

                if (_instance == null)
                {
                    // If not found, autocreate the asset object.
                    _instance = CreateInstance<T>();
                }

                return _instance;
            }
        }

        public static T NullableInstance {
            get {
                if (_instance == null)
                {
                    var t = new T();
                    var name = t.GetType().FullName;
                    _instance = Resources.Load(name) as T;
                }

                return _instance;
            }
        }
    }

}