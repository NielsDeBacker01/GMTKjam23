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
    private float launchChargeMultiplier;

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
                GetComponent<BoxCollider2D>().enabled = true;
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

    private void OnCollisionStay2D(Collision2D other) 
    {
        if( (other.gameObject.CompareTag("Hero") || other.gameObject.CompareTag("Enemy"))
            && (currentState == states.Launching || currentState == states.LaunchFreeze || currentState == states.Recharging))
        {
            Launch(other.gameObject);
        }
    }

    public void Launch(GameObject launchable)
    {
        GetComponent<BoxCollider2D>().enabled = false;
        Rigidbody2D rb = launchable.GetComponent<Rigidbody2D>();
        rb.AddRelativeForce(transform.right * launchPower * launchChargeMultiplier);
    }
}
