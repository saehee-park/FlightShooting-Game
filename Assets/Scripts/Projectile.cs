using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 발사체에 부딪힌 오브젝트의 태그가 "Enemy"
        if (collision.CompareTag("Enemy"))
        {
            // 부딪힌 오브젝트 사망처리 (적)
            Destroy(collision.gameObject);
            // 내 오브젝트 삭제 (발사체)
            Destroy(gameObject);
        }
    }
}

/*
* File: Projectile.cs
* Desc: 플레이어 캐릭터의 공격 발사체
* Functions: OnTriggerEnter2D() - 적과 충돌 처리
*/