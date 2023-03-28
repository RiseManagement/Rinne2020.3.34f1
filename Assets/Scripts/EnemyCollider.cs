using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    [SerializeField, Header("エネミーコントローラー")]
    private EnemyController m_enemyController;
    [SerializeField, Header("アニメーター")]
    private Animator m_animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            m_enemyController.enabled = true;
            m_animator.enabled = true;
        }
    }
}
