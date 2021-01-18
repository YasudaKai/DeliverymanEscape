using System.Collections;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using UnityEngine;

public class LockerManager : MonoBehaviour
{
    public GameObject wall;
    public GameObject[] wallButtons;
    public WallManager wallManager;
    public const int left = 0;
    public const int right = 1;
    public const int back = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

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
        var wPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var hit = Physics2D.Raycast(wPos, Vector2.zero);
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

    
}
