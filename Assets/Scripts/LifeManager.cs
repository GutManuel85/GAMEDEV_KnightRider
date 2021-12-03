using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class LifeManager : MonoBehaviour
{

    public GameObject[] lives;
    private int lifeAmount = 3;
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void reduceLife()
    {

        if (lifeAmount == 1)
        {
            Destroy(lives[0]);
            stoppGame();
        }
        else if (lifeAmount == 2)
        {
            Destroy(lives[1]);
        }
        else if(lifeAmount == 3)
        {
            Destroy(lives[2]);
        }

        lifeAmount--;
    }

    private void stoppGame()
    {
        Time.timeScale = 0;
        gameOver.SetActive(true);
    }
}
