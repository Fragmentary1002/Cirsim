using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TestClick : MonoBehaviour
{
    private string TAG = "TestClick_";

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(TAG + "Click Cube ");

    }


}
