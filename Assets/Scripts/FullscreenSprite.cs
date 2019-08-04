using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullscreenSprite : MonoBehaviour
{

    public float overflow = 0.2f;
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr == null) return;

        transform.localScale = new Vector3(1, 1, 1);

        float width = sr.sprite.bounds.size.x;
        float height = sr.sprite.bounds.size.y;


        float worldScreenHeight = Camera.main.orthographicSize * 2f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        Vector3 xWidth = transform.localScale;
        xWidth.x = (worldScreenWidth / width) + overflow;
        transform.localScale = xWidth;
        //transform.localScale.x = worldScreenWidth / width;
        Vector3 yHeight = transform.localScale;
        yHeight.y = (worldScreenHeight / height) + overflow;
        transform.localScale = yHeight;
        //transform.localScale.y = worldScreenHeight / height;
    }

    public static float GetScreenToWorldHeight
    {
        get
        {
        Vector2 topRightCorner = new Vector2(1, 1);
        Vector2 edgeVector = Camera.main.ViewportToWorldPoint(topRightCorner);
        var height = edgeVector.y * 2;
        return height;
        }
    }
    public static float GetScreenToWorldWidth
    {
        get
        {
        Vector2 topRightCorner = new Vector2(1, 1);
        Vector2 edgeVector = Camera.main.ViewportToWorldPoint(topRightCorner);
        var width = edgeVector.x * 2;
        return width;
        }
    }
}
