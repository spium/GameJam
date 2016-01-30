using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimelineManager : UnitySingleton<TimelineManager> {

    private List<Timeline> _timelines = new List<Timeline>();
    private Vector3 _spawn;

    public Transform spawnPoint;
    public GameObject repetitionPrefab;

    public override void Awake()
    {
        base.Awake();
        _spawn = spawnPoint.position;
    }

    void OnLevelWasLoaded(int level)
    {
        foreach (var tl in _timelines)
        {
            GameObject rep = (GameObject) Instantiate(repetitionPrefab, _spawn, Quaternion.identity);
            var replayer = rep.GetComponent<TimelineReplayer>();
            replayer.timeline = tl;
            replayer.enabled = true;
        }
    }

    public void RecordTimeline(Timeline timeline)
    {
        _timelines.Add(timeline);
    }




}
