using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    //チュートリアルキャンバス
    GameObject tutorialCanvasObj;
    private Vector3 m_offset;
    //チュートリアルキャラ
    GameObject tutorialCharacterObj;
    private RectTransform FrameRect;
    [SerializeField, Header("チュートリアルマネージャー")]
    private TutorialManager m_tutorialManager;
    private RectTransform m_tutorialFramePos;

    // Start is called before the first frame update
    void Start()
    {
        m_offset = new Vector3(2f, 0.5f, 0f);
        tutorialCanvasObj = GameObject.Find("TutorialCanvas");
        tutorialCharacterObj = GameObject.Find("TutorialCharacter_G");
        m_tutorialFramePos = tutorialCanvasObj.transform.GetChild(0).GetComponent<RectTransform>();
        TutorialExplanationNotActive();
        SetDrawPos();
        m_tutorialManager.Init();
    }

    // Update is called once per frame
    void Update()
    {
        //m_tutorialFramePos.position = Camera.main.WorldToScreenPoint(tutorialCharacterObj.transform.position + m_offset);
    }

    /// <summary>
    /// チュートリアル説明表示
    /// </summary>
    public void TutorialExplanationActive()
    {
        Debug.Log("アクティブ");
        tutorialCanvasObj.SetActive(true);
    }

    /// <summary>
    /// チュートリアル説明非表示
    /// </summary>
    public void TutorialExplanationNotActive()
    {
        Debug.Log("ノットアクティブ");
        tutorialCanvasObj.SetActive(false);
    }

    /// <summary>
    /// チュートリアルCanvasの座標セット
    /// </summary>
    void SetDrawPos()
    {
        FrameRect = tutorialCanvasObj.transform.GetChild(0).GetComponent<RectTransform>();
        var framerectWidth = FrameRect.rect.width;
        var framerectHeght = FrameRect.rect.height;

        FrameRect.anchoredPosition = new Vector2(
            tutorialCharacterObj.transform.position.x + framerectWidth / 2.5f,
            tutorialCharacterObj.transform.position.y + framerectHeght);
        Debug.Log(tutorialCharacterObj.transform.position.x);
    }

    /// <summary>
    /// ヒントテキストを更新
    /// </summary>
    /// <param name="hintMessage">ヒントメッセージ</param>
    public void UpdateHInt(string hintMessage)
    {
        //テキスト変数
        var ExplanationObj = tutorialCanvasObj.transform.GetChild(0).GetChild(0);

        //引数のテキストをテキスト変数に更新
        ExplanationObj.GetComponent<Text>().text = hintMessage;
    }
}
