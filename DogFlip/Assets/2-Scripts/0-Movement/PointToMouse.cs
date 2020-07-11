using UnityEngine;

public class PointToMouse : MonoBehaviour
{
    Vector3 mousePos = new Vector3();
    Vector3 screenCenter = new Vector3();

    public float angle;
    public string lookDirection = "down";

    // Start is called before the first frame update
    void Start()
    {
        screenCenter.x = Screen.width / 2;
        screenCenter.z = Screen.height/ 2;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos.x = Input.mousePosition.x - screenCenter.x;
        mousePos.z = Input.mousePosition.y - screenCenter.z;

        angle = Vector3.SignedAngle(Vector3.left, mousePos, Vector3.up) - 22.5f;

             if (angle >= 0 && angle < 45) lookDirection = "up-left";
        else if (angle >= 45 && angle < 90) lookDirection = "up";
        else if (angle >= 90 && angle < 135) lookDirection = "up-right";

        else if (angle >= 135 || angle < -180) lookDirection = "right";

        else if (angle >= -45 && angle < 0) lookDirection = "left";
        else if (angle >= -90 && angle < -45) lookDirection = "down-left";
        else if (angle >= -135 && angle < -90) lookDirection = "down";
        else if (angle >= -180 && angle < -135) lookDirection = "down-right";

        transform.rotation = Quaternion.FromToRotation(Vector3.left, mousePos);
    }
}
