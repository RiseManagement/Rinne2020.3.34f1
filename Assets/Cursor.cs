using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    //ボタンのオブジェクト
    public GameObject buttonObj;
    RectTransform rectTransform = null;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = buttonObj.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {//右
            this.gameObject.transform.position = 
                new Vector2(this.gameObject.transform.position.x + rectTransform.rect.width,
                            this.gameObject.transform.position.y);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {//左
            this.gameObject.transform.position =
                new Vector2(this.gameObject.transform.position.x - rectTransform.rect.width,
                    this.gameObject.transform.position.y);
        }
    }

    //移動処理

    //決定後の遷移
}
