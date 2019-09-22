// Date   : 22.09.2019 17:46
// Project: Game
// Author : bradur

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RectTransformFollowMouse : MonoBehaviour {

    private RectTransform rectTransform;

    void Start() {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update() {
        Cursor.visible = false;
        Vector2 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        //Vector2 mousePos = Input.mousePosition;
        mousePos.x *= Screen.width;
        mousePos.y *= Screen.height;
        rectTransform.anchoredPosition = mousePos;
    }

}
