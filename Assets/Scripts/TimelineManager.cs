using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimelineManager : UnitySingleton<TimelineManager> {

    private Queue<Timeline> _timelines;
    private Vector3 _spawn;
    private int _currentLevel = -1;

    [Tooltip("Maximum duration of a recording in seconds")]
    public float maxRecordingDuration;
    [Tooltip("Maximum number of simultaneous repetitions")]
    public int maxRepetitions;

    public Transform spawnPoint;
    public GameObject repetitionPrefab;

    public int MaxTimelineFrames { get; private set; }

    public override void Awake()
    {
        base.Awake();
        _timelines = new Queue<Timeline>(maxRepetitions);
        _spawn = spawnPoint.position;
        MaxTimelineFrames = (int)(maxRecordingDuration / Time.fixedDeltaTime);
        _currentLevel = Application.loadedLevel;
    }

    void OnLevelWasLoaded(int level)
    {
        Debug.Log("level: " + level + ", current: " + _currentLevel);

        if (level == _currentLevel)
        {
            foreach (var tl in _timelines)
            {
                GameObject rep = (GameObject)Instantiate(repetitionPrefab, _spawn, Quaternion.identity);
                var replayer = rep.GetComponent<TimelineReplayer>();
                replayer.timeline = tl;
                replayer.enabled = true;
            }
        }
        else
        {
            ResetTimelines();
            _currentLevel = level;
        }
    }

    public void RecordTimeline(Timeline timeline)
    {
        if (_timelines.Count == maxRepetitions)
            _timelines.Dequeue();

        _timelines.Enqueue(timeline);
    }

    public void ResetTimelines()
    {
        _timelines.Clear();
    }


}
