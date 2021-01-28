using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class DoorNumberManager : MonoBehaviour
{
    public GameObject wall;
   public void OnClick()
    {
        Debug.Log("push!!!");
        wall.transform.localPosition = new Vector3(0, 1500);
    }
}
