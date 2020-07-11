using UnityEngine;

public class PointToMouse : MonoBehaviour
{
    Vector3 mousePos = new Vector3();
    Vector3 screenCenter = new Vector3();

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

        transform.rotation = Quaternion.FromToRotation(Vector3.left, mousePos);
    }
}
