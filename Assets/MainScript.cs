using UnityEngine;

public class MainScript : MonoBehaviour
{
	public Transform[] cubes;
	
	// Use this for initialization
	void Start () {
		Debug.Log("Hello les 3A AL1 !!! :)"); 
		Debug.Log(cubes.Length);
		Scramble(cubes);
	}

	void Scramble(Transform[] cubes)
	{
		for (var i = 0; i < cubes.Length; i++)
		{
			var rdm = Random.Range(i, cubes.Length);
			Swap(cubes[i], cubes[rdm]);
		}
	}

	void Swap(Transform cube1, Transform cube2)
	{
		var tmp = cube1.position;
		cube1.position = cube2.position;
		cube2.position = tmp;
	}
}
