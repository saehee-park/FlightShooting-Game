using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 0.0f;
    [SerializeField]
    private Vector3 moveDirection = Vector3.zero;
    [SerializeField]
    private long freezeTime;
    [SerializeField]
    private long currentTime;
    public long UnixTimeNow()
    {
        var timeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
        return (long)timeSpan.TotalSeconds;
    }

    private void Update()
    {
        currentTime = UnixTimeNow();
        if (currentTime - freezeTime < 1)
        {
            return;
        }
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    public void MoveTo(Vector3 direction)
    {
        moveDirection = direction;
    }

    public void Freeze()
    {
        freezeTime = UnixTimeNow();
        EnemySpawner enemySpawner = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<EnemySpawner>();
        enemySpawner.SetPause(freezeTime);
    }
}

/*
* File: Movement2D.cs
* Desc: 이동 가능한 모든 오브젝트에게 부착
* Functions: MoveTo() - 외부에서 호출해 이동 방향 설정 
*/