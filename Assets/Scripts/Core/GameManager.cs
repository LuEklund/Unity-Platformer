using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Image healthBar;
    public Image invItemImage;
    public TextMeshProUGUI textCoins;

    //singelton of Gamemanger to be able to access it from anywhere
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        { 
            return instance;
        }
    }

    private void Awake()
    {
        //save the first instance of gameemanger destoy other wise
        if(instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
