using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// シーン遷移管理用クラス
/// </summary>
public class SceneTransManager
{
    /// <summary>
    /// メインゲームシーンに遷移する
    /// </summary>
    public static void TransToMainGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    /// <summary>
    /// ゲームオーバーシーンに遷移する
    /// </summary>
    public static void TransToGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    /// <summary>
    /// ステージ選択シーンに遷移する
    /// </summary>
    public static void TransToStageSelect()
    {
        SceneManager.LoadScene("StageSelect");
    }

    /// <summary>
    /// スキル継承シーンに遷移する
    /// </summary>
    public static void TransToSkill()
    {
        SceneManager.LoadScene("Skill");
    }
}
