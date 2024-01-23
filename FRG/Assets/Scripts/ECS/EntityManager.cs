using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoSingleton<EntityManager>
{
    public Entity player;
    public Entity GetPlayer()
    {
        if(player == null)
        {
             player = GameObject.Instantiate( new GameObject("Player")).AddComponent<Entity>();
        }
        return player;
    }
}
