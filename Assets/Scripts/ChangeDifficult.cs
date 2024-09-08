using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeDifficult : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    public int difficulty;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficult);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    
    void SetDifficult()
    {
        Debug.Log(gameObject.name + "clicked");
        gameManager.GetStart(difficulty);
    }
}
