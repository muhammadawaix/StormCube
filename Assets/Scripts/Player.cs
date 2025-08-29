using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed;
    private Touch touch;
    private bool hasGameOver;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = 0.008f;
        hasGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && !hasGameOver){
            touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Moved){
                transform.position = new Vector2(transform.position.x + touch.deltaPosition.x * speed, transform.position.y + touch.deltaPosition.y * speed);
            }
        }

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, -2.02f, 2.02f);
        pos.y = Mathf.Clamp(transform.position.y, -4.72f, 4.72f);
        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.tag == "Obstacle")
        {
            GamePlay.instance.GameOver();
            hasGameOver = true;
        }
        if(collider.gameObject.tag == "Level"){
            GamePlay.instance.LevelCount();
        }
    }
}
