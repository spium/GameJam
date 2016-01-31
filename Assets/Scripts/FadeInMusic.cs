using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class FadeInMusic : MonoBehaviour
{
    public float fadeRate;

    private AudioSource _audio;
    
    void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        while (_audio.volume < 0.9f)
        {
            _audio.volume = Mathf.Lerp(_audio.volume, 1.0f, fadeRate * Time.deltaTime);
            yield return null;
        }

       _audio.volume = 1.0f;
    }
}
