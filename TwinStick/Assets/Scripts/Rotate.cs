﻿using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

    public float m_speed = 3.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0f, 0f, m_speed * Time.deltaTime);
	}
}
