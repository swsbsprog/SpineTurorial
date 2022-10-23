using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBattle : MonoBehaviour
{
    public Text infoText;
    public GameObject menuUI;
    public ItemBase itembase;
    public Transform weaponParent;
    public Transform skillParent;
    public Transform itemParent;
    void Start() => menuUI.SetActive(false);
    public void SetInfoText(string infoStr)
    {
        infoText.text = infoStr;
    }
    internal void SetHero(Hero hero)
    {
        //hero와 관련된 메뉴 표시하자. 
        menuUI.SetActive(true);
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

    internal void CloseUI()
    {
        gameObject.SetActive(false);
        //ClearData();
    }
}
