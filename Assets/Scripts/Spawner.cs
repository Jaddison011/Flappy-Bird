using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject prefab;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;
    public float originalSpawnRate;

    private void Awake() {
        originalSpawnRate = spawnRate;
        onEnable();
    }

    public void onEnable() {
        InvokeRepeating(nameof(Spawn), originalSpawnRate, originalSpawnRate);
    }

    private void onDisable() {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn() {
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }

    public void ResetSpeed() {
        spawnRate = originalSpawnRate;
    }

    public void IncreaseSpeed() {
        CancelInvoke(nameof(Spawn));
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }
}
