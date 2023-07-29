using UnityEngine;

namespace __MoyaGames.Scripts.Utils
{
    public class PersistentSingleton<T> : Singleton<T> where T : Singleton<T>
    {
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }
    }
}