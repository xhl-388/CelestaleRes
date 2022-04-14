using UnityEngine;
using UnityEngine.UI;
public class HPBarUI : MonoBehaviour
{
    public float HP = 1.0f;
    private float tmpHP;

    private Rect HealthBar;

    void Start()
    {
        HealthBar = new Rect(50, 50, 200, 20);
        tmpHP = HP;
    }

    void OnGUI()
    {
        HP = Mathf.Lerp(HP, tmpHP, 0.05f);
        GUI.HorizontalScrollbar(HealthBar, 0.0f, HP, 0.0f, 1.0f);
    }
    public void SetHP(int flag, float damage)
    {
        Debug.Log(tmpHP);
        if (flag == 1)
        {
            tmpHP += damage;
        }
        else if (flag == 0)
        {
            tmpHP -= damage;
        }
        else if(flag==2)
        {
            tmpHP = damage;
        }
    }
    public float GetHP()
    {
        return HP;
    }
}