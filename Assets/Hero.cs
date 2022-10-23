﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour, ITarget
{
    public Sprite[] weapons;
    public Sprite[] skills;
    public Sprite[] items;

    public string Name => name;

    private void OnMouseDown()
    {
        print(name);
        TrunManager.instance.SelctTarget(this);
    }
}
