using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBehaviour : MonoBehaviour
{
    [SerializeField]
    [Range(0,1)]
    private float fallSpeed;
    [SerializeField]
    private float scale;

    [SerializeField]
    public Transform spawnPoint;

    [SerializeField]
    public Timer timer;
    [SerializeField]
    private float timePunishment;

    private Rigidbody2D rb;
    private LaunchBehaviour lb;
    private bool falling;
    private AudioSource sfx;
    private bool hasPlayed;

    private void Start()
    {
        sfx = GetComponent<AudioSource>();
    }

    void Awake()
    {
        lb = GetComponent<LaunchBehaviour>();
        rb = GetComponent<Rigidbody2D>(); 
        Spawn(0);
    }

    void Update()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        if(falling == true)
        {
            if(transform.localScale.x > 0.3)
            {
                FallAnimation();
                if(hasPlayed == false)
                {
                    sfx.Play();
                    hasPlayed = true;
                }
            }
            else
            {
                Spawn(timePunishment);
                hasPlayed = false;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.CompareTag("Trap") && lb.flying == false && falling == false)
        {
            falling = true;
        }

        if(other.gameObject.CompareTag("Enemy") && lb.flying == false)
        {
            Spawn(timePunishment);
        }
    }

    private void FallAnimation()
    {
        transform.localScale *= (1 - fallSpeed);
    }

    public void Spawn(float punishment)
    {
        falling = false;
        lb.flying = false;
        rb.velocity = Vector2.zero;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        transform.localScale = new Vector3(scale, scale, scale);
        transform.position = spawnPoint.position;
        if(timer.startTimer)
        {
            timer.timerValue -= punishment;
        }
    }
}
