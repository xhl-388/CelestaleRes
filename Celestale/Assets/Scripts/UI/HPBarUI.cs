using UnityEngine;
using UnityEngine.UI;
public class HPBarUI : MonoBehaviour
{
    public float HP = 1.0f;
    public float MaxHP = 1.0f;
    public float x=50.0f;
    public float y=50.0f;
    private float tmpHP;
    private Color curColor=Color.green;

    private Rect HealthBar;

    void Start()
    {
        HealthBar = new Rect(x, y, 150, 10);
        HP = MaxHP;
        tmpHP = HP;
        //Debug.Log(tmpHP+" "+HP+" "+MaxHP);
    }

    void OnGUI()
    {
        HP = Mathf.Lerp(HP, tmpHP, 0.05f);
        GUI.color = curColor;
        GUI.HorizontalScrollbar(HealthBar, 0.0f, HP, 0.0f, MaxHP, GUI.skin.GetStyle("HorizontalScrollbar"));
        
    }
    public void SetHP(int flag, float damage)
    {        
        if (flag == 1)
        {
            tmpHP += damage;
            //Debug.Log(tmpHP);
        }
        else if (flag == 0)
        {
            tmpHP -= damage;
            //Debug.Log(tmpHP);
        }
        else if(flag==2)
        {
            tmpHP = damage;
            //Debug.Log(tmpHP);
        }
        if (tmpHP>MaxHP/2)
        {
            curColor = Color.green;
        }
        else if(tmpHP<MaxHP/4)
        {
            curColor = Color.red;
        }
        else
        {
            curColor = Color.yellow;
        }
    }
    public float GetHP()
    {
        return HP;
    }
}