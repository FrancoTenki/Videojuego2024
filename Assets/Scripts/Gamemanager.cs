using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    private GameData gamedata;
    private GameRepository gameRepository;

    
    private TMP_Text lifeText;
    void Start()
    {
        gameRepository = new GameRepository();
        gamedata=gameRepository.LoadGame();

        lifeText=GameObject.Find("TextVida").GetComponent<TextMeshProUGUI>();
    }

    public void RemoveLife(GameObject play){
        gamedata.life -=10;
        gameRepository.SaveGame(gamedata);

        if(gamedata.life<=0){
            Destroy(play);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            gamedata.life=100;
            gameRepository.SaveGame(gamedata);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        lifeText.text="Vida: "+gamedata.life;
    }
}
