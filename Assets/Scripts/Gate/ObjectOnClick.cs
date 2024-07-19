using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectOnClick : MonoBehaviour, IPointerDownHandler
{

    public GameObject[] characterPrefabs;
    private GameObject[] characterGameObjects;
    private int selectedIndex = 0;
    private int length;//所有可供选择角色的个数；
    //当鼠标点击，即鼠标按下与松开均在该物体上时，触发以下函数
    public void OnPointerClick(PointerEventData eventData)
    {
        //你要触发的代码
        void UpdateCharacterShow()
        {//更新所有角色；
            characterGameObjects[selectedIndex].SetActive(true);
            for (int i = 0; i < length; i++)
            {
                if (i != selectedIndex)
                {
                    characterGameObjects[i].SetActive(false);//把为选择角色设置为隐藏；
                }
            }
        }

    }

    //当检测到鼠标在该物体上有“按下”操作时，触发以下函数
    public void OnPointerDown(PointerEventData eventData)
    {
        //你要触发的代码
    }
}
