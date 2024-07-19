using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 路径绘制类<b>单例</b>
/// <p>
/// 需要挂载拥有LineRenderer组件的游戏对象到LineSample中
/// <p>
/// 使用DrawPath(Vector3, Vector3)函数来绘制路径
/// </summary>
public class PathRenderer : MonoBehaviour
{
    static GameObject lineSample;
    static PathRenderer This;
    static float speed;
    [SerializeField] GameObject _lineSample;

    [SerializeField] float _speed = 3; // 绘制(运动)速度,推荐用3,过快会导致曲线精度损失严重

    // 单例:禁止构造
    private PathRenderer() {  }

    void Start()
    {
        // 初始化 使用赋值的方法解决静态字段无法序列化的问题
        This = this;
        speed = _speed;
        lineSample = _lineSample;
        lineSample.SetActive(false);
    }

    /// <summary>
    /// 绘制路径
    /// </summary>
    /// <param name="beginPos">起点</param>
    /// <param name="endPos">终点</param>
    public static void DrawPath(Vector3 beginPos, Vector3 endPos)
    {
        // 克隆对象
        GameObject line = Instantiate(lineSample);
        line.SetActive(true);
        // 设置起点
        line.transform.position = beginPos;
        // 调用路径绘制协程
        This.StartCoroutine(StartDraw(line, endPos));
    }

    // 计算路径点
    static IEnumerator StartDraw(GameObject line, Vector3 target)
    {
        // 初始化
        bool move = true;
        int posCounter = 0;
        LineRenderer lineRenderer = line.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0;

        // 计算与目标的距离
        float distanceToTarget = Vector3.Distance(line.transform.position, target);

        while (move)
        {
            // 添加当前坐标到曲线
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(posCounter++, line.transform.position);

            // 朝向目标

            line.transform.LookAt(target);

            // 计算弧线中的夹角

            float angle = Mathf.Min(1, Vector3.Distance(line.transform.position, target) / distanceToTarget) * 45;

            line.transform.rotation = line.transform.rotation * Quaternion.Euler(Mathf.Clamp(-angle, -42, 42), 0, 0);

            float currentDist = Vector3.Distance(line.transform.position, target);

            if (currentDist < 0.5f)

                move = false;

            line.transform.Translate(Vector3.forward * Mathf.Min(speed * Time.deltaTime, currentDist));

            yield return null;

        }
    }

}
