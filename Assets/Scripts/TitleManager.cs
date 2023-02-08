using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Player.m_inheritedSkills.Clear();
        Player.Life = 3;
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// ステージセレクトに遷移する
    /// </summary>
    public void TransToStageSelect()
    {
        SceneTransManager.TransToStageSelect();
    }

    /// <summary>
    /// ゲームを終了する
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();
    }
}
