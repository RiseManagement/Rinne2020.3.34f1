using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotSelectionManager : MonoBehaviour
{
    [SerializeField, Header("スロット")]
    private Image[] m_slots;
    [SerializeField, Header("選択中のスロット")]
    private Image m_selectedSlot;
    private int m_selectedSlotIndex = 0;


    // Update is called once per frame
    void Update()
    {
        // 右キーかDキーを押したら
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            // 選択中のスロットを変更する
            m_selectedSlotIndex = (m_selectedSlotIndex + 1) % m_slots.Length;
        }
        // 左キーかAキーを押したら
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            // 選択中のスロットが0より小さくなる場合
            if ((m_selectedSlotIndex - 1) % m_slots.Length < 0)
            {
                // 最後のスロットに移動する
                m_selectedSlotIndex = m_slots.Length - 1;
            }
            else
            {
                // 選択中のスロットを変更する
                m_selectedSlotIndex = (m_selectedSlotIndex - 1) % m_slots.Length;
            }
            Debug.Log(m_selectedSlotIndex);
        }
        // 上キーかWキーを押したら
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            // スロット0に移動する
            m_selectedSlotIndex = 0;
        }
        // 下キーかSキーを押したら
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            // スロット2に移動する
            m_selectedSlotIndex = 2;
        }
        // エンターキーを押したら
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            // エンターキーを押した際の処理
        }

        // 選択中のスロットに選択グラフィックを表示する
        m_selectedSlot.transform.position = m_slots[m_selectedSlotIndex].transform.position;
    }
}
