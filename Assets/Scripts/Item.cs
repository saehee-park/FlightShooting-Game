using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { PowerUp = 0, Boom, HP, Ice, SpeedUp, Invincible, ScoreUp };

public class Item : MonoBehaviour
{
    [SerializeField]
    private ItemType itemType;
    private Movement2D movement2D;

    private PlayerController playerController; //플레이어 점수(Score)에 접근하기 위해 

    private void Awake()
    {
        movement2D = GetComponent<Movement2D>();

        float x = Random.Range(-1.0f, 1.0f);
        float y = Random.Range(-1.0f, 1.0f);

        movement2D.MoveTo(new Vector3(x, y, 0));

        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // ������ ȹ�� �� ȿ��
            Use(collision.gameObject);
            // ������ ������Ʈ ����
            Destroy(gameObject);
        }
    }

    public void Use(GameObject player)
    {
        switch (itemType)
        {
            case ItemType.PowerUp:
                player.GetComponent<Weapon>().AttackLevel++;
                break;
            case ItemType.Boom:
                player.GetComponent<Weapon>().BoomCount++;
                break;
            case ItemType.HP:
                player.GetComponent<PlayerHP>().CurrentHP += 10;
                break;
            case ItemType.Ice:
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (GameObject enemy in enemies)
                {
                    enemy.GetComponent<Movement2D>().Freeze();
                }
                break;
            case ItemType.SpeedUp:
                player.GetComponent<Movement2D>().moveSpeed += 1.0f;
                break;
            case ItemType.Invincible:
                player.GetComponent<PlayerHP>().StartCoroutine("Invincible");
                break;
            case ItemType.ScoreUp:
                playerController.Score += 1000;
                break;
        }
    }
}
