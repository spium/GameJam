using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class BrazierLogic : MonoBehaviour
{
    [Tooltip("How many seconds before the brazier burns off (0 = infinite)")]
    public float burnTime;

    private float _lightingTime;
    private bool _isLit;

    private SpriteRenderer _sprite;

    void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        GameManager.Instance.RegisterBrazier();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        _lightingTime = Time.fixedTime;
        _sprite.color = Color.red;

        if (!_isLit)
        {
            GameManager.Instance.BrazierChanged(true);
            _isLit = true;
        }
    }

    void FixedUpdate()
    {
        var duration = Time.fixedTime - _lightingTime;
        if (_isLit)
        {
            if (duration < burnTime)
            {
                _sprite.color = Color.Lerp(Color.red, Color.green, duration / burnTime);
            }
            else if(burnTime > 0f)
            {
                _isLit = false;
                _sprite.color = Color.green;
                GameManager.Instance.BrazierChanged(false);
            }
        }
    }
}
