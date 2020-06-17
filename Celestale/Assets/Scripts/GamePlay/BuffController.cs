using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum BuffEnum
{
    
}
public interface IAbilityChange
{
    float GetAbilityNow();
    void SetAbilityNow(float ability);
}
public interface IShootSpeedChange
{
    float GetShootSpeedNow();
    void SetShootSpeedNow(float shootSpeed);
}
public interface IArmorChange
{
    float GetArmorNow();
    void SetArmorNow(float armor);
}
public interface IAbilityRateChange
{
    float GetAbilityRate();
    void SetAbilityRate(float abilityRate);
}
public interface IAttackedRateChange
{
    float GetAttackedRate();
    void SetAttackedRate(float attackedRate);
}
public interface IDizziness
{
    bool IsDizz();
    void SetDizz(bool isDizz);
}
public class BuffController    
{
    public static IEnumerator AttackBuff(IAbilityChange o,float change,float time)
    {
        o.SetAbilityNow(o.GetAbilityNow() + change);
        yield return new WaitForSeconds(time);
        o.SetAbilityNow(o.GetAbilityNow() - change);
    }
    public static IEnumerator AttackRateBuff(IAbilityRateChange o,float change,float time)
    {
        o.SetAbilityRate(o.GetAbilityRate() + change);
        yield return new WaitForSeconds(time);
        o.SetAbilityRate(o.GetAbilityRate() - change);
    }
    public static IEnumerator ShootSpeedBuff(IShootSpeedChange o,float change,float time)
    {
        o.SetShootSpeedNow(o.GetShootSpeedNow() + change);
        yield return new WaitForSeconds(time);
        o.SetShootSpeedNow(o.GetShootSpeedNow() - change);
    }
    public static IEnumerator ArmorBuff(IArmorChange o,float change,float time)
    {
        o.SetArmorNow(o.GetArmorNow() + change);
        yield return new WaitForSeconds(time);
        o.SetArmorNow(o.GetArmorNow() - change);
    }
    public static IEnumerator AttackedRateBuff(IAttackedRateChange o,float change,float time)
    {
        o.SetAttackedRate(o.GetAttackedRate() + change);
        yield return new WaitForSeconds(time);
        o.SetAttackedRate(o.GetAttackedRate() - change);
    }
    public static IEnumerator BurningBuff(GameObject o,float damageOnce,float time)
    {
        if (o.GetComponent<Tower>())
        {
            var tower = o.GetComponent<Tower>();
            for(int i = 0; i < 4 * time; i++)
            {
                tower.GetDamaged(damageOnce*tower.GetAttackedRate());
                yield return new WaitForSeconds(0.25f);
            }
        }
        else
        {
            var enemy = o.GetComponent<Enemy>();
            for(int i = 0; i < 4 * time; i++)
            {
                enemy.GetDamaged(damageOnce*enemy.GetAttackedRate());
                yield return new WaitForSeconds(0.25f);
            }
        }
    }
    public static IEnumerator CantMoveBuff(IDizziness o,float time)
    {
        if (!o.IsDizz())
        {
            o.SetDizz(true);
            yield return new WaitForSeconds(time);
            o.SetDizz(false);
        }
    }
}
