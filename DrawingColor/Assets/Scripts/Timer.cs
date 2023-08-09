using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Image timerFillbar;

    float barDivision;

    
    public float totalTime = 120.0f; // Total time for the countdown in seconds
    private float remainingTime;   // Current remaining time

    public Text timerText; // Reference to a UI Text element to display the timer

    public UnityEngine.Events.UnityEvent onTimerEnd; // Event to trigger when the timer ends

    private void Start()
    {
        timerFillbar.fillAmount = 0;
        barDivision = 1 / totalTime;

        remainingTime = totalTime;
        UpdateTimerDisplay();
    }

    private void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;

            UpdateTimerDisplay();

            if (remainingTime <= 0)
            {
                remainingTime = 0;
                UpdateTimerDisplay();
                TimerEnded();
            }
        }
    }

    void UpdateTimerDisplay()
    {
        Debug.Log("Timer: " + FormatTime(remainingTime));
        timerFillbar.fillAmount = (totalTime - remainingTime) / totalTime;
        if (timerText != null)
        {
            timerText.text = FormatTime(remainingTime);
        }
    }

    void TimerEnded()
    {
        // Trigger the event when the timer ends
        if (onTimerEnd != null)
        {
            onTimerEnd.Invoke();
        }
    }

    string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}