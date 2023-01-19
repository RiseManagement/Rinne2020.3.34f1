using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSceneTransition : MonoBehaviour
{
    [SerializeField]
    Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        int len = this.gameObject.name.Length;
        int buttonNoText = int.Parse(gameObject.name.Substring(len - 1));

        button.onClick.AddListener(() => SceneTransManager.TransToStage(buttonNoText));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
