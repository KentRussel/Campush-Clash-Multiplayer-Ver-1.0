using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string playerName;
    public List<Card> hand;
    public int tokenCount;

    void Start()
    {
        hand = new List<Card>();
        tokenCount = 0;
    }

    public void AddCard(Card card)
    {
        hand.Add(card);
    }

    public void DiscardCard(int index)
    {
        hand.RemoveAt(index);
    }

    public void PlayCard(int index)
    {
        if (index < hand.Count)
        {
            Card card = hand[index];
            if (card is TokenCard)
            {
                TokenCard tokenCard = (TokenCard) card;
                if (tokenCount >= tokenCard.tokenCost)
                {
                    tokenCount -= tokenCard.tokenCost;
                    card.Play();
                    hand.RemoveAt(index);
                }
                else
                {
                    Debug.Log("Not enough tokens to play this card!");
                }
            }
            else
            {
                card.Play();
                hand.RemoveAt(index);
            }
        }
    }

    public void StartTurn()
    {
        // Prompt the player to take their turn
        // ...
    }

    public void EndTurn()
    {
        // End the player's turn
        GameManager.instance.EndTurn();
    }
}


