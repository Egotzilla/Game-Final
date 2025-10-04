using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 10, -10);
    /* Vector3(-2.42346263,7.30759048,-9.49757481) */

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;

    }
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }

}
