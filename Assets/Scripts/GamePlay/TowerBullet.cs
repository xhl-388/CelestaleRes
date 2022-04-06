using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// attacking tower bullet
/// </summary>
public class TowerBullet : MonoBehaviour
{
    public Transform targetTransform;           //攻击目标的位移
    [SerializeField]
    private float speed;                        //朝目标行进的速度
    [HideInInspector]
    public float damage;                        //炮弹的伤害（在被实例化时确定）
    private Vector2 transition;
    private void Start()
    {
        
    }
    private void Update()
    {
        if (targetTransform == null)
        {
            Destroy(gameObject);                //可能行进时敌人已经死亡，此时销毁该物体
        }
        else
        {
            transition = targetTransform.position - transform.position;
            transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(transition.y, transition.x)*Mathf.Rad2Deg);
            transform.Translate(transition / transition.magnitude * Time.deltaTime * speed,Space.World);
        }      //朝目标移动
    }
    private void OnTriggerEnter2D(Collider2D collision)         //碰到目标敌人时自爆
    {
        if (collision.transform == targetTransform)
        {
            collision.GetComponent<Enemy>().GetDamaged(damage);
            Destroy(gameObject);
        }
    }
}
