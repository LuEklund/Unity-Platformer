using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Collectable : MonoBehaviour
{
    enum Colletables
    {
        Coin,
        Health,
        Ammo,
        Inventory
    }
    [SerializeField]    private Colletables collect;
    [SerializeField]    private string colletableName;
    [SerializeField]    private Sprite colletableSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == NewPlayer.Instance.gameObject) {
            NewPlayer playerScript = collision.gameObject.GetComponent<NewPlayer>();
            switch (collect)
            {
                case Colletables.Coin:
                        playerScript.coins += 1;
                    break;
                case Colletables.Health:
                    if(playerScript.health < playerScript.maxHealth)
                        playerScript.health += 1;
                    break;
                case Colletables.Ammo:
                    playerScript.ammo += 1;
                    break;
                case Colletables.Inventory:
                    playerScript.AddInventoryItem(colletableName, colletableSprite);
                    break;
                default:
                    break;
            }
            playerScript.UpdateUI();
            Destroy(gameObject);
        }
    }

}
