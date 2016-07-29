using UnityEngine;
using System.Collections;

public class TuToImageSwap : MonoBehaviour
{
    public float imageSize;
    public int imageCount;
    public GameObject imageGroup;

    private Vector3 startMouse;
    private Vector3 startLocal;
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startMouse = Camera.main.ScreenToViewportPoint(Input.mousePosition) * 720;
            startLocal = imageGroup.GetComponent<RectTransform>().localPosition;
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 pdiff = startMouse - Camera.main.ScreenToViewportPoint(Input.mousePosition)*720;
            Vector3 plocal = imageGroup.GetComponent<RectTransform>().localPosition;
            plocal.x = startLocal.x - pdiff.x;
            if (plocal.x >= 0) plocal.x = 0;
            if (plocal.x <= - imageSize * (imageCount - 1 ) )  plocal.x = - imageSize * (imageCount - 1 );
            imageGroup.GetComponent<RectTransform>().localPosition = plocal;
        }
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 plocal = imageGroup.GetComponent<RectTransform>().localPosition;
            plocal.x = Mathf.FloorToInt((plocal.x + imageSize / 2) / imageSize) * imageSize;
            imageGroup.GetComponent<RectTransform>().localPosition = plocal;
        }
    }
}

