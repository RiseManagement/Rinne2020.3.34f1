using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCharacterController : MonoBehaviour
{
    [SerializeField, Header("TutorialController")]
    private TutorialController m_tutorialController;

    TutorialState tutorialState;
    //名称は考え中
    public TutorialState TutorialStateA
    {
        set { }
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

    }

    private void Update()
    {
        UpdateTutorial();
    }

    /// <summary>
    /// 当たり判定（当たっている最中）
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerStay2D(Collider2D collision)
    {
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
                m_tutorialController.UpdateHInt("Aボタン押してください");
                break;
            case TutorialState.InputWait:
                //ボタンごとの処理追加
                if (Input.GetKeyDown(KeyCode.A))
                {
                    UpdateState(TutorialState.ExplanationNotActive);
                }
                break;
            case TutorialState.ExplanationNotActive:
                m_tutorialController.TutorialExplanationNotActive();
                UpdateState(TutorialState.Nomal);
                break;

        }
    }
}
