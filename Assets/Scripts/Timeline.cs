using System.Collections.Generic;
using UnityEngine;

public class Timeline
{
    public List<Sample> samples;

    public Timeline(int maxLength)
    {
        samples = new List<Sample>(maxLength);
    }
}