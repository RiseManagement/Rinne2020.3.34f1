using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gimmick : MonoBehaviour
{
    [SerializeField, Header("死因")]
    private CauseOfDeathType m_causeOfDeathType;
}
