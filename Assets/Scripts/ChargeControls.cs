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
    [SerializeField]
    private float launchPower;
    [SerializeField]
    private Rigidbody2D rb;
    private float launchChargeMultiplier;

    private states currentState;
    private float cooldown;
    public AudioSource m_AudioSource;

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
                GetComponent<BoxCollider2D>().isTrigger = false;
                rb.mass = 1;
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
                    launchChargeMultiplier = ((1 - transform.localScale.x) / (1 - sizeLowerLimit));
                    rb.mass = 100;
                    GetComponent<BoxCollider2D>().isTrigger = true;
                }
                break;
            case states.Launching:
                newScale = transform.localScale.x * (1+expandSpeed);
                if(newScale > 1 + ((sizeUpperLimit - 1) * launchChargeMultiplier))
                {
                    newScale = 1 + ((sizeUpperLimit - 1) * launchChargeMultiplier);
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

    private void OnTriggerStay2D(Collider2D other) 
    {
        if( other.gameObject.CompareTag("Hero")
            && (currentState == states.Launching || currentState == states.LaunchFreeze || currentState == states.Recharging))
        {
            other.gameObject.GetComponent<LaunchBehaviour>().Launch(transform.right * launchPower * launchChargeMultiplier);
            m_AudioSource.Play();
        }
    }
}
