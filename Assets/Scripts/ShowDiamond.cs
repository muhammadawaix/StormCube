using UnityEngine;

public class ShowDiamond : MonoBehaviour
{
    [SerializeField] Transform[] showDimond;
    [SerializeField] GameObject dimond;
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
            int random = Random.Range(0, showDimond.Length);
            GameObject dimonds = Instantiate(dimond, showDimond[random].position, Quaternion.identity);
            Destroy(dimonds, 5f);
            time = 5f;
        }
        else{
        time -= Time.deltaTime;
        }
    }
}
