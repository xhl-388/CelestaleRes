using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkHome : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color transparent = new Color(1, 1, 1, 0);
    private Color notTransparent = new Color(1, 1, 1, 1);
    private bool less=true;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        if (less)
        {
            spriteRenderer.color = Color.Lerp(spriteRenderer.color, transparent, 20*Time.deltaTime);
            if (spriteRenderer.color == transparent)
            {
                less = false;
            }
        }
        else
        {
            spriteRenderer.color = Color.Lerp(spriteRenderer.color, notTransparent, 20*Time.deltaTime);
            if (spriteRenderer.color == notTransparent)
            {
                less = true;
            }
        }
    }
}
