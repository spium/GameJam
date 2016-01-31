using UnityEngine;
using System.Collections;

public class PlatformMovement : MonoBehaviour {

    public float distanceRight = 1f;
    public float speed = 1f;
    public float currPosition = 0f;
    private float startPosition = 0f;
    public bool right = true;

	// Use this for initialization
	void Start () {
        startPosition = transform.position.x-currPosition;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (right) currPosition += speed * Time.deltaTime;
        else currPosition -= speed * Time.deltaTime;

        if (currPosition < 0) right = true;
        else if (currPosition > distanceRight) right = false;

        transform.position = new Vector3(startPosition+currPosition, transform.position.y);
    }
}
