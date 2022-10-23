using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public Sprite[] weapons;
    public Sprite[] skills;
    public Sprite[] items;
    private void OnMouseDown()
    {
        print(name);
        TrunManager.instance.SetHero(this);
    }
}
