﻿namespace SiqGames.Entities
{
    public class PlayerPlayer : Entity<int>
    {
       // public int Player1Id { get; set; }
        public Player Player1 { get; set; }
        //public int Player2Id { get; set; }
        public Player Player2 { get; set; }
    }
}
