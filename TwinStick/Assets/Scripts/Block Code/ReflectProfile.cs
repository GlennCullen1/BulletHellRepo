/* ReflectProfile.cs
 * Abstract class to provide information to bullets about how they should reflect
 * Includes an output member that takes all reflect info and returns a reflection variable */

using UnityEngine;
using System.Collections;

public abstract class ReflectProfile : MonoBehaviour {

    //variables
    public int m_VelocityScale; //Percentage change of bullet after reflection
    public int m_TeamID; //team ID of the blocker;

    //methods
    public abstract ReflectInfo Reflect(GameObject Bullet);
    
}

//record class for relfect implementation
public class ReflectInfo
{
    public Vector2 ReflectVector; //UNIT vector that the bullet should now be traveling down

    public int TeamId; // the new Bullet ID;
}
