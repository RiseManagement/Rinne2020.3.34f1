/*--------------------------------
チュートリアル全体を管理するスクリプトです
以下、各チュートリアルの内容
1.左右移動(A,Dキー)
2.ジャンプ(Spaceキー)
3.拠点発見
4.スキル入れ替え
5.スキル合成
6.トラップエリア侵入
7.トラップエリア脱出
8.ステージ1クリア
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField, Header("チュートリアルキャラクターコントローラー")]
    private TutorialCharacterController m_tutorialCharacterController;
    [SerializeField, Header("チュートリアルコントローラー")]
    private TutorialController m_tutorialController;
    [SerializeField, Header("実行中のチュートリアル")]
    private static int m_currentTutorial;
    [SerializeField, Header("ステージ1開始時のヒントテキスト")]
    private string m_hintStage1Start;
    [SerializeField, Header("ジャンプ説明ヒントテキスト")]
    private string m_jumpHint;
    // ヒントテキストを表示したかどうか
    private static List<bool> m_displayCount = new List<bool>();

    public static int CurrentTutorial { get { return m_currentTutorial; } set { m_currentTutorial = value; } }
    public static List<bool> DisplayCount { get { return m_displayCount; } set { m_displayCount = value; } }

    public void Init()
    {
        for (int i = 0; i < 11; i++)
        {
            DisplayCount.Add(false);
        }
        Stage1Start();
    }

    /// <summary>
    /// ステージ1開始チュートリアル
    /// </summary>
    private void Stage1Start()
    {
        // 左右移動チュートリアルがまだ実行されていなければ
        if (!DisplayCount[0])
        {
            m_tutorialController.UpdateHInt(m_hintStage1Start);
            m_tutorialCharacterController.TutorialStateGet = TutorialCharacterController.TutorialState.ExplanationActive;
            UpdateCurrentTutorial();
        }
    }

    /// <summary>
    /// ジャンプ説明チュートリアル
    /// </summary>
    public void JumpHint()
    {
        if (!DisplayCount[1])
        {
            m_tutorialController.UpdateHInt(m_jumpHint);
            m_tutorialCharacterController.TutorialStateGet = TutorialCharacterController.TutorialState.ExplanationActive;
            UpdateCurrentTutorial();
        }
    }

    /// <summary>
    /// チュートリアルを更新する
    /// </summary>
    public static void UpdateCurrentTutorial()
    {
        CurrentTutorial++;
        DisplayCount[CurrentTutorial - 1] = true;
    }
}
