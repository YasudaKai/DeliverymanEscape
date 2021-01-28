using System.Collections;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using UnityEngine;
using UnityEngine.UI;


public class LockerManager : MonoBehaviour
{
    public GameObject wall;
    public GameObject[] wallButtons;
    public Image[] dials;//現在の画像
    public Sprite[] changeDials;//変更後の画像
    public GameObject locker;
    public GameObject openLocker;
    public const int left = 0;
    public const int right = 1;
    public const int back = 2;
    public bool isClear = false;

    private void Start()
    {
        bool openFlag = SaveManager.instance.GetFlag(SaveManager.Flag.OpenLocker);
        if(openFlag == true)
        {
            locker.SetActive(false);
            openLocker.SetActive(true);
        }
        else
        {
            locker.SetActive(true);
            openLocker.SetActive(false);
        }
    }

    public void OnLockerButton()
    {
        Vector3 wPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //マウスをクリックしたワールド座標をを取得
        
        RaycastHit2D hit = Physics2D.Raycast(wPos, Vector2.zero);
        //wPosが２D空間上のRayの原点。
        //そこからどの方向ににRayをあてるか

        if (hit)
        {
            if (hit.collider.gameObject == locker)
            {
                wall.transform.localPosition = new Vector3(-1000, 1500);
                wallButtons[left].SetActive(false);
                wallButtons[right].SetActive(false);
                wallButtons[back].SetActive(true);
            }
        }
    }

    public enum Dial
    {
        Boar,//イノシシ
        Mouse,
        Cat,
        Dog,
        Max
    }

    //マーク変数をボタンそれぞれ分用意する。
    Dial leftDialMark = Dial.Dog;
    Dial middleDialMark = Dial.Dog;
    Dial rightDialMark = Dial.Dog;

    public void OnDialButton(int position)
    {
        //currentDial++; ここでマーク変数を変更するのではなく、
        //新たにマーク変数の変更用の関数を作る。
        ChangeDialMark(position);
        ShowDialImage(position);
        CheckDialButton();
    }

    void ChangeDialMark(int position)
    {
        //マーク変数の値を変更する
        switch (position)
        {
            case 0:
                leftDialMark++;
                if (leftDialMark >= Dial.Max)
                {
                    leftDialMark = Dial.Boar;
                }
                break;
            case 1:
                middleDialMark++;
                if (middleDialMark >= Dial.Max)
                {
                    middleDialMark = Dial.Boar;
                }
                break;
            case 2:
                rightDialMark++;
                if (rightDialMark >= Dial.Max)
                {
                    rightDialMark = Dial.Boar;
                }
                break;
        }
    }

    void ShowDialImage(int position)
    {
        //マーク変数の値を変更する
        //ポイントはマーク変数をボタン分、用意することだった。
        //そうすればボタンごとの画像を取得できる。
        switch (position)
        {
            case 0:
                dials[0].sprite = GetDialImage(leftDialMark);
                break;
            case 1:
                dials[1].sprite = GetDialImage(middleDialMark);
                break;
            case 2:
                dials[2].sprite = GetDialImage(rightDialMark);
                break;
        }
    }

    Sprite GetDialImage(Dial currentDial)
    {
        int index = (int)currentDial;
        return changeDials[index];
    }

    //現在の画像が変更後、正解の画像かどうかチェック
    //正解の場合、ロッカーのオブジェクトを消し、
    //開いた状態のオブジェクトを表示する。
    void CheckDialButton()
    {
        if(dials[0].sprite == changeDials[0] &&
           dials[1].sprite == changeDials[1] &&
           dials[2].sprite == changeDials[2])
        {
            isClear = true;
            locker.SetActive(false);
            openLocker.SetActive(true);
            //ロッカーが開いたらフラグをセットしてセーブ
            SaveManager.instance.SetFlag(SaveManager.Flag.OpenLocker, true);
        }
    }
}
