using UnityEngine;
using System.Collections;

public class HomingReflect : MonoBehaviour {

	public override ReflectInfo Reflect(GameObject Bullet, Collision2D col)
	{
		ReflectInfo returnValue = new ReflectInfo();


		return returnValue;
	}
	
	public override ReflectInfo Reflect(GameObject Bullet)
	{
		ReflectInfo returnValue = new ReflectInfo();
		return returnValue;
	}

}
