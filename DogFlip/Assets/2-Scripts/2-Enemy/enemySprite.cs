using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySprite : MonoBehaviour
{
    public GameObject model;
    public SpriteRenderer spr;
    string look;
    float angle;

    public Sprite u;
    public Sprite ur;
    public Sprite r;
    public Sprite ul;
    public Sprite d;
    public Sprite dr;
    public Sprite l;
    public Sprite dl;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = model.transform.position + Vector3.left * 0.5f;

        angle = Vector3.SignedAngle(Vector3.forward, -model.transform.forward , Vector3.up) - 22.5f;

        if (angle >= 0 && angle < 45) look = "up-left";
        else if (angle >= 45 && angle < 90) look = "up";
        else if (angle >= 90 && angle < 135) look = "up-right";

        else if (angle >= 135 || angle < -180) look = "right";

        else if (angle >= -45 && angle < 0) look = "left";
        else if (angle >= -90 && angle < -45) look = "down-left";
        else if (angle >= -135 && angle < -90) look = "down";
        else if (angle >= -180 && angle < -135) look = "down-right";

        switch (look)
        {
            case "up-left":
                spr.sprite = ul;
                break;
            case "up":
                spr.sprite = u;
                break;
            case "up-right":
                spr.sprite = ur;
                break;
            case "right":
                spr.sprite = r;
                break;
            case "down-right":
                spr.sprite = dr;
                break;
            case "down":
                spr.sprite = d;
                break;
            case "down-left":
                spr.sprite = dl;
                break;
            case "left":
                spr.sprite = l;
                break;

        }
    }
}
