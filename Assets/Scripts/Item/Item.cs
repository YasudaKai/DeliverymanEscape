using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    //アイテムを識別しやすくするため、
    //列挙型でアイテムを管理してみる。

    //アイテムボックスに表示する
    //アイテムオブジェクトの配列を作って
    //DisPlayBoxItem関数で使用

    public ItemBox itemBox;
    bool hasItem;

    public enum Type 
    {
        Key,
        Leaf,
        Max
    }

    public Type type;

    private void Start()
    {
        //既に取得しているなら非表示
        hasItem = SaveManager.instance.GetItemFlag(type);
        if(hasItem == true)
        {
            gameObject.SetActive(false);
            //アイテムボックスに表示
            itemBox.DisplayBoxItem(type);
        }
    }

    public void OnClick()
    {
        Debug.Log(type + "を取得");
        gameObject.SetActive(false);
        itemBox.DisplayBoxItem(type);
        SaveManager.instance.SetItemFlag(type, true);
    }
}
