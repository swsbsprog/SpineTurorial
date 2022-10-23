using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ITarget
{
    public string Name => name;

    private void OnMouseDown()
    {
        print(name);
        TrunManager.instance.SelctTarget(this);
    }
}
