using UnityEngine;
using System.Collections;

public class HomingReflect : ReflectProfile{

	public override ReflectInfo Reflect(GameObject Bullet, Collision2D col)
	{
		ReflectInfo returnValue = new ReflectInfo();
        TeamManager team = GameObject.FindGameObjectWithTag("Manager").GetComponent<TeamManager>();
        int enemyTeam = transform.root.GetComponentInChildren<CharacterRecord>().m_TeamID == 1 ? 0:1;
        GameObject target = team.FindClosestEnemy(Bullet, enemyTeam, true);

        //Bullet.transform.LookAt(target.transform.position);
        returnValue.ReflectVector = target.transform.position - Bullet.transform.position ;
        returnValue.ReflectVector.Normalize();

        returnValue.TeamId = transform.root.GetComponentInChildren<CharacterRecord>().m_TeamID;
		return returnValue;
	}
	
	public override ReflectInfo Reflect(GameObject Bullet)
	{
        ReflectInfo returnValue = new ReflectInfo();
        TeamManager team = GameObject.FindGameObjectWithTag("Manager").GetComponent<TeamManager>();
        int enemyTeam = transform.root.GetComponentInChildren<CharacterRecord>().m_TeamID == 1 ? 0 : 1;
        GameObject target = team.FindClosestEnemy(Bullet, enemyTeam, true);

        //Bullet.transform.LookAt(target.transform.position);
        returnValue.ReflectVector = target.transform.position - Bullet.transform.position;
        returnValue.ReflectVector.Normalize();

        returnValue.TeamId = transform.root.GetComponentInChildren<CharacterRecord>().m_TeamID;
        return returnValue;
	}

}
