using UnityEngine;

public class Diamond : MonoBehaviour
{   
    private float speed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Player"){
            GamePlay.instance.DimondCount();
            Destroy(this.gameObject);
        }
        if(collider.gameObject.tag == "Obstacle"){
            Destroy(this.gameObject);
        }
    }
}
