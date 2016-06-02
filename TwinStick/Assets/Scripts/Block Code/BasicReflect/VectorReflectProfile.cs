using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class VectorReflectProfile : ReflectProfile
{

    void Start()
    {

    }

    public override ReflectInfo Reflect(GameObject Bullet, Collision2D col)
    {
        ReflectInfo returnValue = new ReflectInfo();

        // reflection of vector on plane  −(2(n · v) n − v).  where n = normal vector of plane and v is direction;
        Bullet bullet = Bullet.GetComponent<Bullet>();
        Vector2 n = col.contacts[0].normal;
        Vector2 v = bullet.m_velocity;
        returnValue.ReflectVector = -(2 * Vector2.Dot(n, v) * n - v);
        returnValue.ReflectVector = returnValue.ReflectVector.normalized * m_VelocityScale;
        return returnValue;
    }

    public override ReflectInfo Reflect(GameObject Bullet)
    {
        ReflectInfo returnValue = new ReflectInfo();
        return returnValue;
    }

}

