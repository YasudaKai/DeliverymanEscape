using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WallManager : MonoBehaviour
{
    public GameObject wall;
    public GameObject[] wallButtons;
    public const int left = 0;
    public const int right = 1;
    public const int back = 2;

    public enum WALL
    {
        Front,
        Right,
        Back,
        Left,
    }
    WALL currentWall = WALL.Front;

    //ロッカーの以外にも画面をアップする
    //場合があるかもしれないから、
    //transform.localPositionを
    //enum型で場合わけしておいた方がいい？

    public enum ZOOM
    {
        
    }


    public void OnRightButton()
    {
        currentWall++;
        if(currentWall > WALL.Left)
        {
            currentWall = WALL.Front;
        }
        ChangeWall();
    }

    public void OnLeftButton()
    {
        currentWall--;
        if(currentWall < WALL.Front)
        {
            currentWall = WALL.Left;
        }
        ChangeWall();
    }

    //Lockerのダイヤル画面でBackボタンを押したら、
    //元のLockerの画面に戻したい。
    /// <summary>
    /// いつ：backボタンを押したとき
    /// 処理：ロッカーの画面に戻したい。
    /// </summary>
    public void OnBackButton()
    {
        wallButtons[left].SetActive(true);
        wallButtons[right].SetActive(true);
        wallButtons[back].SetActive(false);
        wall.transform.localPosition = new Vector3(-1000, 0);
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
