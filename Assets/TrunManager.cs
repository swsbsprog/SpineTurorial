using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunManager : MonoBehaviour
{
    public static TrunManager instance;
    public UIBattle uIBattle;
    public Transform cursorTr;
    Hero selectedHero;
    Sprite selectedSprite;
    void Start()
    {
        instance = this;
        uIBattle.SetInfoText("플레이어를 선택해주세요");
    }

    public enum Mode{ SelectHero, SelectTarget}
    Mode mode = TrunManager.Mode.SelectHero;

    public void SelctTarget(ITarget target)
    {
        switch(mode)
        {
            case Mode.SelectHero: SetHero((Hero)target); break;
            case Mode.SelectTarget: SetItemTarget(target); break;
        } 
    }

    void SetItemTarget(ITarget target)
    {
        print($"{selectedHero}가 {target }대상에 {selectedSprite}을 사용한다");
        uIBattle.CloseUI();
    }

    internal void SetHero(Hero hero)
    {
        selectedHero = hero;
        //hero 선택되었다는 알림 표시하자.
        cursorTr.gameObject.SetActive(true);
        cursorTr.position = hero.transform.position;

        //hero와 관련된 메뉴 표시하자. 
        uIBattle.SetHero(hero);
    }

    internal void SelectItem(Sprite sprite)
    {
        selectedSprite = sprite;
        uIBattle.SetInfoText("대상을 선택해주세요");
        mode = Mode.SelectTarget;
    }

    public void PassHeroTurn()
    {
        print($"{selectedHero}의 턴을 종료한다");
    }
}
public interface ITarget
{
    string Name { get; }    
}