﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearManager : MonoBehaviour
{
    private void Start()
    {
        // 継承中のスキルを全削除
        Player.m_inheritedSkills.Clear();
    }

    /// <summary>
    /// タイトルに戻る
    /// </summary>
    public void BackToTitle()
    {
        SceneTransManager.TransToTitle();
    }
}
