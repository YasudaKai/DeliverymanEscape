using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Junary 15th, 2021
///★特定のボタンを押したとき
///Panelを動かしたい。
///　→Panelのtransformを取得する
///　→transform.positionで位置を変更する。
///★Panelを左右に動かしたい。　
///　→現在の位置をマーク変数で管理。（列挙型で）
///　→マーク変数の値によってどこのWallの位置にするか決める
///　

///Junuary 16th, 2021
///★Gitでのバージョン管理
///→GitDeskTopとコマンドプロンプトでGitを操作して管理するの
///　どちらがいいのか？
///→調べてもどちらがいいとかはでなかった。
///　楽なGitDeskTopを使うことにする。
///
///★背景とアイテムボックスの画像の配置。
///
///★アイテムボックスの実装
///アイテムを取得するとアイテムがアイテムボックスに移動する。
///アイテムを取得する。
///→アイテムをクリックできるようにする。
///→SetActiveで削除する。

public class WallManager : MonoBehaviour
{
    public GameObject wall;

    public enum WALL
    {
        Front,
        Right,
        Back,
        Left,
    }

    WALL currentWall = WALL.Front;

   
    public void OnRightButton()
    {
        currentWall++;
        if(currentWall > WALL.Left)
        {
            currentWall = WALL.Front;
        }
        ChangeWall();
        Debug.Log("push");
    }

    public void OnLeftButton()
    {
        currentWall--;
        if(currentWall < WALL.Front)
        {
            currentWall = WALL.Left;
        }
        ChangeWall();
        Debug.Log("leftPush");
    }

    void ChangeWall()
    {
        switch (currentWall)
        {
            case WALL.Front:
                wall.transform.localPosition = new Vector3(0, 0);
                break;
            case WALL.Right:
                wall.transform.localPosition = new Vector3(-1000, 0);
                break;
            case WALL.Back:
                wall.transform.localPosition = new Vector3(-2000, 0);
                break;
            case WALL.Left:
                wall.transform.localPosition = new Vector3(-3000, 0);
                break;
        }
    }
}
