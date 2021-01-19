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
    public const int left = 0;
    public const int right = 1;
    public const int back = 2;

    //ロッカーの鍵に当たり判定をつけて
    //いつ：ロッカー鍵付近をクリックした時
    //処理：アップになるようにする。

    /// ロッカーの鍵がアップになったときに左右の方向キー
    /// が邪魔なので消したい。
    /// 代わりに戻るボタンを追加したい。
    /// 
    /// いつ：ロッカーがアップになった時
    /// 処理：左右の方向きーを削除。バックボタンを追加。
    public void OnLockerButton()
    {
        Vector3 wPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //マウスをクリックしたワールド座標をを取得
        
        RaycastHit2D hit = Physics2D.Raycast(wPos, Vector2.zero);
        //wPosが２D空間上のRayの原点。
        //そこからどの方向ににRayをあてるか

        if (hit)
        {　　　
            if (hit.collider.gameObject.name == this.name)
            {
                Debug.Log("Lockerのダイヤルに当たった。");
                //ロッカーをアップにしたとき、
                //WallManagerのZOOM型の値をLockerDialにしたい。

                wall.transform.localPosition = new Vector3(-1000, 1500);
                wallButtons[left].SetActive(false);
                wallButtons[right].SetActive(false);
                wallButtons[back].SetActive(true);
            }
        }
    }

    //DialButtonをプッシュしたら、画像を変更したい
    //いつ：DialButtonをプッシュした時
    // →どのボタンを押したのか引数で区別する ok
   
    //処理：画像を変更したい
    //→現在の画像を取得
    //→変更後の画像を取得
    //→マーク変数で現在の画像を管理
    //→ボタンが押されるたびにマーク変数を＋＋していき
    //その値に応じてSpriteで画像を変更する


    public enum Dial
    {
        Boar,//イノシシ
        Mouse,
        Cat,
        Dog,
    }

    Dial currentDial = Dial.Dog;
    public void OnDialButton(int index)
    {
        Debug.Log(index + "dialPush!!");
        currentDial++;
        if(currentDial > Dial.Dog)
        {
            currentDial = Dial.Boar;
        }

        ChangeDialButton(index);
    }

    void ChangeDialButton(int index)
    {
        dials[index].sprite = GetDialImage();
    }

    //マーク変数の値によって
    //返す画像を決める。
    Sprite GetDialImage()
    {
        switch (currentDial)
        {
            case Dial.Boar:
                return changeDials[0];
                break;
            case Dial.Mouse:
                return changeDials[1];
                break;
            case Dial.Cat:
                return changeDials[2];
                break;
            case Dial.Dog:
                return changeDials[3];
                break;
        }
        return null;
    }



    
}
