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
}

public class Foe : AdventureCard {
    private int specialBP;
    private string specialQuest;

    public int SpecialBP {
        get {
            return specialBP;
        }
    }

    public Foe(string name, int bp, int bids, int specialBP, string specialQuest)
        : base(name, bp, bids) {
        this.specialBP = specialBP;
        this.specialQuest = specialQuest;
    }

    public bool hasSpecial(){
        return (specialQuest != null);
    }
}

public class Test : AdventureCard {
    private int specialBids;
    private string specialQuest;

    public int SpecialBids {
        get {
            return specialBids;
        }
    }

    public Test(string name, int bp, int bids, int specialBids, string specialQuest)
        : base(name, bp, bids) {
        this.specialBids = specialBids;
        this.specialQuest = specialQuest;
    }

    public bool hasSpecial(){
        return (specialQuest != null);
    }
}

public class Ally : AdventureCard {
    private int specialBP;
    private int specialBids;
    private string specialQuest;

    public int SpecialBP {
        get
        {
            return specialBP;
        }
    }
    public int SpecialBids {
        get {
            return specialBids;
        }
    }

    public bool hasSpecial(){
        return (specialQuest != null);
    }

    public Ally(string name, int bp, int bids, int specialBP, int specialBids, string specialQuest)
        : base(name, bp, bids) {
        this.specialBP = specialBP;
        this.specialBids = specialBids;
        this.specialQuest = specialQuest;
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

public class Event : StoryCard {
    public Event(string name) : base(name) { }
}

public class Tournament : StoryCard {
    public Tournament(string name) : base(name) { }
}

public class Quest : StoryCard {
    public Quest(string name) : base(name) { }
}
