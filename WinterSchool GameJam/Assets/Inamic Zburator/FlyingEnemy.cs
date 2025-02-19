using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public float speed;
    private GameObject player;
    public bool chase = false;
    public Transform startingPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if(player==null)
        return;
        if(chase==true)
        Chase();
        else
        {
        ReturnStart();
        }
    }

    private void ReturnStart()
    {
    transform.position=Vector2.MoveTowards(transform.position,startingPoint.position,speed*Time.deltaTime);
    }

    private void Chase()
    {
        transform.position=Vector2.MoveTowards(transform.position,player.transform.position,speed* Time.deltaTime);
    }
}
