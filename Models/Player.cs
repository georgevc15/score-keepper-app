using System.Collections.Generic;

namespace ScoreKeeper.Models
{
    public class Player
    {
        public virtual init Id {get;set;}
        
        public virtual string Name {get; set;}
        
        public virtual List<Score> Scores {get; set;}
    }

}