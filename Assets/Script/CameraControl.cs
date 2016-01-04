using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
    public float zoomSpeed = 0.1f;
    public float targetOrtho;
    public float smoothSpeed = 0.1f;
    public float minOrtho = 0.3f;
    public float maxOrtho = 2.0f;
    private Vector3 dragOrigin;
	// Use this for initialization
	void Start () {
        targetOrtho = GetComponent<Camera>().orthographicSize;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            dragOrigin = GetComponent<Camera>().ScreenToWorldPoint(dragOrigin);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 currentPos =new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            currentPos = GetComponent<Camera>().ScreenToWorldPoint(currentPos);
            Vector3 movePos = dragOrigin - currentPos;
            transform.position = transform.position + movePos;
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0.0f)
        {
            targetOrtho -= scroll * zoomSpeed;
            targetOrtho = Mathf.Clamp(targetOrtho, minOrtho, maxOrtho);
        }
        GetComponent<Camera>().orthographicSize = Mathf.MoveTowards(GetComponent<Camera>().orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);
    }
}
