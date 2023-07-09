using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderBehaviour : MonoBehaviour
{
        [SerializeField]
    private AudioLevel audioLevel;
    public void OnSliderChange(float value){
        audioLevel.volume = value;
    }
}