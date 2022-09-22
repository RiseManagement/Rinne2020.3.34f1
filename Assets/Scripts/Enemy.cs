using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField, Header("スキル")]
    private Skill m_skill;

    /// <summary>
    /// プレイヤーをDestroyする
    /// </summary>
    /// <param name="player"></param>
    public abstract void PlayerKill(Player player);

    /// <summary>
    /// プレイヤーを倒す一連の処理を呼び出す
    /// </summary>
    /// <param name="player"></param>
    public abstract void ExecutePlayerKillManager(Player player);
}
