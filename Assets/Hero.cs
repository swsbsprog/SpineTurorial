using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    private void OnMouseDown()
    {
        print(name);
        TrunManager.instance.SetHero(this);
    }
}
