using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCharacterController : MonoBehaviour
{
    TutorialController m_tutorialController;
    [SerializeField, Header("チュートリアルマネージャー")]
    private TutorialManager m_tutorialManager;
    [SerializeField, Header("選択肢フレーム")]
    private GameObject m_selectionFrame;
    [SerializeField, Header("チュートリアルキャンバス")]
    private GameObject m_tutorialCanvas;
    private static bool m_isInteractable;

    public static bool IsInteractable { get { return m_isInteractable; } set { m_isInteractable = value; } }

    TutorialState tutorialState;
    public TutorialState TutorialStateGet
    {
        get
        {
            return tutorialState;
        }
        set
        {
            tutorialState = value;
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
        if (collision.CompareTag("Tutorial"))
        {
            var hintText = collision.GetComponent<Hint>();
            m_tutorialController.UpdateHInt(hintText.m_hintText);
            UpdateState(TutorialState.ExplanationActive);
            TutorialManager.UpdateCurrentTutorial();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && IsInteractable && Input.GetKey(KeyCode.F))
        {
            m_selectionFrame.SetActive(true);
            m_tutorialCanvas.SetActive(true);
        }
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
    /// チュートリアル状態の更新
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
                break;
            case TutorialState.InputWait:
                if (TutorialManager.CurrentTutorial == 1 && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)))
                {
                    UpdateState(TutorialState.ExplanationNotActive);
                    m_tutorialManager.Invoke("JumpHint", 2);
                }
                else if (TutorialManager.CurrentTutorial == 2 && Input.GetKeyDown(KeyCode.Space))
                {
                    UpdateState(TutorialState.ExplanationNotActive);
                }
                else if (TutorialManager.CurrentTutorial == 3)
                {
                    // TODO: 拠点のヒント処理
                }
                break;
            case TutorialState.ExplanationNotActive:
                m_tutorialController.TutorialExplanationNotActive();
                UpdateState(TutorialState.Nomal);
                break;
        }
    }
}
