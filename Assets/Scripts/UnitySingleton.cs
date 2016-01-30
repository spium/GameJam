using System;
using UnityEngine;

public class UnitySingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    private static bool _isQuitting = false;
    private bool _onlyInstance = true;

    protected bool OnlyInstance { get { return _onlyInstance; } }

    public static T Instance
    {
        get
        {
            if (_isQuitting)
                return null;

            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<T>();

                if (_instance == null)
                    _instance = new GameObject("Singleton_" + typeof(T)).AddComponent<T>();
            }

            return _instance;
        }
    }

    public virtual void Awake()
    {
        if (_instance != null && this != _instance)
        {
            //If a Singleton already exists and you find
            //another reference in scene, destroy it!
            //Debug.LogError("Detected multiple instances of singleton " + typeof(T) + ". Check your game objects.");
            _onlyInstance = false;
            Destroy(this.gameObject);
        }
        else if (_instance == null)
        {
            _instance = GetComponent<T>();
            DontDestroyOnLoad(_instance.gameObject);
        }
    }

    public virtual void OnDestroy()
    {
        if (_onlyInstance)
        {
            _isQuitting = true;
            _instance = null;
        }
    }
}
