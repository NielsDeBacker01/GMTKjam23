using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeControls : MonoBehaviour
{
    enum states {Neutral, Charging, Launching, LaunchFreeze, Recharging};

    [SerializeField]
    [Range(0, 1)]
    private float shrinkSpeed;
    [SerializeField]
    [Range(0, 10)]
    private float expandSpeed;
    [SerializeField]
    [Range(0, 1)]
    private float reshrinkSpeed;
    [SerializeField]
    private float sizeLowerLimit;
    [SerializeField]
    private float sizeUpperLimit;
    [SerializeField]
    private float extendFreeze;

    private states currentState;
    private float cooldown;

    void Awake()
    {
        currentState = states.Neutral;
    }

    void FixedUpdate() 
    {
        float newScale = 1;
        switch (currentState)
        {
            case states.Neutral:
                if(Input.GetKey(KeyCode.Space))
                {
                    currentState = states.Charging;
                }
                break;
            case states.Charging:
                if(Input.GetKey(KeyCode.Space))
                {
                    newScale = transform.localScale.x * (1-shrinkSpeed);
                    if(newScale < sizeLowerLimit)
                    {
                        newScale = sizeLowerLimit;
                    }
                    changeScale(newScale);
                }
                else
                {
                    currentState = states.Launching;
                }
                break;
            case states.Launching:
                newScale = transform.localScale.x * (1+expandSpeed);
                if(newScale > sizeUpperLimit)
                {
                    newScale = sizeUpperLimit;
                    currentState = states.LaunchFreeze;
                    cooldown = extendFreeze;
                }
                changeScale(newScale);
                break;
            case states.LaunchFreeze:
                cooldown -= Time.fixedDeltaTime;
                if(cooldown < 0)
                {
                    currentState = states.Recharging;
                }
                break;
            case states.Recharging:
                newScale = transform.localScale.x * (1-reshrinkSpeed);
                if(newScale < 1)
                {
                    newScale = 1;
                    currentState = states.Neutral;
                }
                changeScale(newScale);
                break;
        }
    }

    void changeScale(float newScale)
    {
        transform.localScale = new Vector3(newScale, transform.localScale.y, transform.localScale.z);
        transform.localPosition = new Vector3(-0.222f + (newScale / 2), 0, 0);
    }
}
