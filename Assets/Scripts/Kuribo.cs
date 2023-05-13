using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kuribo : Enemy
{
    private SpriteRenderer m_spriteRenderer;
    private Animator m_animator;
    [SerializeField, Header("ダメージ画像")]
    private Sprite m_damageImage;

    private void Start()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var player = collision.GetComponent<Player>();

            if (player != null && !player.IsDefeatTheKuriboEnabled)
            {
                ExecutePlayerKillManager(player);
            }
            else if (player != null && player.IsDefeatTheKuriboEnabled)
            {
                if (player.gameObject.transform.position.y > transform.position.y + 0.4f)
                {
                    m_animator.enabled = false;
                    m_spriteRenderer.sprite = m_damageImage;
                    Destroy(gameObject, 0.5f);
                }
                else
                {
                    ExecutePlayerKillManager(player);
                }
            }
        }
    }

    public override void ExecutePlayerKillManager(Player player)
    {
        var playerKillManager = new PlayerKillManager(player);
        playerKillManager.PlayerKill(this, m_skill);
    }

    public override void PlayerKill(Player player)
    {
        Destroy(player.gameObject);
    }
}
