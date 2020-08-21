using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {


	static public Spawner	S;	//a
	static public List<Boid>	boids;	//b


	[Header("Set in Onspector: Spawning")]
	public GameObject	boidPrefab;	//c
	public Transform	boidAnchor;
	public int		numBoids = 100;
	public float	spawnRadius = 100f;
	public float	spawnDelay = 0.1f;


	[Header("Set in Inspector: Boids")]
	public float	velocity = 30f;
	public float	neighborDist = 30f;
	public float	collDist = 10f;
	public float	velMatching = 10f;
	public float	flockCentering = 0.2f;
	public float	collAvoid = 4f;
	public float	attractPull = 3f;
	public float	attractPush = 2f;
	public float	attractPushDist = 1f;

	void Awake () {

		S = this;	//d

		boids = new List<Boid> ();
		InstantiateBoid ();
	}

	public void InstantiateBoid() {
		GameObject go = Instantiate (boidPrefab);
		Boid b = go.GetComponent<Boid> ();
		b.transform.SetParent (boidAnchor);	//e
		boids.Add (b);
		if (boids.Count < numBoids) {
			Invoke ("InstantiateBoid", spawnDelay);	//f
		}
	}
}


