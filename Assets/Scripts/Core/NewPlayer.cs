using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewPlayer : PhysicsObject
{
    [Header("Attributes")]
    [SerializeField] private float attackDuration = 0.2f;//attack box active for when attacking
    public int attackPower = 25;
    [SerializeField] private float jumpPower = 3;
    [SerializeField] private float maxSpeed = 3;

    [Header("Inventory")]
    public int ammo;
    public float coins = 0;
    public int health = 100;
    public int maxHealth = 100;

    [Header("Refences")]
    [SerializeField] private GameObject attackBox;
    private Vector2 healthBarSize;
    public Dictionary<string, Sprite> inventory = new Dictionary<string, Sprite>();//Dictonary storing all strings and values.
    public Sprite inventoryEmpty;//default icon for inventory
    public Sprite keyGemSprite;//gem icon for inventory
    public Sprite keySprite;//key icon for inventory

    //singleton instantation
    private static NewPlayer instance;
    public static NewPlayer Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        //save the first instance of NewPlayer. Destroy otherwise and telport old player to this player 
        if (instance != null)
        {
            Instance.transform.position = gameObject.transform.position;
            Destroy(gameObject);
        }
        else
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        healthBarSize = GameManager.Instance.healthBar.rectTransform.sizeDelta;
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        targetVelocity = new Vector2(Input.GetAxis("Horizontal") * maxSpeed, 0);
        if(Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpPower;
        }
        if(targetVelocity.x < -.01)
        {
            transform.localScale = new Vector2(-1,1);
        }
        else if (targetVelocity.x > .01)
        {
            transform.localScale = new Vector2(1, 1);
        }
        if(Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(ActiavteAttack());

        }
        if (health <= 0)
            playerDie();
    }


    public IEnumerator ActiavteAttack()
    {
        attackBox.SetActive(true);
        yield return new WaitForSeconds(attackDuration);
        attackBox.SetActive(false);
    }

    public void UpdateUI()
    {
        GameManager.Instance.textCoins.text = coins.ToString();

        GameManager.Instance.healthBar.rectTransform.sizeDelta = new Vector2(healthBarSize.x * ((float)health/(float)maxHealth), GameManager.Instance.healthBar.rectTransform.sizeDelta.y);
    }

    public void playerDie()
    {
        SceneManager.LoadScene("Level1");
    }

    public void AddInventoryItem(string key, Sprite image)
    {
        inventory.Add(key, image);
        GameManager.Instance.invItemImage.sprite = inventory[key];
    }

    public void RemoveInventoryItem(string key)
    {
        inventory.Remove(key);
        GameManager.Instance.invItemImage.sprite = inventoryEmpty;
    }

}
