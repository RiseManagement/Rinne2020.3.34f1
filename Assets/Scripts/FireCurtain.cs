using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCurtain : Gimmick
{
    [SerializeField, Header("最大持続時間")]
    private float m_maxDuration;
    // 現在の持続時間
    private float m_currentDuration;
    private SpriteRenderer m_spriteRenderer;
    private BoxCollider2D m_coll;

    private void Start()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_coll = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        m_currentDuration += Time.deltaTime;
        // 持続時間が最大になった、かつ画像が表示されていた場合
        if (m_currentDuration >= m_maxDuration && m_spriteRenderer.enabled)
        {
            HideFireCurtain();
        }
        // 持続時間が最大になった、かつ画像が表示されていない場合
        else if (m_currentDuration >= m_maxDuration && !m_spriteRenderer.enabled)
        {
            ShowFireCurtain();
        }
    }

    /// <summary>
    /// 火のカーテンを表示する
    /// </summary>
    private void ShowFireCurtain()
    {
        m_coll.enabled = true;
        m_spriteRenderer.enabled = true;
        m_currentDuration = 0f;
    }

    /// <summary>
    /// 火のカーテンを非表示にする
    /// </summary>
    private void HideFireCurtain()
    {
        m_coll.enabled = false;
        m_spriteRenderer.enabled = false;
        m_currentDuration = 0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var player = collision.GetComponent<Player>();

            // playerがnullじゃない、かつ焼死耐性スキルが継承されていなければ実行
            if (player != null)
            {
                if (player.EnduranceCount == 0)
                {
                    ExecutePlayerKillManager(player);
                }
                else
                {
                    player.EnduranceCount -= 1;
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
