using UnityEngine;
using System.Collections;

public class PolygonSpawn : MonoBehaviour
{
    public GameObject target;
	// Use this for initialization

    public float spawnTime;
    public float speed;             //  After 'speed' seconds reaches
    public float angspeed;          //  'angspeed' time rotation per falling
    public ANGLE_DIRECTION angdir;  //  Direction of rotation

    public float bounce;            //  bounce ratio
    public float pathz;             // Descending path variable ratio

    public Queue spawnList;
	void Start () {
        spawnList = new Queue();
        Invoke("CreatePolygon",spawnTime);
	}
	
	// Update is called once per frame
	void Update () {
	   
	}

    void CreatePolygon()
    {
        GameObject go = (GameObject)Instantiate(target,
                    gameObject.transform.position, gameObject.transform.rotation);
        go.transform.parent = gameObject.transform.parent;
        go.GetComponent<PolygonMovement>().init(speed, angspeed, angdir, bounce, pathz);
        //if (angdir == ANGLE_DIRECTION.CLOCK_WISE) angdir = ANGLE_DIRECTION.COUNTER_CLOCK_WISE;
        //else angdir = ANGLE_DIRECTION.CLOCK_WISE;
        spawnList.Enqueue(go);
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
