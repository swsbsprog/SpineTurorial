using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunManager : MonoBehaviour
{
    public static TrunManager instance;
    public Transform cursorTr;
    Hero _hero;


    public ItemBase itembase;
    public Transform weaponParent;
    public Transform skillParent;
    public Transform itemParent;
    void Start()
    {
        instance = this;

    }

    internal void SetHero(Hero hero)
    {
        _hero = hero;
        //hero 선택되었다는 알림 표시하자.
        cursorTr.gameObject.SetActive(true);
        cursorTr.position = hero.transform.position;

        //hero와 관련된 메뉴 표시하자. 
        UpdateList(weaponParent, hero.weapons);
        UpdateList(skillParent, hero.skills);
        UpdateList(itemParent, hero.items);
    }

    private void UpdateList(Transform parent, Sprite[] visibleItems)
    {
        var toDelete = parent.GetComponentsInChildren<ItemBase>();
        foreach (var item in toDelete)
            Destroy(item.gameObject);

        // visibleItems에 있는것을 parent에 생성하자.
        itembase.gameObject.SetActive(true);
        foreach (Sprite item in visibleItems)
        {
            var newItem = Instantiate(itembase, parent);
            newItem.Init(item);
        }
        itembase.gameObject.SetActive(false);
    }

    public void PassHeroTurn()
    {
        print($"{_hero}의 턴을 종료한다");
    }
}
