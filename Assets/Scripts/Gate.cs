using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private string requiredInventoryItemString;
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
        if (collision.gameObject == NewPlayer.Instance.gameObject)
        {
            NewPlayer playerScript = collision.gameObject.GetComponent<NewPlayer>();
            if(playerScript.inventory.ContainsKey(requiredInventoryItemString))
            {
                playerScript.RemoveInventoryItem(requiredInventoryItemString);
                Destroy(gameObject);
            }

        }
    }
}
