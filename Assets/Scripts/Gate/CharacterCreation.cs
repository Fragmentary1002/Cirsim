using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreation : MonoBehaviour
{

    public GameObject[] characterPrefabs;
    private GameObject[] characterGameObjects;
    private int selectedIndex = 0;
    private int length;//所有可供选择角色的个数；

    // Start is called before the first frame update
    void Start()
    {
        length = characterPrefabs.Length;
        characterGameObjects = new GameObject[length];
        for (int i = 0; i < length; i++)
        {
            characterGameObjects[i] = GameObject.Instantiate(characterPrefabs[i], transform.position, transform.rotation) as GameObject;
        }
        UpdateCharacterShow();
    }



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

    public void OnNextButtonClick()
    {//当我们点击了下一个按钮；
        selectedIndex++;
        selectedIndex %= length;
        UpdateCharacterShow();
    }

    public void OnPrevButtonClick()
    {//当我们点击了上一个按钮；
        selectedIndex--;
        if (selectedIndex == -1)
        {
            selectedIndex = length - 1;
        }
        UpdateCharacterShow();
    }
}