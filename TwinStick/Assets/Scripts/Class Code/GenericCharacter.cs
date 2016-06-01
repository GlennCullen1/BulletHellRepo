/* GenericCharacter.cs
 * Abstract class to provide genereic methods for each character ability */

using UnityEngine;
using System.Collections;

public abstract class GenericCharacter : MonoBehaviour {
    
    //variables
    public int m_StartingHeatlh;
    public int m_MaxHeatlh;
    public int m_SupportCooldown;
    //methods
    public abstract void Dash();
    public abstract void Block();
    public abstract void Support();
    public abstract void Ultimate();
    
}