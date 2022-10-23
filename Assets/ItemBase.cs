using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBase : MonoBehaviour
{
    public Image icon;
    public Text iconNameText;   

    internal void Init(Sprite sprite)
    {
        // 아이콘 설정.
        icon.sprite = sprite;
        //item.name 이름 설정.
        iconNameText.text = sprite.name.Split("_")[^1];  
    }

    public void OnValueChange(bool isChecked)
    {
        print(iconNameText.text + "선택했습니다");
        TrunManager.instance.SelectItem(icon.sprite);
        // 아이템/무기/스킬 -> 사용대상 선택 후 사용했습니다. 출력.
    }
}
