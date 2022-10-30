using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Player.m_inheritedSkills.Clear();
        Player.Remain = 3;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    SceneTransManager.TransToStageSelect();
        //}
    }

    /// <summary>
    /// ステージ1に遷移する
    /// </summary>
    public void TransToMainGame()
    {
        SceneTransManager.TransToStage1();
    }

    /// <summary>
    /// ゲームを終了する
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();
    }
}
