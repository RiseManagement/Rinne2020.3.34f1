using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaenBana : Enemy
{
    [SerializeField, Header("火の玉")]
    private GameObject m_fireBall;
    [SerializeField, Header("発射間隔")]
    private int m_shotInterval;
    [SerializeField, Header("発射方向")]
    private float m_shotDirection;

    private void Start()
    {
        InvokeRepeating("Shot", 10, m_shotInterval);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var player = collision.GetComponent<Player>();

            if (player != null)
            {
                ExecutePlayerKillManager(player);
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

    /// <summary>
    /// 火の玉を発射する
    /// </summary>
    private void Shot()
    {
        var fireBall = Instantiate(m_fireBall, transform.position, transform.rotation);
        Vector2 ballForce;
        ballForce = transform.right * m_shotDirection;
        fireBall.GetComponent<Rigidbody2D>().AddForce(ballForce);
        Destroy(fireBall.gameObject, 2);
    }
}
