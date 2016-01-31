using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : UnitySingleton<MusicManager>
{
    private AudioSource[] audio;
    private double SongStart;
    public float bpm = 160;
    private float bpmForSec;
    public float FadeRate = 3f;
    public int DefaultStart = 0;

    void Start()
    {
        audio = GetComponents<AudioSource>();
        SongStart = AudioSettings.dspTime;
        audio[DefaultStart].PlayScheduled(AudioSettings.dspTime);
        bpmForSec = 60 / bpm;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.G))
            if (audio[0].isPlaying)
                ChangeTrack(1);
            else
                ChangeTrack(0);
    }

    void ChangeTrack(int number)
    {
        float conto = (float)((AudioSettings.dspTime - SongStart) % bpmForSec);

        conto = bpmForSec - conto;

        for (int i = 0; i < audio.Length; i++)
        {
            if (audio[i].isPlaying)
                StartCoroutine(FadeOut(i));
        }

        audio[number].PlayScheduled(AudioSettings.dspTime + conto);
    }

    IEnumerator FadeOut(int i)
    {
        while (audio[i].volume > 0.1f)
        {
            audio[i].volume = Mathf.Lerp(audio[i].volume, 0.0f, FadeRate * Time.deltaTime);
            yield return null;
        }
        
        audio[i].volume = 0.0f;
        audio[i].Stop();
    }

    IEnumerator FadeIn(int i)
    {
        while (audio[i].volume < 0.9)
        {
            audio[i].volume = Mathf.Lerp(audio[i].volume, 1.0f, FadeRate * Time.deltaTime);
            yield return null;
        }

        audio[i].volume = 1.0f;
    }
}
