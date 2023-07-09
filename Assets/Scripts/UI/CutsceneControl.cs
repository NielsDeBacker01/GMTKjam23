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
    private void Start() {
        slide = 0;
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
            case 1:
                png1.SetActive(false);
                break;
            case 2:
                png2.SetActive(false);
                break;
            case 3:
                png3.SetActive(false);
                break;
            case 4:
                SceneManager.LoadScene("FullGame");
                break;
        }
    }
}
