using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUnitHealthBar : MonoBehaviour
{
    private Transform bar;

    void Start()
    {
        bar = transform.Find("Bar");
    }

    public void setHealthBar(float normalizedValue)
    {
        bar.localScale = new Vector3(normalizedValue, 1f);
        if (normalizedValue < 0.3f)
        {
            bar.Find("BarSprite").GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            bar.Find("BarSprite").GetComponent<SpriteRenderer>().color = Color.green;
        }
    }
}