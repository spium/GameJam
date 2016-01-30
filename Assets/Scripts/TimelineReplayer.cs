using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Collider2D))]
public class TimelineReplayer : MonoBehaviour {

    public Timeline timeline;

    private int _currentFrame = 0;
    private Rigidbody2D _rb;
    private Animator _anim;
    private Collider2D[] _colliders;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _colliders = GetComponents<Collider2D>();
    }

    void FixedUpdate()
    {
        if (_currentFrame < timeline.samples.Count)
        {
            var sample = timeline.samples[_currentFrame];
            _rb.MovePosition(sample.position);
            transform.localScale = new Vector3(sample.scaleX, transform.localScale.y, transform.localScale.z);
            _anim.SetFloat("Speed", sample.speed);
            _anim.SetFloat("vSpeed", sample.vspeed);
            _anim.SetBool("Crouch", sample.crouch);
            _anim.SetBool("Ground", sample.ground);
            ++_currentFrame;
        }
        else
        {
            _rb.velocity = new Vector2();
            _anim.SetFloat("Speed", 0f);
            _anim.SetFloat("vSpeed", 0f);
            _anim.SetBool("Crouch", false);
            _anim.SetBool("Ground", true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            foreach (var col in _colliders)
            {
                col.isTrigger = false;
            }
        }
    }
}
