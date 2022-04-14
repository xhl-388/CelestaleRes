using UnityEngine;
using System.Collections;

public class DragMouse : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        //  StartCoroutine(OnMyMouseDown());
    }
    private IEnumerator OnMyMouseDown()
    {
        while (true)
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 camera = Camera.main.WorldToScreenPoint(transform.position);// 相机是世界的，世界到屏幕
                Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.z);
                transform.position = Camera.main.ScreenToWorldPoint(pos);
                Debug.Log("Down True ");

            }
            yield return new WaitForEndOfFrame();
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 camera = Camera.main.WorldToScreenPoint(transform.position);// 相机是世界的，世界到屏幕
            Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.z);
            //transform.position = Camera.main.ScreenToWorldPoint(pos);
            Debug.Log(Camera.main.ScreenToWorldPoint(pos));
            //Debug.Log("Down True ");

        }
    }
}