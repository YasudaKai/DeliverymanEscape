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

    public enum Type 
    {
        Key,
        Leaf,
    }

    public Type type;

    public void OnClick()
    {
        Debug.Log(type + "を取得");
        gameObject.SetActive(false);
        itemBox.DisplayBoxItem(type);
    }

    //画面上のアイテムを取得したときに
    //アイテムボックスのアイテムを表示したい。
    //アイテムのtypeの値によって、
    //表示させるアイテムを決めて表示。

    

    
}
