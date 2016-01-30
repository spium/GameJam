using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets._2D;
using UnityEditorInternal;

//[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class TimelineRecorder : MonoBehaviour
{
    private Timeline _timeline;
    //private Rigidbody2D _rb;
    private Animator _anim;

    void Awake()
    {
        //_rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _timeline = new Timeline(transform.position);
    }

    void FixedUpdate()
    {
        _timeline.samples.Add(new Sample(transform.position, transform.localScale.x, _anim.GetFloat("Speed"), _anim.GetFloat("vSpeed"), _anim.GetBool("Crouch"), _anim.GetBool("Ground")));
    }

    void Die()
    {
        TimelineManager.Instance.RecordTimeline(_timeline);
    }
}
