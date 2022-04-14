using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRangeMessager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        transform.parent.SendMessage("OnTriggerEnter2D",other,SendMessageOptions.DontRequireReceiver);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        transform.parent.SendMessage("OnTriggerExit2D",other,SendMessageOptions.DontRequireReceiver);
    }
}
