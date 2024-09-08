using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public List<GameObject> prefabs = new List<GameObject>();
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI theScore;
    public TextMeshProUGUI gameOverText;
    public GameObject mainMenu;
    public GameObject inGame;
    public Button btnRestartGame;

    private int score;
    public bool isGameActive;
    private float spawnRate;

    private Target target;
    void Start()
    {
        mainMenu.gameObject.SetActive(true);
        inGame.gameObject.SetActive(false);
        theScore.gameObject.SetActive(false);

    }

    private void Update()
    {
        if (score < 0)
        {
            GameOver();
        }
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            spawnRate = Random.Range(0.5f, 2f);
            yield return new WaitForSeconds(spawnRate);

            int randomTarget = Random.Range(0, prefabs.Count);

            Instantiate(prefabs[randomTarget], new Vector3(Random.Range(-4.5f, 4.5f), this.transform.position.y, this.transform.position.z), 
                prefabs[randomTarget].transform.rotation);
            yield return null;
        }
    }

    public void ScoreManager(int newScore)
    {
            score += newScore;

        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        inGame.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GetStart(int difficulty)
    {
        spawnRate /= difficulty;
        theScore.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(false);
        isGameActive = true;

        StartCoroutine(SpawnTarget());
        ScoreManager(0);
    }
}
