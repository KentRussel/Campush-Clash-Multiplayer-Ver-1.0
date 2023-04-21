using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<Card> cards;
    
    void Awake()
    {
        cards = new List<Card>();
        AddCardsOfType(typeof(AttackCardStereotype), 3);
        AddCardsOfType(typeof(AttackCardPersonal), 3);
        AddCardsOfType(typeof(DefenseCard), 3);
        AddCardsOfType(typeof(PowerCard), 2);
        AddCardsOfType(typeof(ItemCardTier1), 5);
        AddCardsOfType(typeof(ItemCardTier2), 3);
        AddCardsOfType(typeof(ItemCardTier3), 1);
        
        Shuffle();
    }
    
    void AddCardsOfType(System.Type type, int count)
    {
        var prefab = Resources.Load<GameObject>(type.Name);
        for (int i = 0; i < count; i++)
        {
            var instance = Instantiate(prefab).GetComponent<Card>();
            cards.Add(instance);
        }
    }
    
    void Shuffle()
    {
        System.Random random = new System.Random();
        for (int i = 0; i < cards.Count; i++)
        {
            int randomIndex = random.Next(i, cards.Count);
            Card temp = cards[i];
            cards[i] = cards[randomIndex];
            cards[randomIndex] = temp;
        }
    }
    Card DrawCard()
    {
        if (cards.Count == 0)
        {
            // If there are no more cards in the deck, shuffle the discard pile
            cards.AddRange(discardPile);
            discardPile.Clear();
            Shuffle();
        }
        
        // Draw the top card from the deck and remove it from the cards list
        Card drawnCard = cards[0];
        cards.RemoveAt(0);
        return drawnCard;
    }
    
    void DiscardCard(Card card)
    {
        // Add the card to the discard pile
        discardPile.Add(card);
    }
}


