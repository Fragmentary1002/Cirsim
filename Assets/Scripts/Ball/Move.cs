using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 小球移动
/// </summary>
public class Move : MonoBehaviour
{
    /// <summary>
    /// 默认移动目标位置
    /// </summary>
    public Transform target;

    [SerializeField] float speed = 10; // 移动速度

    private bool move = true;


    /// <summary>
    /// 使小球移动到默认目标
    /// </summary>
    public void Shoot()
    {
        Shoot(target);
    }

    /// <summary>
    /// 使小球移动到指定目标位置
    /// </summary>
    public void Shoot(Transform target)
    {
        StartCoroutine(StartShoot(target));
    }

    IEnumerator StartShoot(Transform target)

    {
        // 计算与目标的距离
        float distanceToTarget = Vector3.Distance(this.transform.position, target.position);

        while (move)
        {

            Vector3 targetPos = target.position;

            // 朝向目标

            this.transform.LookAt(targetPos);

            // 计算弧线中的夹角

            float angle = Mathf.Min(1, Vector3.Distance(this.transform.position, targetPos) / distanceToTarget) * 45;

            this.transform.rotation = this.transform.rotation * Quaternion.Euler(Mathf.Clamp(-angle, -42, 42), 0, 0);

            float currentDist = Vector3.Distance(this.transform.position, target.position);

            if (currentDist < 10e-8)

                move = false;

            this.transform.Translate(Vector3.forward * Mathf.Min(speed * Time.deltaTime, currentDist));

            yield return null;


        }
    }
}
