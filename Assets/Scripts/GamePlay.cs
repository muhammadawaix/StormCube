using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlay : MonoBehaviour
{
    internal static GamePlay instance;
    [SerializeField] GameObject gameOver;
    [SerializeField] TextMeshProUGUI diamondCount;
    [SerializeField] TextMeshProUGUI levelCount;
    [SerializeField] TextMeshProUGUI totalDiamondCount;
    [SerializeField] TextMeshProUGUI totalLevelCount;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource backgroundSound;
    [SerializeField] AudioClip button;
    [SerializeField] AudioClip gameOverSound;
    [SerializeField] AudioClip diamondSound;
    internal int count;
    internal int level;
    internal float elapsedTime;

    void Awake(){
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOver.SetActive(false);
        level = 1;
        Time.timeScale = 1;
        if (PlayerPrefs.GetInt("Sound", 0) == 1)
        {
            backgroundSound.Play();
        }
        else
        {
            backgroundSound.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        diamondCount.text = count.ToString();
        levelCount.text = "Level " + level.ToString();

        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }


    internal void GameOver(){
        gameOver.SetActive(true);
        Time.timeScale = 0;
        SetDimond();
        if(PlayerPrefs.GetInt("Sound", 0) == 1){
            audioSource.PlayOneShot(gameOverSound);
        }
        backgroundSound.Stop();
        totalDiamondCount.text = count.ToString();
        totalLevelCount.text = "Level " + level.ToString();
    }

    public void GetButton(string name){
        if(name == "RePlay"){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            if(PlayerPrefs.GetInt("Sound", 0) == 1){
            audioSource.PlayOneShot(button);
            }
            Time.timeScale = 1;
        }
        else if(name == "Home"){
            SceneManager.LoadScene(0);
            if (PlayerPrefs.GetInt("Sound", 0) == 1)
            {
                audioSource.PlayOneShot(button);
            }
            Time.timeScale = 1;
        }
        else{
            Debug.Log("Button Error");
        }
    }

    internal void DimondCount(){
        count++;
        if(PlayerPrefs.GetInt("Sound", 0) == 1){
            audioSource.PlayOneShot(diamondSound);
            }
    }
    internal void LevelCount(){
        level++;
    }

    void SetDimond(){
        PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond", 0) + count);
    }
}
