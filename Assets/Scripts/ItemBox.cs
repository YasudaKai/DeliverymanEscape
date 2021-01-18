using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBox : MonoBehaviour
{
    public GameObject[] boxItems;

   
   
    public void DisplayBoxItem(Item.Type type)
    {
        int index = (int)type;
        boxItems[index].SetActive(true);
    }
}
