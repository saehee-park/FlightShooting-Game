using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 적에게 부딪힌 오브젝트의 태그가 "Player"
        if (collision.CompareTag("Player"))
        {
            // 적 사망
            Destroy(gameObject);
        }
    }
}

/*
* File: Enemy.cs
* Desc: 적 캐릭터 오브젝트에 부착해서 사용
*/
