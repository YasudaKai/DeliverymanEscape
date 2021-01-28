using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    const string SAVE_KEY = "SAVE_DATA";
    SaveData saveData = new SaveData();

    public enum Flag
    {
        OpenLocker,
        Max,
    }

    //★セーブ機能の実装
    //JsonUtility →　PlayerPrefs
    //JsonUtility
    //・クラス(セーブデータ）をJson(文字列)に変換できる
    //PlayerPrefs
    //・数字や文字列を保存できるもの

    //static化してどこからでも参照できるようにする
    public static SaveManager instance;
    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        //Save();
        Load();
    }

    //Save関数
    void Save()
    {
        string json = JsonUtility.ToJson(saveData);
        PlayerPrefs.SetString(SAVE_KEY, json);
        //Debug.Log(json);
    }

    //Load関数
    void Load()
    {
        if (PlayerPrefs.HasKey(SAVE_KEY) == true)
        {
            //保存データのjsonを取得する
            string json = PlayerPrefs.GetString(SAVE_KEY);
            //Debug.Log(json);
            //jsonからセーブデータを復元する
            saveData = JsonUtility.FromJson<SaveData>(json);
        }
        else
        {
            saveData = new SaveData();
        }
    }

    //アイテムを取得したことをセーブする関数
    public void SetItemFlag(Item.Type flag, bool value)
    {
        saveData.getItemFlag[(int)flag] = value;
        Save();
    }

    public bool GetItemFlag(Item.Type flag)
    {
        return saveData.getItemFlag[(int)flag];
    }

    public void SetFlag(Flag flag, bool value)
    {
        saveData.flags[(int)flag] = value;
        Save();
    }

    public bool GetFlag(Flag flag)
    {
        return saveData.flags[(int)flag];
    }
}

public class SaveData
{
    //bool型の初期値はfalseになる
    //public bool[] flags = new bool[3];
    public bool[] getItemFlag = new bool[(int)Item.Type.Max];
    public bool[] flags = new bool[(int)SaveManager.Flag.Max];
}
