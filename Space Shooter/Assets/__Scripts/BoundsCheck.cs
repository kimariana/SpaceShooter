using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Keeps a GameObject on screen
// ONLY works for an orthographic Main Camera
public class BoundsCheck : MonoBehaviour
{
    public enum eType { center, inset, outset };

    [Header("Inscribed")]
    public eType boundsType = eType.center;
    public float radius = 1f;

    [Header("Dynamic")]
    public float camWidth;
    public float camHeight;

    void Awake() {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
    }

    void LateUpdate() {
        // Find the checkRadius that will enable center, inset, or outset
        float checkRadius = 0;
        if(boundsType == eType.inset) checkRadius = -radius;
        if(boundsType == eType.outset) checkRadius = radius;

        Vector3 pos = transform.position;

        // Restrict the X position to camWidth
        if(pos.x > camWidth + checkRadius) {
            pos.x = camWidth + checkRadius;
        }
        if(pos.x < -camWidth - checkRadius) {
            pos.x = -camWidth - checkRadius;
        }

        // Restrict the Y position to camHeight
        if(pos.y > camHeight + checkRadius) {
            pos.y = camHeight + checkRadius;
        }
        if(pos.y < -camHeight - checkRadius) {
            pos.y = -camHeight - checkRadius;
        }

        transform.position = pos;
    }
}
