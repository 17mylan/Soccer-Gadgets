using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    // __________________________________________
    // |                                          |
    // |                VARIABLES                 |
    // |__________________________________________|
    public float startSpeed;
    public float extraSpeed;
    public float maxExtraSpeed;
    public bool player1Start = true;
    private int hitCounter = 0;
    private Rigidbody2D rb;
    public TrailRenderer trailRenderer;
    // __________________________________________
    // |                                          |
    // |              MONOBEHAVIOR                |
    // |__________________________________________|
    private void Start(){
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Launch());
    }
    // __________________________________________
    // |                                          |
    // |            PUBLIC FONCTION               |
    // |__________________________________________|
    private void RestartBall(){
        rb.velocity = new Vector2(0, 0);
        transform.position = new Vector2(0, 0);
    }
    public IEnumerator Launch(){
        RestartBall();
        hitCounter = 0;
        yield return new WaitForSeconds(3.2f);
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Pong Game"){
            if (player1Start == true){
                MoveBall(new Vector2(-1, 0));
            }
            else{
                MoveBall(new Vector2(1, 0));
            }
        }
        else{
            MoveBall(new Vector2(-1, 0));
        }
    }
    public void MoveBall(Vector2 direction){
        direction = direction.normalized;
        float ballSpeed = startSpeed + hitCounter * extraSpeed;
        rb.velocity = direction * ballSpeed;
    }
    public void IncreaseHitCounter(){
        if(hitCounter * extraSpeed < maxExtraSpeed){
            hitCounter++;
        }
    }
}
