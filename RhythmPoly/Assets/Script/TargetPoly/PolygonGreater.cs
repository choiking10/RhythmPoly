using UnityEngine;
using System.Collections;

class PolygonGreater : MonoBehaviour
{
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        gameObject.transform.localScale += new Vector3(1f, 1f, 0f);
        if (gameObject.transform.localScale.x > 30f)
        {
            Destroy(gameObject);
        }
    }
}
