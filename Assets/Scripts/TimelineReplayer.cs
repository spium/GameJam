using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class TimelineReplayer : MonoBehaviour {

    public Timeline timeline;

    private int _currentFrame = 0;
    private Rigidbody2D _rb;
    private Animator _anim;
    private Collider2D[] _colliders;
    private SpriteRenderer _sprite;

    private Color _startColor, _endColor;
    private float _recordingFrames;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _colliders = GetComponents<Collider2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _startColor = _sprite.material.GetColor("_Color");
        _endColor = new Color(_startColor.r, _startColor.g, _startColor.b, 0f);
    }

    void Start()
    {
        _recordingFrames = TimelineManager.Instance.MaxTimelineFrames;
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
            _anim.SetBool("Head", sample.head);
            _anim.SetBool("Dead", sample.dead);
        }
        else if (_currentFrame >= _recordingFrames)
        {
            Destroy(gameObject);
        }
        else
        {
            _rb.velocity = new Vector2();
            _anim.SetFloat("Speed", 0f);
            _anim.SetFloat("vSpeed", 0f);
            _anim.SetBool("Crouch", false);
            _anim.SetBool("Ground", true);
        }

        //lerp sprite alpha
        _sprite.material.SetColor("_Color", Color.Lerp(_startColor, _endColor, _currentFrame / _recordingFrames));
        ++_currentFrame;
    }
}
