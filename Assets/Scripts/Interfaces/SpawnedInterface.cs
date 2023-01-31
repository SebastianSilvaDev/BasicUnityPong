using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawnedControllerInterface
{
    void ISetSpawner(Spawners.BaseSpawnerComponent spawner);

    void IRequestReespawn();
}
