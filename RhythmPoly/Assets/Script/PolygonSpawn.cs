using UnityEngine;
using System.Collections;

public class PolygonSpawn : MonoBehaviour
{
    public GameObject[] target;
	// Use this for initialization

    public float spawnTime;
    public float speed;             //  After 'speed' seconds reaches
    public float angspeed;          //  'angspeed' time rotation per falling
    public ANGLE_DIRECTION angdir;  //  Direction of rotation

    public float bounce;            //  bounce ratio
    public float pathz;             // Descending path variable ratio

    public Queue spawnList;
	
    /* debug */
    public int  idx = 0;
    void Start () {
        spawnList = new Queue();
        Invoke("CreatePolygon",spawnTime);
	}
	// Update is called once per frame
	void Update () {
	   
	}

    void CreatePolygon()
    {
        GameObject go = (GameObject)Instantiate(target[idx],
                    gameObject.transform.position, gameObject.transform.rotation);
        go.transform.parent = gameObject.transform.parent;
        go.GetComponent<PolygonMovement>().init(speed, angspeed, angdir, bounce, pathz);
        spawnList.Enqueue(go);
        idx++;
        if (idx >= target.Length) idx = 0;
        Invoke("CreatePolygon", spawnTime);
    }
    public GameObject GetFrontObject()
    {
        return (GameObject)spawnList.Peek();
    }
    public void RemoveFrontObject()
    {
        GameObject.Destroy((GameObject)spawnList.Peek());
        spawnList.Dequeue();
    }
}
