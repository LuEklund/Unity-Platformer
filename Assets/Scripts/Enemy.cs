using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : PhysicsObject
{
    [SerializeField] private float maxSpeed = 3;

    public int health = 100;

    private RaycastHit2D rightLedgeRaycastHit;
    private RaycastHit2D leftLedgeRaycastHit;
    private RaycastHit2D rightWallRaycastHit;
    private RaycastHit2D leftWallRaycastHit;
    [SerializeField] private Vector2 rayCastOffset;
    [SerializeField] private float rayCastLength = 2;
    [SerializeField] private int enemyDamageDeal = 10;
    [SerializeField] private LayerMask rayCastLayerMask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetVelocity = new Vector2(maxSpeed, 0);

        rightLedgeRaycastHit = Physics2D.Raycast(new Vector2(transform.position.x + rayCastOffset.x, transform.position.y + rayCastOffset.y), Vector2.down, rayCastLength);
        if (rightLedgeRaycastHit.collider == null)
            maxSpeed = -3;

        rightWallRaycastHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.right, rayCastLength, rayCastLayerMask);
        if (rightWallRaycastHit.collider != null)
            maxSpeed = -3;

        leftLedgeRaycastHit = Physics2D.Raycast(new Vector2(transform.position.x - rayCastOffset.x, transform.position.y + rayCastOffset.y), Vector2.down, rayCastLength);
        if (leftLedgeRaycastHit.collider == null)
            maxSpeed = 3;

        leftWallRaycastHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.left, rayCastLength, rayCastLayerMask);
        if (leftWallRaycastHit.collider != null)
            maxSpeed = 3;
        if(health <= 0)
               Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == NewPlayer.Instance.gameObject)
        {
            NewPlayer.Instance.health -= enemyDamageDeal;
            NewPlayer.Instance.UpdateUI();
        }
    }

}
