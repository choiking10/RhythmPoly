using System;
using UnityEngine;
using System.Collections;

public class PolygonAccpet : MonoBehaviour
{
    public string target_name = "UserPoly"; 
    public float speed; // speed초만에 userpoly에 도달
    public Vector3 startPos ;
    public Vector3 targetPos;
    public Vector3 targetRot;
    public float movstep;
    public float rotstep;

    void Start()
    {
        speed = 0.2f;

        startPos = gameObject.transform.position;
        targetPos = GameObject.Find(target_name).transform.position;
        targetRot = GameObject.Find(target_name).transform.eulerAngles;
        float dist = Vector3.Distance(startPos, targetPos);
        movstep = dist * Time.fixedDeltaTime / speed;

        Vector3 pang = gameObject.transform.eulerAngles;
        pang.x = (pang.x + 360f) % 360f;
        pang.y = (pang.y + 360f) % 360f;
        pang.z = (pang.z + 360f) % 360f;

        dist = Vector3.Distance(pang, targetRot);
        rotstep = dist * Time.fixedDeltaTime / speed;

        RemoveMover();
    }
    public void RemoveMover()
    {
        Destroy(gameObject.GetComponent<PolygonMovement>());
    }

    void FixedUpdate()
    {
        gameObject.transform.position =
                Vector3.MoveTowards(gameObject.transform.position,
                                  targetPos, movstep);
        Vector3 pang = gameObject.transform.eulerAngles;
        pang.x = (pang.x + 360f) % 360f;
        pang.y = (pang.y + 360f) % 360f;
        pang.z = (pang.z + 360f) % 360f;
        gameObject.transform.eulerAngles =
                Vector3.MoveTowards(pang,
                                  targetRot, rotstep);
        if(targetPos == gameObject.transform.position)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(51f / 255f, 102f / 255f, 213f / 255f, 1f);
            gameObject.AddComponent<PolygonGreater>();
            Destroy(this);
        }
    }
}
