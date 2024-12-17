using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameController : MonoBehaviour
{
    public List<GameObject> giftParentList;
    public int giftCountTop;
    public int giftCountMid;
    public int giftCountBot;

    public GameObject giftRowTop;
    public GameObject giftRowBot;
    public GameObject giftRowMid;

    public Button restartButton;

    public SpriteRenderer playerSprite;
    float playerPosition;

    public AudioSource backgroundMusic;

    public List<GameObject> giftsList;
    Vector3 positionGifts;
    float positionGiftsY;
    float positionGiftX;
    float positionGiftsZ;

    public void Start()
    {
        restartButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        CheckAmountGiftsLeft();
    }

    void CheckAmountGiftsLeft()
    {
        //count remaining children per row; only access rows that exist
        if (giftParentList.Count >= 3)
        {
            giftCountTop = giftParentList[0].transform.childCount;
            giftCountMid = giftParentList[1].transform.childCount;
            giftCountBot = giftParentList[2].transform.childCount;
        }
        else
        {
            giftCountTop = giftCountMid = giftCountBot = 0;
        }

        //test out: what if all gifts have fallen
        /*giftCountTop = 0;
        giftCountMid = 0;
        giftCountBot = 0;*/

        //show restart button once all gifts are destroyed
        if (giftCountTop == 0 && giftCountMid == 0 && giftCountBot == 0)
        {
            ShowRestartButton();
            backgroundMusic.Stop();
        }
    }

    void ShowRestartButton()
    {
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        //Reset Santa's Position
        playerPosition = playerSprite.transform.position.x;
        playerPosition = 0;

        //Restart Background Music 
        backgroundMusic.time = 0; // Reset playback position to the start
        backgroundMusic.Play();

        //Reset gifts
        float startX = -6f; //starting X position of the left most gift
        float stepX = 1.5f; // distance between gifts

        // Top Row (gifts 0–8)
        for (int i = 0; i < 9; i++)
        {
            // Reassign to Top Row
            giftsList[i].transform.SetParent(giftRowTop.transform);

            // assign previous positions
            positionGifts = new Vector3(startX + (i * stepX), 0, 0);
            giftsList[i].transform.localPosition = positionGifts;
        }

        // Mid Row (gifts 9-17)
        for (int i = 0; i < 9; i++)
        {
            // Reassign to Top Row
            giftsList[i+9].transform.SetParent(giftRowMid.transform);

            // assign previous positions
            positionGifts = new Vector3(startX + (i * stepX), 0, 0);
            giftsList[i+9].transform.localPosition = positionGifts;
        }

        // Bottom Row (gifts 18-26)
        for (int i = 0; i < 9; i++)
        {
            // Reassign to Top Row
            giftsList[i + 18].transform.SetParent(giftRowBot.transform);

            // assign previous positions
            positionGifts = new Vector3(startX + (i * stepX), 0, 0);
            giftsList[i + 18].transform.localPosition = positionGifts;
        }
    }
}
