using UnityEngine;
using System.Collections;

public class PolygonSpawn : MonoBehaviour
{
    public GameObject[] target;
    public PolygonData[] datas;
    public AudioSource audiosource;
    // Use this for initialization

    public float spawnTime;
    public float speed;             //  After 'speed' seconds reaches
    public float angspeed;          //  'angspeed' time rotation per falling
    public ANGLE_DIRECTION angdir;  //  Direction of rotation

    public float bounce;            //  bounce ratio
    public float pathz;             // Descending path variable ratio

    private Queue spawnList;

    public string filename;
	
    /* debug */
    public int idx = 0;
    public int bef = 3;
    public int delta = 0;
    public int ppreIdx = 0;
    void Start () {
        spawnList = new Queue();
        datas = PolygonData.GetDataFromFile(filename);
        Debug.Log("test :" + datas); 
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

        if (idx >= datas.Length) return;
        if (datas[idx].timeline - datas[idx].speed * 1000 < delta) CreatePolygon();
    }
    
    void CreatePolygon()
    {
        GameObject go = (GameObject)Instantiate(nextPrefab(),
                    gameObject.transform.position, gameObject.transform.rotation);
        go.transform.parent = gameObject.transform.parent;
        go.GetComponent<PolygonMovement>().init(datas[idx].speed, datas[idx].angspeed, datas[idx].angdir, bounce, pathz);
        spawnList.Enqueue(go);

        idx++;

        //if(datas.Length > idx)
          //  Invoke("CreatePolygon", spawnTime);
    }
    public GameObject nextPrefab()
    {
        int nextIdx = Random.Range(ppreIdx - datas[idx].limit_change < 0 ? 0 : ppreIdx - datas[idx].limit_change,
                                ppreIdx + datas[idx].limit_change > 3 ? 3 : ppreIdx + datas[idx].limit_change);
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
