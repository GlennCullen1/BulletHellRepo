using UnityEngine;
using System.Collections;

public class CommonMethods : MonoBehaviour {
	
	static public GameObject FindClosestObjectInArray(GameObject originObject, GameObject[] arrayToSearch, bool requireLOS)
	{
		GameObject returnValue = null;
		float lowestDistance = 1000000; // stupid high number to start with;

		foreach(GameObject obj in arrayToSearch)
		{
			float tempDist = Vector3.Distance(originObject.transform.position, obj.transform.position);

			if( tempDist < lowestDistance)// new candidate
			{
				if(requireLOS)
				{
					RaycastHit2D testRay = Physics2D.Linecast(originObject.transform.position, obj.transform.position);
					//in sight
					if(testRay.transform == obj.transform)
					{
						returnValue = obj;
					}

				}
				else
				{
					returnValue = obj;
				}
			}
		}
		return returnValue;
	}
}
