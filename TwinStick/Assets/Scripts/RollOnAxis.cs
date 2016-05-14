using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class RollOnAxis : MonoBehaviour {

    public string m_rollInput = "Dodge";
    public bool m_immune = false;
    public bool m_roll = false;

    Animator m_anim;
    Rigidbody2D m_rb2d;

    void Start()
    {
        m_anim = GetComponent<Animator>();
        m_rb2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
