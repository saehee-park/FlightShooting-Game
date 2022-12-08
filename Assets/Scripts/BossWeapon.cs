using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType { HalfCircleFire = 0, SingleFireToCenterPosition,Attack}

public class BossWeapon : MonoBehaviour
{
    public float speed;
    public GameObject Player;

    [SerializeField]
    private GameObject projectilePrefab; // ������ �� �����Ǵ� �߻�ü ������
    
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    public void StartFiring(AttackType attackType)
    {
        // attackType �������� �̸��� ���� �ڷ�ƾ�� ����
        StartCoroutine(attackType.ToString());
    }

    public void StopFiring(AttackType attackType)
    {   // attackType �������� �̸��� ���� �ڷ�ƾ�� ����
        StopCoroutine(attackType.ToString());
    }

    private IEnumerator HalfCircleFire()
    {
        float attackRate = 1.5f;            // ���� �ֱ�
        int count = 30;                      // �߻�ü ���� ����
        float intervalAngle = -180 / count;    // �߻�ü ������ ����
        float weightAngle = 0;              // ���ߵǴ� ���� (�׻� ���� ��ġ�� �߻����� �ʵ��� ����)
        // �����·� ����ϴ� �߻�ü ���� (count ������ŭ)
        while (true)
        {
            for (int i = 0; i < count; i++)
            {   // �߻�ü ����
                GameObject clone = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

                // �߻�ü �̵� ����(����)
                float angle = weightAngle + intervalAngle * i;
                // �߻�ü �̵� ����(����)
                float x = Mathf.Cos(angle * Mathf.PI / 180.0f); // Cos(����), PI / 180�� ����
                float y = Mathf.Sin(angle * Mathf.PI / 180.0f); // Sin(����), PI / 180�� ����
                // �߻�ü �̵� ���� ����
                clone.GetComponent<Movement2D>().MoveTo(new Vector2(x, y));
            }
            // �߻�ü�� �����Ǵ� ���� ���� ������ ���� ����
            weightAngle += 1;
            // attackRate �ð���ŭ ���
            yield return new WaitForSeconds(attackRate);
        }
    }
    private IEnumerator SingleFireToCenterPosition()
    {
        Vector3 targetPosition = Vector3.zero; // ��ǥ ��ġ �߾�
        float attackRate = 0.2f;

        while (true)
        {   // �߻�ü ����
            GameObject clone = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            // �߻�ü �̵�����
            Vector3 direction = (targetPosition - clone.transform.position).normalized;

            // �߻�ü �̵� ���� ����
            clone.GetComponent<Movement2D>().MoveTo(direction);
            // attackRate �ð���ŭ ���
            yield return new WaitForSeconds(attackRate);
        }
    }
    private IEnumerator Attack()
    {
        float attackRate = 0.3f;
        while (true)
        {
            GameObject clone = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Vector3 direction = (Player.transform.position - clone.transform.position).normalized;
            float vx = direction.x * speed;
            float vy = direction.y * speed;
            //x���� �Ѿ�� �����ϱ�
            this.GetComponent<SpriteRenderer>().flipX = (vx < 0);
            clone.GetComponent<Movement2D>().MoveTo(direction);
            yield return new WaitForSeconds(attackRate);
        }
    }
}