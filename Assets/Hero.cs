using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
public class Hero : Attackable
{
    public Animator animator;
    public Sprite[] weapons;
    public Sprite[] skills;
    public Sprite[] items;

    public string Name => name;

    private void OnMouseDown()
    {
        print(name);
        TrunManager.instance.SelctTarget(this);
    }

    internal void SetAttackAnimation()
    {
        animator.SetTrigger("Attack");
    }
}

public class Attackable : MonoBehaviour
{
    public int hp = 10;
    public void SetDamage(int damge)
    {
        hp -= damge;
        print(hp);
    }
}