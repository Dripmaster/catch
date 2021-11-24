using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class penScript : MonoBehaviour
{
    static Color[] colors = { Color.white,Color.black,Color.red,Color.blue,Color.green}; 
    static float[] sizes = { 0.05f,0.03f,0.01f};

    int colorNum, sizeNum;

    MeshRenderer r;
    public TrailRenderer _trail;
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<MeshRenderer>();
        colorNum = 1;
        sizeNum = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            if(!isOnUI())
            _trail.emitting = true;
        }
        else
        {
            _trail.emitting = false;
        }
        _trail.startWidth = transform.localScale.x;
        _trail.material.color = r.material.color;
    }

    public void changeColor()
    {
        r.material.color = colors[colorNum++];
        if (colorNum >= colors.Length)
            colorNum = 0;
    }
    public void changeSize()
    {
        transform.localScale = Vector3.one * sizes[sizeNum++]; 
        if (sizeNum >= sizes.Length)
            sizeNum = 0;
    }
    public void clear()
    {

        _trail.Clear();
    }
    public static bool isOnUI()
    {//터치 포인트가 UI위에 있는지 확인해준다.
        List<RaycastResult> results = new List<RaycastResult>();
        PointerEventData ped = new PointerEventData(GameObject.Find("EventSystem").GetComponent<EventSystem>());
        ped.position = Input.GetTouch(0).position;
        GameObject.Find("Canvas").GetComponent<GraphicRaycaster>().Raycast(ped, results);
        if (results.Count > 0)
        {
            return true;
        }
        return false;
    }
}
