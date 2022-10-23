using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
    public void SelctTarget(Attackable target)
    {
        switch(mode)
        {
            case Mode.SelectHero: SetHero((Hero)target); break;
            case Mode.SelectTarget: SetItemTarget(target); break;
        } 
    }
    internal void SelectItem(Sprite sprite)
    {
        selectedSprite = sprite;
        uIBattle.SetInfoText("대상을 선택해주세요");
        mode = Mode.SelectTarget;
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
    public void PassHeroTurn()
    {
        print($"{selectedHero}의 턴을 종료한다");
    }
    void SetItemTarget(Attackable target)
    {
        print($"{selectedHero}가 {target }대상에 {selectedSprite}을 사용한다");
        uIBattle.CloseUI();
        ItemType itemType = GetItemType(selectedSprite);
        switch(itemType)
        {
            case ItemType.Weapon://selectedSprite 무기 였다면
                //target으로 이동 해서 hp 감소 시키자.
                Vector3 dir = target.transform.position - selectedHero.transform.position;
                dir.Normalize();
                //dir = dir.normalized;
                Vector3 destination = target.transform.position - dir;

                float destMovTime = 0.3f;
                selectedHero.transform.DOMove(destination, destMovTime)
                    .OnComplete(() => {
                        // 공격 모션 하자.
                        selectedHero.SetAttackAnimation();
                        target.SetDamage(1);
                    });

                // 복귀
                selectedHero.transform.DOMove(selectedHero.transform.position, 0.1f)
                    .SetDelay(destMovTime + 1.4f);

                break;
        }
    }

    private ItemType GetItemType(Sprite selectedSprite)
    {
        if (selectedSprite.name.StartsWith("A_"))
            return ItemType.Item;
        else if (selectedSprite.name.StartsWith("I_"))
            return ItemType.Item;
        else if (selectedSprite.name.StartsWith("W_"))
            return ItemType.Weapon;
        else if (selectedSprite.name.StartsWith("S_"))
            return ItemType.Skill;
        return ItemType.Item;
    }

    public enum ItemType
    {
        Weapon, Skill, Item
    }
}