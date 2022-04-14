using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddShieldTower : Tower
{
    private float nextAddTime;
    private LayerMask towerLayer;
    private State state;
    private Animator anim;
    private AudioSource audioSource;
    enum State
    {
        Idle,
        Heal
    }
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        InitTower();
    }
    private void Start()
    {
        nextAddTime = Time.time;
        towerLayer =1<<LayerMask.NameToLayer("Tower");
    }
    private void Update()
    {
        if (Time.time > nextAddTime)
        {
            state = State.Heal;
            Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, new Vector2(shootRadius, shootRadius), 0, towerLayer);
            for (int i = 0; i < colliders.Length; i++)
            {
                Act(colliders[i].gameObject);
                audioSource.Play();
            }
            nextAddTime = Time.time + shootSpeedNow;
        }
        else state = State.Idle;
        SetAnim();
    }
    private void SetAnim()
    {
        if (state == State.Idle)
        {
            if (anim.GetBool("IsHealing"))
            {
                anim.SetBool("IsHealing", false);
            }
        }
        else
        {
            if (anim.GetBool("IsHealing"))
            {
                anim.SetBool("IsHealing", true);
            }
        }
    }
    public override void Act(GameObject o)
    {
        if(o!=_attackColliderObject)
            o.GetComponent<Tower>().GiveShieldBuff(abilityValueNow);
    }
}
