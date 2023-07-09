using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float timerValue = 12;

    // Update is called once per frame
    void Update()
    {
        if (timerValue > 0)
            timerValue -= Time.deltaTime;
        
        if (timerValue < 10)
            timerText.text = "00:0" + Mathf.Round(timerValue).ToString();
        else
            timerText.text = "00:" + Mathf.Round(timerValue).ToString();


        if (timerValue <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
