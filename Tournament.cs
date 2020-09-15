using System;
using System.Collections.Generic;
using System.Text;

namespace H1_ProgrammingTest
{
    public class Tournament
    {
        #region Fields
        private List<Hero> heroes;
        private Hero[,] fightGroup = new Hero[4,8]; //row number is stage + 1, col number is the hero position
        private Hero winner;
        private byte stage; //stage 0 = 1/4, stage 1 = semi finals, stage 2 is the final and stage 3 is the tournament is finished
        #endregion

        #region Properties
        /// <summary>
        /// Get a list of all competing heroes
        /// </summary>
        public List<Hero> Heroes
        {
            get
            {
                return heroes;
            }
        }
        /// <summary>
        /// Get the stage of the tournament, stage 0 = 1/4, stage 1 = semi finals, stage 2 is the final and stage 3 is the tournament is finished
        /// </summary>
        public byte Stage
        {
            get
            {
                return stage;
            }
        }
        public Hero Winner
        {
            get
            {
                return winner;
            }
        }
        #endregion

        #region Constructors
        public Tournament(List<Hero> heroes)
        {
            AddHeroes(heroes);
            stage = 0;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Start the next stage
        /// </summary>
        public void StartStage()
        {
            if (stage < 3)
            {
                switch (stage)
                {
                    case 0:
                        Fight(fightGroup[0, 0], fightGroup[0, 1]);
                        Fight(fightGroup[0, 2], fightGroup[0, 3]);
                        Fight(fightGroup[0, 4], fightGroup[0, 5]);
                        Fight(fightGroup[0, 6], fightGroup[0, 7]);
                        break;
                    default:

                        break;
                }
                stage++;
            }
        }
        /// <summary>
        /// Fight method
        /// </summary>
        /// <param name="hero1"></param>
        /// <param name="hero2"></param>
        private void Fight(Hero hero1, Hero hero2)
        {
            bool hero1turn = true;
            bool swingLeft = false;
            int catLiveCounter = 0;
            while (hero1.Alive.Equals("alive") && hero2.Alive.Equals("alive"))
            {
                Random random = new Random();
                //Hero 1
                hero1.CurrentAttack = hero1.Attack[random.Next(0, hero1.Attack.Count)];
                hero1.CurrentDefence = hero1.Defence[random.Next(0, hero1.Defence.Count)];

                random = new Random(); //Generate a new seed
                                       //Hero 2
                hero2.CurrentAttack = hero2.Attack[random.Next(0, hero2.Attack.Count)];
                hero2.CurrentDefence = hero2.Defence[random.Next(0, hero2.Defence.Count)];
                if (hero1turn)
                {
                    switch (hero1.Name)
                    {
                        case "FastCarl":
                            if (swingLeft)
                            {
                                hero1.CurrentAttack = 2;
                                swingLeft = false;
                            }
                            else
                            {
                                hero1.CurrentAttack = 5;
                                swingLeft = true;
                            }
                            break;
                        case "CatTiger":
                            if (catLiveCounter < 9)
                            {
                                hero1.AddHealth = 3;
                                catLiveCounter++;
                            }
                            break;
                    }
                    //Attack
                    hero2.TakeDamage(hero1.CurrentAttack);
                    hero1turn = false;
                }
                else //Hero 2's turn
                {
                    switch (hero2.Name)
                    {
                        case "FastCarl":
                            if (swingLeft)
                            {
                                hero2.CurrentAttack = 2;
                                swingLeft = false;
                            }
                            else
                            {
                                hero2.CurrentAttack = 5;
                                swingLeft = true;
                            }
                            break;
                        case "CatTiger":
                            if (catLiveCounter < 9)
                            {
                                hero2.AddHealth = 3;
                                catLiveCounter++;
                            }
                            break;
                    }
                    //Attack
                    hero1.TakeDamage(hero2.CurrentAttack);
                    hero1turn = true;
                }
            }
        }
        /// <summary>
        /// Internal method to add all heroes to the list
        /// </summary>
        /// <param name="heroes">List of all heroes</param>
        /// <returns></returns>
        private bool AddHeroes(List<Hero> heroes)
        {
            try
            {
                this.heroes = heroes;
                for (int i = 0; i < heroes.Count; i++)
                {
                    fightGroup[0, i] = heroes[i];
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
    }
}
