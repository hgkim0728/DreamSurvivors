using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    [SerializeField, Tooltip("스캔 범위")] private float scanRange;
    [SerializeField, Tooltip("스캔 대상 레이어")] private LayerMask targetLayer;

    // 스캔된 적의 배열
    private RaycastHit2D[] targets;
    // 스캔된 적 중 가장 가까운 곳에 있는 적
    private Transform nearTarget;

    private void FixedUpdate()
    {
        // 스캔 범위 내의 적들을 스캔
        targets = Physics2D.CircleCastAll(transform.position, scanRange, Vector2.zero, 0, targetLayer);
        nearTarget = GetNearestTarget();
    }

    /// <summary>
    /// 스캔된 적 캐릭터 중에 가장 가까운 적을 특정
    /// </summary>
    /// <returns>가장 가까이 있는 적의 Transform</returns>
    Transform GetNearestTarget()
    {
        Transform result = null;
        float diff = 100;

        foreach(RaycastHit2D target in targets)
        {
            Vector3 playerPos = transform.position;
            Vector3 targetPos = target.transform.position;
            float curDiff = Vector3.Distance(playerPos, targetPos);

            if(curDiff < diff)
            {
                diff = curDiff;
                result = target.transform;
            }
        }

        return result;
    }
}
