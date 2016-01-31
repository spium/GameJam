using UnityEngine;
using System.Collections;

public class StickToMovingPlatform : MonoBehaviour
{
    private Transform _initialParent;

    void Start()
    {
        _initialParent = transform.parent;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "MovingPlatform")
        {
            transform.parent = collision.collider.transform;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "MovingPlatform")
        {
            transform.parent = _initialParent;
        }
    }
}
