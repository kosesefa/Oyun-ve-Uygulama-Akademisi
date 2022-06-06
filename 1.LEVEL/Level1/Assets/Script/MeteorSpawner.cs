using UnityEngine;
public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] AsteroidPrefabs;

    void Start()
    {
        InvokeRepeating("SpawnAsteroids",3f,1f);
    }
    private void Update()
    {
        
    }

    private void SpawnAsteroids()
    {
        for (int i = 0; i < 5; i++)
        {
            var pos = new Vector3(Random.Range(-150, 150), Random.Range(150, 350), Random.Range(-150, 150));
            var chosenAsteroid = AsteroidPrefabs[Random.Range(0, AsteroidPrefabs.Length)];
            var asteroid = Instantiate(chosenAsteroid, pos, Quaternion.Euler(-75, 0, 0));
            //chosenAsteroid.AddComponent<Rigidbody>();
            chosenAsteroid.GetComponent<Rigidbody>().velocity = new Vector3(-4,-4,0);

            // You can still manipulate asteroid afterwards like .AddComponent etc
        }
    }
}