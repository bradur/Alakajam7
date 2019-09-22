// Date   : 22.09.2019 17:46
// Project: Game
// Author : bradur

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RectTransformFollowMouse : MonoBehaviour {

    //private RectTransform rectTransform;
    private Image image;

    [SerializeField]
    private Canvas parentCanvas;
    void Start() {
        //rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }

    void Update() {
        Cursor.visible = false;
        Vector3 movePos;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(
            parentCanvas.transform as RectTransform,
            Input.mousePosition,
            null, //parentCanvas.worldCamera,
            out movePos
        );


        image.transform.position = (Vector2)movePos;
    }

}
