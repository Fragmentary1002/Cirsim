using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
class GatePrefabs
{
    public GameObject NULLGate;
    public GameObject NOTGate;
    public GameObject ANDGate;
    public GameObject ORGate;
}

public class GateChanger : MonoBehaviour
{
    // 单例
    public static GateChanger Instance;
    [SerializeField] GatePrefabs prefabs;
    GateType[] typeArray;
    Dictionary<GateType, int> typeIndex;
    Dictionary<GateType, GameObject> gates;

    void Awake()
    {
        Instance = this;
        initGateDictionary();
        initTypeOrder();
    }

    void initGateDictionary()
    {
        gates = new Dictionary<GateType, GameObject>();

        gates.Add(GateType.NULL, prefabs.NULLGate);
        gates.Add(GateType.NOT, prefabs.NOTGate);
        gates.Add(GateType.AND, prefabs.ANDGate);
        gates.Add(GateType.OR, prefabs.ORGate);
    }

    // 记录类型的前后顺序关系
    void initTypeOrder()
    {
        typeArray = (GateType[])Enum.GetValues(typeof(GateType));
        typeIndex = new Dictionary<GateType, int>();

        for (int i = 0; i < typeArray.Length; i++)
        {
            typeIndex.Add(typeArray[i], i);
        }
    }

    public void ChangetoNext(Transform transform, GateType currentType)
    {
        int nextIndex = (typeIndex[currentType] + 1) % typeArray.Length;
        GateType nextType = typeArray[nextIndex];
        Change(transform, nextType);
    }

    public void ChangetoPrevious(Transform transform, GateType currentType)
    {
        int previousIndex = (typeIndex[currentType] + typeArray.Length - 1) % typeArray.Length;
        GateType previousType = typeArray[previousIndex];
        Change(transform, previousType);
    }

    public void Change(Transform transform, GateType type)
    {
        Instantiate(gates[type], transform.position, transform.rotation);
        Destroy(transform.gameObject);
    }
}
