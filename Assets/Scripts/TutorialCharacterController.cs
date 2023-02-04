using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCharacterController : MonoBehaviour
{
    [SerializeField, Header("Player")]
    private GameObject m_playerObj;

    private void Update()
    {
        if (m_playerObj != null)
        {
            Move();
        }
    }

    /// <summary>
    /// 移動する(プレイヤーを追従する)
    /// </summary>
    private void Move()
    {
        var playerPos = m_playerObj.transform.position;
            transform.position = new Vector3(playerPos.x + 0.45f, playerPos.y + 0.45f, transform.position.z);
    }
}
