using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーを倒してスキルを継承させるまでの処理を管理するクラス
/// </summary>
public class PlayerKillManager
{
    // プレイヤー
    private Player m_player;

    public PlayerKillManager(Player player)
    {
        m_player = player;
    }

    /// <summary>
    /// エネミーがプレイヤーを倒す一連の処理
    /// </summary>
    /// <param name="enemy"></param>
    /// <param name="skill"></param>
    public void PlayerKill(Enemy enemy, Skill skill)
    {
        if (Player.Remain != 0)
        {
            Player.Remain--;
            var inheritance = new Inheritance(skill);
            // スキル継承クラスのスキルを継承させる関数呼び出し
            inheritance.InheritSkill();
            // プレイヤーをDestroyする関数呼び出し
            enemy.PlayerKill(m_player);
            SceneTransManager.TransToSkill();
        }
        else
        {
            enemy.PlayerKill(m_player);
            SceneTransManager.TransToGameOver();
        }
    }

    /// <summary>
    /// ギミックがプレイヤーを倒す一連の処理
    /// </summary>
    /// <param name="player"></param>
    /// <param name="causeOfDeathType"></param>
    public void PlayerKill(Gimmick gimmick, Skill skill)
    {
        if (Player.Remain != 0)
        {
            Player.Remain--;
            var inheritance = new Inheritance(skill);
            // スキル継承クラスのスキルを継承させる関数呼び出し
            inheritance.InheritSkill();
            // プレイヤーをDestroyする関数呼び出し
            gimmick.PlayerKill(m_player);
            SceneTransManager.TransToSkill();
        }
        else
        {
            gimmick.PlayerKill(m_player);
            SceneTransManager.TransToGameOver();
        }
    }
}
