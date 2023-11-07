using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _gold;
    [SerializeField] private GameObject[] _positions;

    private float _spawnTime;

    public float timeBetweenSpawn;
    private GameManager _gameManager;
    private void Start()
    {
        _gameManager = FindAnyObjectByType<GameManager>();

    }
    private void Update()
    {
        if (Time.time > _spawnTime)
        {
            Spawn();
            _spawnTime = Time.time + timeBetweenSpawn;
        }

    }
    private void Spawn()
    {
        int randomPos = Random.Range(0, _positions.Length);
        Instantiate(_gold, _positions[randomPos].transform.position, transform.localRotation);
    }
}
