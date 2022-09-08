using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameManager : MonoBehaviour
{
    [SerializeField, Header("PlayerController")]
    private PlayerController m_playerController;
    // Start is called before the first frame update
    void Start()
    {
        m_playerController.Init();
    }
}
