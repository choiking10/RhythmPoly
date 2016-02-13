﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Polygon : MonoBehaviour {
	public List<GameObject> poly;
	public int lastPoly;
	static GameObject nowPoly;
	// Use this for initialization
	void Start () {
		for (int i = 1; i < 5; i++)
			poly [i].active = false;
		nowPoly = poly [0];
	}
    void AllFalse()
    {
        for (int i = 0; i < 5; i++)
            poly[i].active = false;
    }
    public void AttachRoutine()
    {
        Debug.Log("attach");
        if (nowPoly == poly[0])
        {
            AllFalse();
            poly[0].active = true;

            nowPoly.GetComponent<Animator>().Play("3_4");
            lastPoly = 4;
            nowPoly = poly[1];
        }
        else if (nowPoly == poly[1])
        {
            AllFalse();
            poly[1].active = true;
            nowPoly.GetComponent<Animator>().Play("4_5");
            lastPoly = 5;
            nowPoly = poly[2];
        }
        else if (nowPoly == poly[2])
        {
            AllFalse();
            poly[2].active = true;
            nowPoly.GetComponent<Animator>().Play("5_6");
            lastPoly = 6;
            nowPoly = poly[3];
        }
        else if (nowPoly == poly[3])
        {
            AllFalse();
            poly[3].active = true;
            nowPoly.GetComponent<Animator>().Play("6_7");
            lastPoly = 7;
            nowPoly = poly[4];
        }
        TouchReceiver.IsAttached = false;
    }
    public void DetachRoutine()
    {
        if (nowPoly == poly[1])
        {
            AllFalse();
            poly[1].active = true;
            nowPoly.GetComponent<Animator>().Play("4_3");
            lastPoly = 3;
            nowPoly = poly[0];
        }
        if (nowPoly == poly[2])
        {
            AllFalse();
            poly[2].active = true;
            nowPoly.GetComponent<Animator>().Play("5_4");
            lastPoly = 4;
            nowPoly = poly[1];
        }
        if (nowPoly == poly[3])
        {
            AllFalse();
            poly[3].active = true;
            nowPoly.GetComponent<Animator>().Play("6_5");
            lastPoly = 5;
            nowPoly = poly[2];
        }
        if (nowPoly == poly[4])
        {
            AllFalse();
            poly[4].active = true;
            nowPoly.GetComponent<Animator>().Play("7_6");
            lastPoly = 6;
            nowPoly = poly[3];
        }
        TouchReceiver.IsDetached = false;
    }
	
}
