using UnityEngine;
using System.Collections;

public class RespawnCharacter : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.collider.SendMessage("Die");
            Application.LoadLevel(Application.loadedLevel);
        }
    }

}
