using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Card
{
    private string cardRank;
    private string cardSuit;
    private int power;
    public Card(string rank,string suit)
    {
        this.cardRank = rank;
        this.cardSuit = suit;
        this.power = (int)Enum.Parse(typeof(Suits), this.cardSuit) + (int)Enum.Parse(typeof(CardRanks), this.cardRank);
    }
    public override string ToString()
    {
        return $"Card name: {this.cardRank} of {this.cardSuit}; Card power: {power}";
    }

}
