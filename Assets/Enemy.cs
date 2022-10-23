using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Attackable
{
    public string Name => name;

    private void OnMouseDown()
    {
        print(name);
        TrunManager.instance.SelctTarget(this);
    }
}
