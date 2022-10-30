using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    private void Start()
    {
        // 継承中のスキルを全削除
        Player.m_inheritedSkills.Clear();
    }
}
