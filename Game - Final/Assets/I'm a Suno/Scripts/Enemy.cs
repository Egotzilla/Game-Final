using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRigidbody;
    private GameObject player;
    public float speed;

    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRigidbody.AddForce(lookDirection * speed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

}
