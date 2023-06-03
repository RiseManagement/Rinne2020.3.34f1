using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour
{
    [SerializeField, Header("選択肢1グラフィック")]
    private GameObject m_selectionImage1;
    [SerializeField, Header("選択肢2グラフィック")]
    private GameObject m_selectionImage2;
    private bool m_selection1;
    private bool m_selection2;
    [SerializeField, Header("チュートリアルフレーム")]
    private GameObject m_tutorialFrame;
    private RectTransform m_selectionFramePos;
    private Vector3 m_offset;

    private void Start()
    {
        m_selection1 = true;
        m_selection2 = false;
        m_selectionFramePos = GetComponent<RectTransform>();
        m_offset = new Vector3(290f, 0f, 0f);
    }

    private void Update()
    {
        // 選択肢フレームの位置をチュートリアルフレーム＋オフセットの位置に配置する
        m_selectionFramePos.position = m_tutorialFrame.transform.position + m_offset;
        // 選択肢1が選択されている時
        if (m_selection1)
        {
            m_selectionImage1.SetActive(true);
            m_selectionImage2.SetActive(false);

            // Sキーまたは下矢印キーを押したら
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                m_selection2 = true;
                m_selection1 = false;
            }

            // エンターキーを押したら
            if (Input.GetKey(KeyCode.Return))
            {
                SceneTransManager.TransToSkillSwap();
            }
        }
        // 選択肢2が選択されている時
        else if (m_selection2)
        {
            m_selectionImage2.SetActive(true);
            m_selectionImage1.SetActive(false);
            // Wキーまたは上矢印キーを押したら
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                m_selection1 = true;
                m_selection2 = false;
            }
            // エンターキーを押したら
            if (Input.GetKey(KeyCode.Return))
            {
                SceneTransManager.TransToSkillFusion();
            }
        }
    }
}