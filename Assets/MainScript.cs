using System.Collections;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    public Transform[] cubes;

    // Use this for initialization
    IEnumerator Start()
    {
        Debug.Log("Avant Mélange : " + GetError(cubes));
        yield return StartCoroutine(Scramble(cubes));
        Debug.Log("Après Mélange : " + GetError(cubes));

        yield return new WaitForSeconds(1f);

        StartCoroutine(NaiveLocalSearch(cubes));
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

    IEnumerator NaiveLocalSearch(Transform[] cubes)
    {
        var currentError = GetError(cubes);

        while (currentError != 0)
        {
            Transform cube1;
            Transform cube2;
            do
            {
                cube1 = cubes[Random.Range(0, cubes.Length)];
                cube2 = cubes[Random.Range(0, cubes.Length)];
            } while (!AreNeighbours(cube1, cube2));

            Swap(cube1, cube2);

            var newError = GetError(cubes);

            if (newError <= currentError)
            {
                currentError = newError;
            }
            else
            {
                Swap(cube1, cube2);
            }

            yield return null;
        }
    }

    bool AreNeighbours(Transform cube1, Transform cube2)
    {
        // L'un au dessus de l'autre
        if (cube1.position.x == cube2.position.x && Mathf.Abs(cube1.position.y - cube2.position.y) == 2f)
        {
            return true;
        }
        
        // Côte à côte
        if (cube1.position.y == cube2.position.y && Mathf.Abs(cube1.position.x - cube2.position.x) == 2f)
        {
            return true;
        }

        return false;
    }
}