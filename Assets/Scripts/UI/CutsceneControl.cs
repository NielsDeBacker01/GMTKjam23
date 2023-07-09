using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneControl : MonoBehaviour
{
    private int slide;
    public GameObject png1;
    public GameObject png2;
    public GameObject png3;
    public GameObject png4;
    private void Start() {
        slide = 0;
        png1.SetActive(false);
        png2.SetActive(false);
        png3.SetActive(false);
        png4.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            slide += 1;
        }

        switch (slide)
        {
            case 0:
                png1.SetActive(true);
                break;
            case 1:
                png1.SetActive(false);
                png2.SetActive(true);
                break;
            case 2:
                png2.SetActive(false);
                png3.SetActive(true);
                break;
            case 3:
                png3.SetActive(false);
                png4.SetActive(true);
                break;
            case 4:
                SceneManager.LoadScene("FullGame");
                break;
        }
    }
}
