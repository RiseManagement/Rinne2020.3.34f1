using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SkillDBEntity))]
public class SkillDBEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var skillDBEntity = target as SkillDBEntity;
        if (GUILayout.Button("継承状態リセット"))
        {
            skillDBEntity.ResetInherited();
        }
    }
}
