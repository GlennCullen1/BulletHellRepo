using UnityEngine;
using System.Collections;

public class BasicReflectProfile : ReflectProfile {
    
    void Start()
    {

    }


    public override ReflectInfo Reflect(GameObject Bullet)
    {
        ReflectInfo returnValue = new ReflectInfo();


        returnValue.ReflectVector = gameObject.transform.right.normalized * m_VelocityScale;
        returnValue.TeamId = m_TeamID;
        return returnValue;
    }

    public override ReflectInfo Reflect(GameObject Bullet,Collision2D col)
    {
        ReflectInfo returnValue = new ReflectInfo();
        return returnValue = new ReflectInfo();
    }
    
}
