using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    public int modelToSpwan;
    [SerializeField] private float spawnDuration;
    public enum CHARS
    {
        SKELETON = 1, THYRA = 2, GOAT = 3, COWBOY = 4
    };

    [SerializeField] private GameObject[] charModel;
    [SerializeField] private Transform instancePoint;
    [SerializeField] private Transform spawnPoint;
    private GameObject currentSpawn;


    private void Awake()
    {
        //SpawnModel(modelToSpwan);
    }


    public void SpawnModel(int spawnModel)
    {
        instancePoint = gameObject.transform;
        currentSpawn = Instantiate(charModel[spawnModel], instancePoint);
        ModelToPosition(currentSpawn, spawnPoint);
    }

    private void ModelToPosition(GameObject model,Transform destPosition)
    {
        StartCoroutine(ModelToPositionCoroutine(model, destPosition));
    }


    IEnumerator ModelToPositionCoroutine(GameObject model,Transform destPosition)
    {
        Vector3 currentPos = model.transform.position;
        float timeElapsed = 0f;
        while (timeElapsed < spawnDuration)
        {
            transform.position = Vector3.Lerp(currentPos, destPosition.position, timeElapsed / spawnDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = destPosition.position;

    }


}
