using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface for future Ai implementation common to player and enemy.
/// </summary>
public interface IArtificialIntelligence
{
     void RunDijkstra(Vector3 pos);
}
