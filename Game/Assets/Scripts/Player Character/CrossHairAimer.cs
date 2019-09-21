// Date   : 21.09.2019 18:01
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;

public class CrossHairAimer : MonoBehaviour {

    [SerializeField]
    private Transform crossHair;
    void Start () {
        if (crossHair == null) {
            Debug.Log("<color=red>Crosshair missing from " + name + "!</color>");
        }
    }

    void Update () {
        crossHair.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        /*
        Vector2 mousePosition = Input.mousePosition;
        Vector2 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        Vector2 offset = new Vector2(mousePosition.x - screenPoint.x, mousePosition.y - screenPoint.y);
        if (offset.magnitude > minMagnitude) {
            float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle + preAngle);
        }*/
    }

    public Vector2 GetDirection() {
        /*Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePosition);*/
        Vector2 direction = crossHair.position - transform.position;
        return direction.normalized;
    }
}
