using UnityEngine;

public class Sample {

    public Vector2 position;
    public float scaleX;
    public float speed, vspeed;
    public bool crouch, ground;

    public Sample(Vector2 position, float scaleX, float speed, float vspeed, bool crouch, bool ground)
    {
        this.position = position;
        this.scaleX = scaleX;
        this.speed = speed;
        this.vspeed = vspeed;
        this.crouch = crouch;
        this.ground = ground;
    }
}
