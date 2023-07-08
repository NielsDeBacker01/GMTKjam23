using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float counter;
    private float timerValue = 59;

    // Update is called once per frame
    void Update()
    {
        if (timerValue > 0)
        {
            timerValue -= Time.deltaTime;
        }

        timerText.text = "00:" + Mathf.Round(timerValue).ToString();
    }
}
