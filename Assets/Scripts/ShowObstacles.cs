using UnityEngine;

public class ShowObstacles : MonoBehaviour
{
    [SerializeField] Transform[] showObstacles;
    [SerializeField] GameObject obstacle;
    private float time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(time <= 0f){
            int random = Random.Range(0, showObstacles.Length);
            GameObject obstacles = Instantiate(obstacle, showObstacles[random].position, Quaternion.identity);
            Destroy(obstacles, 5f);
            time = 1f;
        }
        else{
            time -= Time.deltaTime;
        }
    }
    
}
