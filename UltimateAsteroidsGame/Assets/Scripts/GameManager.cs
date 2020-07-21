using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Player")]
    public PlayerController player;
    public int lives;

    [Header("UI")]
    public List<Sprite> livesUI;    //lives correspond to index, i.e. 0 live - 0 index
    public Image livesCountImage;

    [Header("Spawning")]
    public GameObject spawner;
    public float spawnRadius;

    [Header("Asteroids")]
    public List<GameObject> asteroidPrefabs;
    public int asteroidsInLevel;


    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if(asteroidsInLevel < 3)
        {
            SpawnAsteroids();
        }
    }

    //Spawn an asteroid
    public void SpawnAsteroids()
    {
        //move the spawner to a random location
        spawner.transform.position = Random.insideUnitCircle * spawnRadius;

        //pick a random prefab from the list of prefabs
        int random = Random.Range(0, asteroidPrefabs.Count);

        //spawn an asteroid
        Instantiate(asteroidPrefabs[random], spawner.transform.position, Quaternion.identity);

        //increase the number of asteroids in our level
        asteroidsInLevel++;
    }

    void LoseALife()
    {
        if(lives - 1 < 0)
        {
            //Gameover
        }
        else
        {
            //decrease lives count
            lives--;
            UpdateLifeUI();
        }
    }

    void UpdateLifeUI()
    {
        //change life image to correspoding number
        livesCountImage.sprite = livesUI[lives];
    }

    public void Respawn()
    {
        //lose a life
        LoseALife();

        //reset the position of the player to the center of the world
        player.gameObject.transform.position = Vector3.zero;
    }
}
