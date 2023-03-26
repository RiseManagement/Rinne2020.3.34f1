using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    //チュートリアルキャンバス
    GameObject tutorialCanvasObj;

    //チュートリアルキャラ
    GameObject tutorialCharacterObj;

    // Start is called before the first frame update
    void Start()
    {
        tutorialCanvasObj = GameObject.Find("TutorialCanvas");
        tutorialCharacterObj = GameObject.Find("TutorialCharacter_G");

        TutorialExplanationNotActive();
        SetDrawPos();
    }

    // Update is called once per frame
    void Update()
    {
    }

    /// <summary>
    /// チュートリアル説明表示
    /// </summary>
    public void TutorialExplanationActive()
    {
        tutorialCanvasObj.SetActive(true);
    }

    /// <summary>
    /// チュートリアル説明非表示
    /// </summary>
    public void TutorialExplanationNotActive()
    {
        tutorialCanvasObj.SetActive(false);
    }

    /// <summary>
    /// チュートリアルCanvasの座標セット
    /// </summary>
    void SetDrawPos()
    {
        var FrameRect = tutorialCanvasObj.transform.GetChild(0).GetComponent<RectTransform>();
        var framerectWidth = FrameRect.rect.width;
        var framerectHeght = FrameRect.rect.height;

        FrameRect.anchoredPosition = new Vector2(
            tutorialCharacterObj.transform.position.x + framerectWidth / 2.5f,
            tutorialCharacterObj.transform.position.y + framerectHeght);
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
