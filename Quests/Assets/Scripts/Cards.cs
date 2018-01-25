using System;

public abstract class Card { 
    protected string name;
    
    protected Card(string name) {
        this.name = name;
    }

    public string Name {
        get
        {
            return name;
        }
    }
}

public abstract class AdventureCard : Card {
    protected int bp;
    protected int bids;
    public int BP { 
        get {
            return bp;
        }
    }
    public int Bids {
        get {
            return bids;
        }
    }

    protected AdventureCard(string name, int bp, int bids) 
        : base(name) {
        this.bp = bp;
        this.bids = bids;
    }

    virtual public int getBP(Quest currQuest) {
        return bp;
    }

    virtual public int getBids(Quest currQuest) {
        return bids;
    }

}

public class Foe : AdventureCard {
    private int specialBP;
    private string specialQuest;


    public Foe(string name, int bp, int bids, int specialBP, string specialQuest)
        : base(name, bp, bids) {
        this.specialBP = specialBP;
        this.specialQuest = specialQuest;
    }
}

public class Test : AdventureCard {
    private int specialBids;
    private string specialQuest;


    public Test(string name, int bp, int bids, int specialBids, string specialQuest)
        : base(name, bp, bids) {
        this.specialBids = specialBids;
        this.specialQuest = specialQuest;
    }

    public override int getBids(Quest currQuest){
        return (currQuest.Name == specialQuest) ? specialBids : bids;
    }

}

public class Ally : AdventureCard {
    private int specialBP;
    private int specialBids;
    private string specialQuest;

    public Ally(string name, int bp, int bids, int specialBP, int specialBids, string specialQuest)
        : base(name, bp, bids) {
        this.specialBP = specialBP;
        this.specialBids = specialBids;
        this.specialQuest = specialQuest;
    }

    public override int getBP(Quest currQuest){
        return (currQuest.Name == specialQuest) ? specialBP : bp;
    }

    public override int getBids(Quest currQuest){
        return (currQuest.Name == specialQuest) ? specialBids : bids;
    }
}

public class Amour : AdventureCard {
    public Amour(string name, int bp, int bids)
        : base(name, bp, bids) { }

}

public class Weapon : AdventureCard {
    public Weapon(string name, int bp, int bids)
        : base(name, bp, bids) { }
}

public abstract class StoryCard : Card {
    protected StoryCard(string name) : base(name) { }

}

public abstract class Event : StoryCard {

    public Event(string name) : base(name) { }

    public abstract void play();
}

public class ChivalrousDeed : Event {

    public ChivalrousDeed() : base("Chivalrous Deed") { }

    public override void play(){

    }
}

public class Tournament : StoryCard {
    private int shields;
    public int Shields{
        get{
            return shields;
        }
    }

    public Tournament(string name, int shields) 
        : base(name) { 
         this.shields = shields;
    }
}

public class Quest : StoryCard {
    private int stages;
    public int Stages {
        get {
            return stages;
        }
    }

    public Quest(string name, int stages) : base(name) {
        this.stages = stages;
    }
}
