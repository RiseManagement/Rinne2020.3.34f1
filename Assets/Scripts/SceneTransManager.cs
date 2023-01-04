using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// シーン遷移管理用クラス
/// </summary>
public class SceneTransManager
{
    // 直前のメインゲームシーン名
    private static string m_latestSceneName;

    public static string LatestSceneName { get { return m_latestSceneName; } set { m_latestSceneName = value; } }

    /// <summary>
    /// タイトルシーンに遷移する
    /// </summary>
    public static void TransToTitle()
    {
        SceneManager.LoadScene("Title");
    }

    /// <summary>
    /// メインゲームシーンに遷移する
    /// </summary>
    public static void TransToStage1()
    {
        SceneManager.LoadScene("Stage1");
    }

    public static void TransToStage(int no)
    {
        SceneManager.LoadScene("Stage" + no.ToString());
    }

    /// <summary>
    /// ゲームオーバーシーンに遷移する
    /// </summary>
    public static void TransToGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    /// <summary>
    /// ステージクリアシーンに遷移する
    /// </summary>
    public static void TransToStageClear()
    {
        SceneManager.LoadScene("GameClear");
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

    /// <summary>
    /// 直前のメインゲームシーンに遷移する
    /// </summary>
    public static void TransToMainGameLatest()
    {
        SceneManager.LoadScene(LatestSceneName);
    }
}
