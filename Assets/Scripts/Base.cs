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
}
