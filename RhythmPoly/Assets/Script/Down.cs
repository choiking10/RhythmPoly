using UnityEngine;
using System.Collections;

public class Down : MonoBehaviour {
    public float speed;
    public float angspeed;
    private Vector3 startVertex;
    private Vector3 mousePos;
	// Use this for initialization
	void Start () {
        startVertex = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pvec = gameObject.transform.position;
        if (gameObject.transform.position.y > 0)
        {
            gameObject.transform.position -= new Vector3(0, speed, 0);
            gameObject.transform.localScale -= new Vector3(speed, 0, speed);
            gameObject.transform.eulerAngles += new Vector3(0, speed * angspeed, 0);
        }
	}
    void OnPostRender()
    {
        GL.PushMatrix();
        GL.LoadOrtho();
        GL.Begin(GL.LINES);
        GL.Color(Color.red);
        GL.Vertex(startVertex);
        GL.Vertex(new Vector3(mousePos.x / Screen.width, mousePos.y / Screen.height, 0));
        GL.End();
        GL.PopMatrix();
    }
}
