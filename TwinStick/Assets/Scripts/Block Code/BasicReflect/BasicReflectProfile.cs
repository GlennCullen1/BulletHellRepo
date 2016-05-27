﻿using UnityEngine;
using System.Collections;

public class BasicReflectProfile : ReflectProfile {
    
    void Start()
    {

    }

    public override ReflectInfo Reflect(GameObject Bullet)
    {
        ReflectInfo returnValue = new ReflectInfo();

        returnValue.ReflectVector = gameObject.transform.right.normalized;
        returnValue.TeamId = m_TeamID;
        return returnValue;
    }
    
}