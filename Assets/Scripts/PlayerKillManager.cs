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

    #region Enemy
    /// <summary>
    /// エネミーがプレイヤーを倒す一連の処理
    /// </summary>
    /// <param name="enemy"></param>
    /// <param name="skill"></param>
    public void PlayerKill(Enemy enemy, Skill skill)
    {
        if (Player.Life != 0)
        {
            Debug.Log(Player.Life);
            Player.Life--;
            #region 継承スキル数が上限に達していない&未継承スキルを獲得した場合
            if (Player.m_inheritedSkills.Count < Player.InheritanceLimit
                && !Player.m_inheritedSkills.Contains(skill))
            {
                var inheritance = new Inheritance(skill);
                // スキル継承クラスのスキルを継承させる関数呼び出し
                inheritance.InheritSkill();
                // プレイヤーをDestroyする関数呼び出し
                enemy.PlayerKill(m_player);
                SceneTransManager.TransToSkill();
            }
            #endregion

            #region 継承スキル数が上限に達していない&既に継承しているスキルを獲得した場合
            else if (Player.m_inheritedSkills.Count < Player.InheritanceLimit
                && Player.m_inheritedSkills.Contains(skill))
            {
                SceneTransManager.TransToMainGameLatest();
            }
            #endregion

            #region 継承スキル数が上限に達した&未継承スキルを獲得した場合
            else if (Player.m_inheritedSkills.Count == Player.InheritanceLimit
                && !Player.m_inheritedSkills.Contains(skill))
            {
                Player.m_swapSkills.Add(skill);
                enemy.PlayerKill(m_player);
                SceneTransManager.TransToSkillSwap();
            }
            #endregion
        }
        else
        {
            enemy.PlayerKill(m_player);
            SceneTransManager.TransToGameOver();
        }
    }
    #endregion

    #region Gimmick
    /// <summary>
    /// ギミックがプレイヤーを倒す一連の処理
    /// </summary>
    /// <param name="player"></param>
    /// <param name="causeOfDeathType"></param>
    public void PlayerKill(Gimmick gimmick, Skill skill)
    {
        if (Player.Life != 0)
        {
            Player.Life--;
            #region 継承スキル数が上限に達していない&未継承スキルを獲得した場合
            if (Player.m_inheritedSkills.Count < Player.InheritanceLimit
                && !Player.m_inheritedSkills.Contains(skill))
            {
                var inheritance = new Inheritance(skill);
                // スキル継承クラスのスキルを継承させる関数呼び出し
                inheritance.InheritSkill();
                // プレイヤーをDestroyする関数呼び出し
                gimmick.PlayerKill(m_player);
                SceneTransManager.TransToSkill();
            }
            #endregion

            #region 継承スキル数が上限に達していない&既に継承しているスキルを獲得した場合
            else if (Player.m_inheritedSkills.Count < Player.InheritanceLimit
                && Player.m_inheritedSkills.Contains(skill))
            {
                SceneTransManager.TransToMainGameLatest();
            }
            #endregion

            #region 継承スキル数が上限に達した&未継承スキルを獲得した場合
            else if (Player.m_inheritedSkills.Count == Player.InheritanceLimit
                && !Player.m_inheritedSkills.Contains(skill))
            {
                Player.m_swapSkills.Add(skill);
                gimmick.PlayerKill(m_player);
                SceneTransManager.TransToSkillSwap();
            }
            #endregion
        }
        else
        {
            gimmick.PlayerKill(m_player);
            SceneTransManager.TransToGameOver();
        }
    }
    #endregion
}
