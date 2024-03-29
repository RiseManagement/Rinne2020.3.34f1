﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FollowCamera : MonoBehaviour
{
    [SerializeField, Header("Player")]
    private GameObject m_playerObj;

    private void Update()
    {
        if (m_playerObj != null)
        {
            MoveCamera();
        }
    }

    /// <summary>
    /// カメラを移動する
    /// </summary>
    private void MoveCamera()
    {
        var playerPos = m_playerObj.transform.position;
        if (playerPos.y < -3f)
        {
            return;
        }
        else
        {
            transform.position = new Vector3(playerPos.x, playerPos.y, transform.position.z);
        }
    }
}
