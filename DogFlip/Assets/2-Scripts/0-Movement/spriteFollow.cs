using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteFollow : MonoBehaviour
{
    public GameObject model;
    public SpriteRenderer spr;
    string look;

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
        look = model.GetComponent<PointToMouse>().lookDirection;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = model.transform.position + Vector3.left*0.5f;

        look = model.GetComponent<PointToMouse>().lookDirection;
        
        print(look);

        switch(look){
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
