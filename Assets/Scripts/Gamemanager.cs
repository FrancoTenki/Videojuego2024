
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    private GameData gamedata;
    private GameRepository gameRepository;

    
    private TMP_Text lifeText;
    private TMP_Text manaText;

    // public RawImage vida;

    void Start()
    {
        
        gameRepository = new GameRepository();
        gamedata=gameRepository.LoadGame();

        lifeText=GameObject.Find("TextVida").GetComponent<TextMeshProUGUI>();
        manaText=GameObject.Find("TextMana").GetComponent<TextMeshProUGUI>();
        // vida=GameObject.Find("VidaBarra").GetComponent<RawImage>();

        // float healthPercentage = gamedata.life / 100;
        // vida. = healthPercentage;
    }

    public void RemoveLife(GameObject play){
        gamedata.life -=10;
        gameRepository.SaveGame(gamedata);

        if(gamedata.life<=0){
            Destroy(play);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
            gamedata.life=100;
            gamedata.mana=100;
            gameRepository.SaveGame(gamedata);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        lifeText.text="Vida: "+gamedata.life;
        manaText.text="Mana: "+gamedata.mana;
    }
    public long getMana()
    {
        return gamedata.mana;
    }
    public void reduceMana()
    {
        gamedata.mana -=10;
    }
}
