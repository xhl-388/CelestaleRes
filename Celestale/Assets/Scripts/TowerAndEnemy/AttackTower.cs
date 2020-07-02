using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// tower that can attack enemies
/// </summary>
public class AttackTower : Tower
{
    [SerializeField]
    protected List<GameObject> enemyList = new List<GameObject>();    //攻击范围内的敌人
    protected float nextAttackTime;                                   //下次攻击的事时间
    protected List<GameObject> defendEnemy = new List<GameObject>();
    public GameObject bulletOfThis;                                 //该炮台的炮弹的prefab
    protected State state;
    private Animator anim;
    protected AudioSource audioSource;
    protected enum State
    {
         Idle,
         Attack
    }
    protected virtual void Awake()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        InitTower();                //初始化炮台属性
    }
    public override void Act(GameObject o)          //攻击行为：发射炮弹
    {
        audioSource.Play();
        state = State.Attack;
        GameObject bullet;
        bullet = Instantiate(bulletOfThis,transform);
        bullet.GetComponent<TowerBullet>().damage = abilityValueNow*abilityRate;
        bullet.GetComponent<TowerBullet>().targetTransform = o.transform;
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")&&!enemyList.Contains(collision.gameObject)&&!defendEnemy.Contains(collision.gameObject))   //当检测到的是敌人而且敌人列表中没有该物体时将该物体加入到敌人列表
        {
            if (collision.GetComponent<DefendEnemy>())
            {
                defendEnemy.Add(collision.gameObject);
            }
            else
            {
                enemyList.Add(collision.gameObject);
            }
        }
    }
    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && (enemyList.Contains(collision.gameObject)||defendEnemy.Contains(collision.gameObject)))  //当检测到的是敌人而且敌人列表中含有该敌人时将该敌人移除
        {
            if (enemyList.Contains(collision.gameObject))
                enemyList.Remove(collision.gameObject);
            else defendEnemy.Remove(collision.gameObject);
        }
    }
    protected virtual void Start()
    {
        nextAttackTime = Time.time + shootSpeedNow;
    }
    protected virtual void Update()                               //周期地攻击敌人
    {
        if (IsDizz())
        {
            if (state == State.Attack)
            {
                state = State.Idle;
            }
            SetAnim();
            return;
        }
        if (enemyList.Count != 0||defendEnemy.Count!=0) {
            if (Time.time > nextAttackTime)
            {
                if (defendEnemy.Count == 0)
                    Act(enemyList[0]);
                else Act(defendEnemy[0]);
                nextAttackTime = Time.time + shootSpeedNow;
            }
            else state = State.Idle;
        }
        else
        {
            state = State.Idle;
            nextAttackTime = Time.time + shootSpeedNow;
        }
        SetAnim();
    }
    protected void SetAnim()
    {
        if (state == State.Idle)
        {
            if(anim.GetBool("IsAttacking"))
                anim.SetBool("IsAttacking", false);
        }
        else
        {
            if(!anim.GetBool("IsAttacking"))
                anim.SetBool("IsAttacking", true);
        }
    }
}
