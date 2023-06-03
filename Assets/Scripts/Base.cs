using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Base : MonoBehaviour
{
    [SerializeField, Header("チュートリアルキャラ用ソケット")]
    private GameObject m_spCharaSocket;

    /// <summary>
    /// スキル入れ替えシーンに遷移する
    /// </summary>
    public void TransToSkillSwapScene()
    {
        SceneTransManager.TransToSkillSwap();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var player = collision.GetComponent<Player>();
            player.m_spChara.transform.parent = null;
            player.m_spChara.transform.position = m_spCharaSocket.transform.position;
            TutorialCharacterController.IsInteractable = true;
        }
    }
}
