using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : MonoBehaviour
{
    [SerializeField, Header("スロットプレハブ")]
    private GameObject m_slotPrefab;
    [SerializeField, Header("入れ替えスキルスロットパネル")]
    private GameObject m_swapSkillSlotPanel;
    [SerializeField, Header("入れ替えスキルスロット")]
    private List<SkillSlot> m_swapSkillSlots = new List<SkillSlot>();
    [SerializeField, Header("継承中スキルスロット")]
    private SkillSlot[] m_inheritedSkillSlots;
    [SerializeField, Header("スキルなしの通知")]
    private GameObject m_noSkillText;

    private void Start()
    {
        // 入れ替えられるスキルが1つでもある場合
        if (Player.m_swapSkills.Count != 0)
        {
            m_noSkillText.SetActive(false);
            // 入れ替えスキルの数だけ入れ替えスキルスロットを生成する
            for (int i = 0; i < Player.m_swapSkills.Count; i++)
            {
                m_swapSkillSlots.Add(Instantiate(m_slotPrefab, m_swapSkillSlotPanel.transform).GetComponent<SkillSlot>());
                m_swapSkillSlots[i].Skill = Player.m_swapSkills[i];
                m_swapSkillSlots[i].ShowSkillText();
            }
        }
        else
        {
            m_noSkillText.SetActive(true);
        }
        // 継承中のスキルの数だけ継承中スキルスロットを生成する
        for (int i = 0; i < Player.m_inheritedSkills.Count; i++)
        {
            m_inheritedSkillSlots[i].Skill = Player.m_inheritedSkills[i];
            m_inheritedSkillSlots[i].ShowSkillText();
        }
    }
}
