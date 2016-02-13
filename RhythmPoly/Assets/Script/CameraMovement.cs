using UnityEngine;
using System.Collections;

class CameraMovement: MonoBehaviour 
{
    public float speed;
    public Vector3 limit;
    public Vector3 target;

    void Start()
    {
        target = RandomGeneration();
    }

    void Update()
    {
        Vector3 tmp = transform.localEulerAngles;
        if (tmp.x >= 180) tmp.x -= 360;
        if (tmp.y >= 180) tmp.y -= 360;
        if (tmp.z >= 180) tmp.z -= 360;

        if (Vector3.Distance(target, tmp) < 0.1f)
        {
            target = RandomGeneration();
        }
        else
        {
            transform.localEulerAngles = Vector3.MoveTowards(tmp, target, speed * Time.deltaTime);
            //Debug.Log(transform.localEulerAngles);
        }
    }
    Vector3 RandomGeneration()
    {
        return new Vector3( Random.Range(-limit.x, limit.x),
                          Random.Range(-limit.y, limit.y),
                          Random.Range(-limit.z, limit.z)); ;
    }

}
