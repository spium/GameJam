﻿using UnityEngine;
using UnityEngine.Events;
public class EnvInteractionTrigger : MonoBehaviour
{
    public UnityEvent onEnter;
    public UnityEvent onExit;

    void OnTriggerEnter2D(Collider2D other)
    {
        onEnter.Invoke();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        onExit.Invoke();
    }
}
