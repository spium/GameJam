using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class DoorOpenClosed : MonoBehaviour
{
    private Collider2D colliderDoor;

    void Awake()
    {
        colliderDoor = GetComponent<Collider2D>();
    }

    public void OpenDoor()
    {
        colliderDoor.enabled = false;
        //TODO animazione
    }

    public void CloseDoor()
    {
        colliderDoor.enabled = true;
        //TODO animazione
    }
}
