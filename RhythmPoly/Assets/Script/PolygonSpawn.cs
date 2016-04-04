using UnityEngine;
using System.Collections;

public class PolygonSpawn : MonoBehaviour
{
    public GameObject[] target;
    public AudioSource audiosource;
    // Use this for initialization

    public float spawnTime;
    public float fallingspeed;             //  After 'speed' seconds reaches
    public float angspeed;          //  'angspeed' time rotation per falling
    public int limitPolyAngle;      // poly`s change angle range
    public ANGLE_DIRECTION angdir;  //  Direction of rotation

    public float bounce;            //  bounce ratio
    public float pathz;             // Descending path variable ratio

    private Queue spawnList;

    public string filename;
	
    /* debug */
    public int idx = 0;
    public int delta = 0;
    public int ppreIdx = 0;

    void Start () {
        spawnList = new Queue();
        angspeed = 1;
        ppreIdx = 0;
        Invoke("MusicStart", 1f);
	}
    
    void MusicStart()
    {
        delta = 0;
        audiosource.Play();
    }
    void FixedUpdate()
    {
        delta += (int)(Time.fixedDeltaTime * 1000f);
        CreatePolygon();
    }
    
    void CreatePolygon()
    {
        //condition 
        if (delta < spawnTime)
        {
            return;
        }
        delta = 0;

        //make Poly
        GameObject go = (GameObject)Instantiate(nextPrefab(),
                    gameObject.transform.position, gameObject.transform.rotation);
        go.transform.parent = gameObject.transform.parent;
        go.GetComponent<PolygonMovement>().init(fallingspeed, angspeed, angdir, bounce, pathz);
        spawnList.Enqueue(go);

        idx++;

        //if(datas.Length > idx)
          //  Invoke("CreatePolygon", spawnTime);
    }
    public void SetLevel(int anglimit, float sptime, float falltime)
    {
        limitPolyAngle = anglimit;
        spawnTime = sptime * 1000;
        fallingspeed = falltime;
    }
    public GameObject nextPrefab()
    {
        Debug.Log(" ppreidx : " + ppreIdx + "limitPoly angle : " + limitPolyAngle);
        
        Debug.Log("(" + Mathf.Max(0, ppreIdx - limitPolyAngle) + "," + Mathf.Min(4, ppreIdx + limitPolyAngle) + ")");
        int nextIdx = Random.Range(Mathf.Max(0, ppreIdx - limitPolyAngle), Mathf.Min(4, ppreIdx + limitPolyAngle));
        
        ppreIdx = nextIdx;
        return target[nextIdx];
    }
    public GameObject GetFrontObject()
    {
        if (spawnList.Count == 0) return null;
        return (GameObject)spawnList.Peek();
    }
    public void RemoveFrontObject()
    {
        if (spawnList.Count == 0) return;
        ((GameObject)spawnList.Dequeue()).GetComponent<PolygonMovement>().destroyflag = true;
    }
}
