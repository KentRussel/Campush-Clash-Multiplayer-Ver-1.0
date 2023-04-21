using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<Player> players;
    public int currentPlayerIndex;
    public int cardsToDraw;
    public int maxHandSize;

    private Deck deck;

    void Awake()
    {
        instance = this;
        deck = FindObjectOfType<Deck>();
    }

    void Start()
    {
        ShuffleDeck();
        DealCards();
        StartGame();
    }

    void ShuffleDeck()
    {
        deck.Shuffle();
    }

    void DealCards()
    {
        for (int i = 0; i < players.Count; i++)
        {
            for (int j = 0; j < maxHandSize; j++)
            {
                players[i].AddCard(deck.DrawCard());
            }
        }
    }

    void StartGame()
    {
        currentPlayerIndex = Random.Range(0, players.Count);
        StartTurn();
    }

    void StartTurn()
    {
        // Determine if the player needs to draw cards
        if (cardsToDraw > 0)
        {
            for (int i = 0; i < cardsToDraw; i++)
            {
                players[currentPlayerIndex].AddCard(deck.DrawCard());
            }
            cardsToDraw = 0;
        }

        // Check if the player needs to discard a card
        while (players[currentPlayerIndex].hand.Count > maxHandSize)
        {
            // Prompt the player to discard a card
            // ...

            // Discard the chosen card
            players[currentPlayerIndex].DiscardCard(cardIndex);
        }

        // Start the player's turn
        players[currentPlayerIndex].StartTurn();
    }

    public void EndTurn()
    {
        currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
        StartTurn();
    }
}

