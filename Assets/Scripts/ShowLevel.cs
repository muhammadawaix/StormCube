using UnityEngine;

public class ShowLevel : MonoBehaviour
{
    [SerializeField] Transform showLevel;
    [SerializeField] GameObject level;
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
            if(GamePlay.instance.count >= 5){
            GameObject obstacles = Instantiate(level, showLevel.position, Quaternion.identity);
            Destroy(obstacles, 5f);
            time = 100f;
            }
        }
        else{
            time -= Time.deltaTime;
        }
    }
}
