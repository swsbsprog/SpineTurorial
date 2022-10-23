using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunManager : MonoBehaviour
{
    public static TrunManager instance;
    public UIBattle uIBattle;
    public Transform cursorTr;
    Hero _hero;
    void Start()=> instance = this;
    internal void SetHero(Hero hero)
    {
        _hero = hero;
        //hero 선택되었다는 알림 표시하자.
        cursorTr.gameObject.SetActive(true);
        cursorTr.position = hero.transform.position;

        //hero와 관련된 메뉴 표시하자. 
        uIBattle.SetHero(hero);
    }

    public void PassHeroTurn()
    {
        print($"{_hero}의 턴을 종료한다");
    }
}
