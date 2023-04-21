using UnityEngine;

public class Card : MonoBehaviour
{
    public string cardName;
    public string description;
    public int tier;

    public virtual void Use()
    {
        // Default behavior is to simply discard the card when used
        Deck.instance.DiscardCard(this);
    }
}

public class AttackCardStereotype : Card
{
    public int stereotypeDamage;

    public override void Use()
    {
        // Reduce the health of the targeted player by the stereotype damage
        // ...

        // Discard the card
        base.Use();
    }
}

public class AttackCardPersonal : Card
{
    public int personalDamage;

    public override void Use()
    {
        // Reduce the health of the targeted player by the personal damage
        // ...

        // Discard the card
        base.Use();
    }
}

public class DefenseCard : Card
{
    public int defenseAmount;

    public override void Use()
    {
        // Increase the defense of the player for one turn by the defense amount
        // ...

        // Discard the card
        base.Use();
    }
}

public class PowerCard : Card
{
    public override void Use()
    {
        // Perform some powerful game-changing action
        // ...

        // Discard the card
        base.Use();
    }
}

public class ItemCardTier1 : Card
{
    public int itemEffect;

    public override void Use()
    {
        // Apply the item effect to the player
        // ...

        // Discard the card
        base.Use();
    }
}

public class ItemCardTier2 : Card
{
    public int itemEffect;

    public override void Use()
    {
        // Apply the item effect to the player
        // ...

        // Discard the card
        base.Use();
    }
}

public class ItemCardTier3 : Card
{
    public int itemEffect;

    public override void Use()
    {
        // Apply the item effect to the player
        // ...

        // Discard the card
        base.Use();
    }
}


