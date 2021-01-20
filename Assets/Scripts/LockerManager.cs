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
    public bool isClear = false;

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
        Max
    }

    //マーク変数をボタンそれぞれ分用意する。
    Dial leftDialMark = Dial.Dog;
    Dial middleDialMark = Dial.Dog;
    Dial rightDialMark = Dial.Dog;

    public void OnDialButton(int position)
    {
        //currentDial++; ここでマーク変数を変更するのではなく、
        //新たにマーク変数を変更用の関数を作る。
        ChangeDialMark(position);
        ShowDialImage(position);
        CheckDialButton();
    }

    void ChangeDialMark(int position)
    {
        const int left = 0;
        const int middle = 1;
        const int right = 2;

        //マーク変数の値を変更する
        switch (position)
        {
            case left:
                leftDialMark++;
                if (leftDialMark >= Dial.Max)
                {
                    leftDialMark = Dial.Boar;
                }
                break;
            case middle:
                middleDialMark++;
                if (middleDialMark >= Dial.Max)
                {
                    middleDialMark = Dial.Boar;
                }
                break;
            case right:
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
        const int left = 0;
        const int middle = 1;
        const int right = 2;

        //マーク変数の値を変更する
        //ポイントはマーク変数をボタン分、用意することだった。
        //そうすればボタン事の画像を取得できる。
        switch (position)
        {
            case left:
                dials[left].sprite = GetDialImage(leftDialMark);
                break;
            case middle:
                dials[middle].sprite = GetDialImage(middleDialMark);
                break;
            case right:
                dials[right].sprite = GetDialImage(rightDialMark);
                break;
        }
    }

    Sprite GetDialImage(Dial currentDial)
    {
        int index = (int)currentDial;
        return changeDials[index];
        /*
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
        }*/
        //return null;
    }

    //現在の画像が変更後、正解の画像かどうかチェック
    //
    void CheckDialButton()
    {
        if(dials[0].sprite == changeDials[0] &&
           dials[1].sprite == changeDials[1] &&
           dials[2].sprite == changeDials[2])
        {
            Debug.Log("DialClear!!!");
            isClear = true;
        }
    }

    //マーク変数の値によって
    //返す画像を決める。
    
    //Dialの画像の順番が正解か判定したい。
    //→並び順の正解を作っておいて、
    //現在の画像と照らし合わせ、合っているなら、
    //条件クリアにする。

    //現在の画像の順番が、
    //左から、ねずみ、ねこ、いのしし
    //この順番の最初と最後は干支の順位
    //ねこは干支レースに参加できなかった動物


}
