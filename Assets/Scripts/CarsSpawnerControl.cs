using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsSpawnerControl : MonoBehaviour {

	public Transform[] spawnPointsCars;
	public GameObject[] cars;
	public Transform[] spawnPointsBikes;
	public GameObject bike;


	int randomSpawnPoint, randomMonster;
	public static bool spawnAllowed;

	int lastPoint, lastUpPoint, upSpawn, countRepeat;

	// Use this for initialization
	void Start () {
		lastPoint = -1;
		upSpawn = -1;
		spawnAllowed = true;
		upSpawn = Random.Range (3, 5);
		lastUpPoint = upSpawn;
		InvokeRepeating ("SpawnAMonster", 0f, 10f);
	}

	void SpawnAMonster()
	{
		if (spawnAllowed) {
			do{
				randomSpawnPoint = Random.Range (0, 3);
			}while (randomSpawnPoint == lastPoint);
			lastPoint = randomSpawnPoint;
			randomMonster = Random.Range (0, 2);
			Instantiate (cars [randomMonster], spawnPointsCars[randomSpawnPoint].position, Quaternion.identity);

			randomSpawnPoint = Random.Range (0, 2);
			Instantiate (bike, spawnPointsBikes[randomSpawnPoint].position, Quaternion.identity);

		}
		
	}

}
