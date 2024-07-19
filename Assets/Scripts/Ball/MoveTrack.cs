using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 自动添加LineRenderer
[RequireComponent(typeof(LineRenderer))]

/// <summary>
/// 移动轨迹
/// </summary>
public class MoveTrack : MonoBehaviour
{
    LineRenderer lineRenderer;
    List<Vector3> pointList = new List<Vector3>();
    [SerializeField] int pointSize = 20;

    void Start()
    {
        InitPointList();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = pointSize;
    }

    void FixedUpdate()
    {
        UpdatePointList();
        DrawLine();
    }

    /// <summary>
    /// 初始化坐标点列表
    /// </summary>
    /// 用起始坐标填满列表
    void InitPointList()
    {
        Vector3 originPos = transform.position;
        for (int i = 0; i < pointSize; i++)
            pointList.Add(originPos);
    }
    /// <summary>
    /// 更新坐标点列表
    /// </summary>
    void UpdatePointList()
    {
        // 移除最后一个坐标点
        pointList.RemoveAt(pointSize - 1);
        // 添加当前坐标点到表头
        pointList.Insert(0, transform.position);
    }

    /// <summary>
    /// 绘制运动轨迹
    /// </summary>
    void DrawLine()
    {
        for (int i = 0; i < pointSize; i++)
            lineRenderer.SetPosition(i, pointList[i]);
    }
}
