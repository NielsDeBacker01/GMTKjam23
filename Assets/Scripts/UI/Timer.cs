using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float counter;
    public float timerValue = 5;
    public bool startTimer;

    private void Awake() {
        startTimer = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (timerValue > 0 && startTimer)
        {
            timerValue -= Time.deltaTime;
        }

        string seconds = (Mathf.Round(timerValue) % 60) < 10 ?
            "0" + (Mathf.Round(timerValue) % 60) : 
            (Mathf.Round(timerValue) % 60).ToString();

        string minutes = Mathf.Floor(Mathf.Round(timerValue)/60) < 10 ? 
            "0" + Mathf.Floor(Mathf.Round(timerValue)/60) : 
            Mathf.Floor(Mathf.Round(timerValue)/60).ToString();

        timerText.text = minutes + ":" + seconds;
 
        if (timerValue <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
