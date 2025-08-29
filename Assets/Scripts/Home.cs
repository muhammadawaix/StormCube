using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    [SerializeField] GameObject option;
    [SerializeField] GameObject soundOn;
    [SerializeField] GameObject soundOff;
    [SerializeField] TextMeshProUGUI dimondText;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip button;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dimondText.text = PlayerPrefs.GetInt("Diamond", 0).ToString();
        option.SetActive(false);
        // audioSource.Play();
        if(PlayerPrefs.GetInt("Sound", 0) == 1){
            soundOn.SetActive(true);
            soundOff.SetActive(false);
            audioSource.Play();
        }
        else{
            soundOff.SetActive(true);
            soundOn.SetActive(false);
            audioSource.Stop();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }


    public void GetButton(string name){
        if(name == "Play"){
            SceneManager.LoadScene(1);
            if (PlayerPrefs.GetInt("Sound", 0) == 1)
            {
                audioSource.PlayOneShot(button);
            }
        }
        else if(name == "Options"){
            option.SetActive(true);
            if(PlayerPrefs.GetInt("Sound", 0) == 1){
            audioSource.PlayOneShot(button);
            }
        }
        else if(name == "Exit"){
            option.SetActive(false);
            if(PlayerPrefs.GetInt("Sound", 0) == 1){
            audioSource.PlayOneShot(button);
            }
        }
        else{
            Debug.Log("Button Error");
        }
    }


    public void SoundOn(){
        soundOff.SetActive(true);
        soundOn.SetActive(false);
        audioSource.Stop();
        PlayerPrefs.SetInt("Sound", 0);
    }
    public void SoundOff(){
        soundOn.SetActive(true);
        soundOff.SetActive(false);
        audioSource.Play();
        PlayerPrefs.SetInt("Sound", 1);
    }
}
