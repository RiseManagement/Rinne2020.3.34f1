using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCharacterController : MonoBehaviour
{
    TutorialController m_tutorialController;

    TutorialState tutorialState;
    public TutorialState TutorialStateGet
    {
        get
        {
            return tutorialState;
        }
    }

    public enum TutorialState
    {
        Nomal,              //通常
        ExplanationActive,  //説明表示
        InputWait,          //入力待ち
        ExplanationNotActive//説明非表示
    }

    private void Start()
    {
        m_tutorialController = GameObject.Find("TutorialController").GetComponent<TutorialController>();
    }

    private void Update()
    {
        UpdateTutorial();
    }

    /// <summary>
    /// 当たり判定（単一判定）
    /// </summary>
    /// <param name="collision">オブジェクトの</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //チュートリアルステートリセット
        switch (collision.tag)
        {
            case "TutorialReset":
                UpdateState(TutorialState.Nomal);
                break;
        }

        //説明表示ステート更新
        if (tutorialState != TutorialState.Nomal) return;
        UpdateState(TutorialState.ExplanationActive);
    }

    /// <summary>
    /// 状態更新
    /// </summary>
    void UpdateState(TutorialState state)
    {
        switch (state)
        {
            case TutorialState.Nomal:
                tutorialState = TutorialState.Nomal;
                break;
            case TutorialState.ExplanationActive:
                tutorialState = TutorialState.ExplanationActive;
                break;
            case TutorialState.InputWait:
                tutorialState = TutorialState.InputWait;
                break;
            case TutorialState.ExplanationNotActive:
                tutorialState = TutorialState.ExplanationNotActive;
                break;
        }
    }

    /// <summary>
    /// チュートリアル更新
    /// </summary>
    void UpdateTutorial()
    {
        switch (tutorialState)
        {
            case TutorialState.Nomal:
                break;
            case TutorialState.ExplanationActive:
                m_tutorialController.TutorialExplanationActive();
                UpdateState(TutorialState.InputWait);

                //テスト文
                m_tutorialController.UpdateHInt("スペースボタン押してください");
                break;
            case TutorialState.InputWait:
                //ボタンごとの処理
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    UpdateState(TutorialState.ExplanationNotActive);
                }
                break;
            case TutorialState.ExplanationNotActive:
                m_tutorialController.TutorialExplanationNotActive();
                break;

        }
    }
}
