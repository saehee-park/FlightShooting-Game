using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAutoDestroyer : MonoBehaviour
{
    private ParticleSystem particle;

    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
    }

    public void Update()
    {
        if( particle.isPlaying == false)
        {
            Destroy(gameObject);
        }
    }
}

/*
 * File : ParticleAutoDestoryer.cs
 * Desc
 *  : 파티클 오브젝트에 부착해서 사용
    : 파티클의 재생이 완료되면 오브젝트 삭제
 *
 */