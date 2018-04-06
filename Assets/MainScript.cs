using System.Collections;
using UnityEngine;

public class MainScript : MonoBehaviour
{
	public Transform[] cubes;
	
	// Use this for initialization
	IEnumerator Start () {
		Debug.Log("Avant Mélange : " + GetError(cubes));
		yield return StartCoroutine(Scramble(cubes));
		Debug.Log("Après Mélange : " + GetError(cubes));
	}

	IEnumerator Scramble(Transform[] cubes)
	{
		for (var i = 0; i < cubes.Length; i++)
		{
			var rdm = Random.Range(i, cubes.Length);
			Swap(cubes[i], cubes[rdm]);
			yield return null;
		}
	}

	void Swap(Transform cube1, Transform cube2)
	{
		var tmp = cube1.position;
		cube1.position = cube2.position;
		cube2.position = tmp;
	}

	int GetError(Transform[] cubes)
	{
		var error = 0;

		foreach (var cube1 in cubes)
		{
			foreach (var cube2 in cubes)
			{
				if (cube1.tag == cube2.tag && cube1.position.y != cube2.position.y)
				{
					error++;
				}
			}
		}

		return error;
	}
}
