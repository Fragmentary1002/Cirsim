using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickRayCastHitControl : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    private GameObject[] characterGameObjects;
    private int selectedIndex = 0;
    private int length;//所有可供选择角色的个数；

    private string TAG = "ClickRayCastHitControl_";
    Ray ray;
    RaycastHit hit;
    GameObject obj;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(TAG + "点击鼠标左键");
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.gameObject.name);
                obj = hit.collider.gameObject;
                Debug.Log(TAG + "点中： name = " + obj.name + "点中： tag = " + obj.tag);
                //通过名字
                if (obj.name.Equals("NullGate(Clone)"))
                {
                    Debug.Log("点中" + obj.name);
                   
                   
                }
                //通过标签
                if (obj.tag == "CubeRed")
                {
                    Debug.Log("点中" + obj.name);
                    
                }
            }
        }
    }

}
