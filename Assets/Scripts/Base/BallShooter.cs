using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 小球发射器
/// </summary>
public class BallShooter : MonoBehaviour
{
    [SerializeField] GameObject blueBall;
    [SerializeField] GameObject redBall;
    [SerializeField] Transform target;

    void Start()
    {
        // 绘制路径
        PathRenderer.DrawPath(transform.position,target.position);
    }

    void Update()
    {
        ShortcutKey();
    }

    // 快捷键操作
    void ShortcutKey()
    {
        if (Input.GetButtonDown("ShootBall"))
            ShootBlueAndRedBalls();
    }

    /// <summary>
    /// 发射蓝球
    /// </summary>
    public void ShootBlueBall()
    {
        ShootBall(blueBall);
    }

    /// <summary>
    /// 发射红球
    /// </summary>
    public void ShootRedBall()
    {
        ShootBall(redBall);
    }

    /// <summary>
    /// 同时发射红球和蓝球
    /// </summary>
    public void ShootBlueAndRedBalls()
    {
        ShootRedBall();
        ShootBlueBall();
    }

    // 发射小球(通用),克隆对象并调用Shoot
    private void ShootBall(GameObject ball)
    {
        GameObject newBall = GameObject.Instantiate(ball, this.transform.position, new Quaternion(0, 0, 0, 0));
        newBall.SetActive(true);

        //若无指定target,则使用小球默认值
        if (target != null)
            newBall.GetComponent<Move>().Shoot(target);
        else
            newBall.GetComponent<Move>().Shoot();

    }
}
