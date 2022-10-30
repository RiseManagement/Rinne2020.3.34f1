using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    private void Start()
    {
        // 継承中のスキルを全削除
        Player.m_inheritedSkills.Clear();
        // 残機をリセット
        Player.Remain = 3;
    }

    /// <summary>
    /// リトライする
    /// </summary>
    public void Retry()
    {
        SceneTransManager.TransToMainGameLatest();
    }

    /// <summary>
    /// タイトルに戻る
    /// </summary>
    public void BackToTitle()
    {
        SceneTransManager.TransToTitle();
    }
}
