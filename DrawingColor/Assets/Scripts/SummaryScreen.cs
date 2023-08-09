using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummaryScreen : MonoBehaviour
{
    public static SummaryScreen instance;

    private void Awake()
    {
        instance = this;
    }

    float timePassed;

    public void SetTimePassed(int timePass)
    {
        timePass = timePass;
    }

    public void StartGameEndSequence()
    {
        if(timePassed < 180 && timePassed > 120)
        {
            
        }
    }
}
