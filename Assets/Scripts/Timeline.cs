using System.Collections.Generic;
using UnityEngine;

public class Timeline
{
    public List<Sample> samples;
    public Vector3 initialPosition;

    public Timeline(Vector3 initialPosition)
    {
        this.initialPosition = initialPosition;
        samples = new List<Sample>();
    }
}