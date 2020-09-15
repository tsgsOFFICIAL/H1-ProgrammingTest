using System;
using System.Collections.Generic;
using System.Text;

namespace H1_ProgrammingTest
{
    public class Hero
    {
        #region Fields
        private byte hp;
        private bool alive;
        private string name;
        private byte currentAttack;
        private byte currentDefence;
        private List<byte> attack = new List<byte>();
        private List<byte> defence = new List<byte>();
        #endregion

        #region Properties
        /// <summary>
        /// What type of hero
        /// </summary>
        public enum Type
        {
            KongFu,
            SuperDogDino,
            FastCarl,
            VenomousGunner,
            MinimouseMikkel,
            CatTiger,
            RubberGoat,
            MooseEgon
        }
        /// <summary>
        /// Get the living state of the hero
        /// </summary>
        public string Alive
        {
            get
            {
                if (alive)
                {
                    return "alive";
                }
                else
                {
                    return "dead";
                }
            }
        }
        /// <summary>
        /// Get the HP from the hero
        /// </summary>
        public string HP
        {
            get
            {
                return $"{hp} HP";
            }
        }
        public byte AddHealth
        {
            set
            {
                hp = value;
            }
        }
        /// <summary>
        /// Get the name of the Hero
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
        }
        /// <summary>
        /// Get a list of possible attack values
        /// </summary>
        public List<byte> Attack
        {
            get
            {
                return attack;
            }
        }
        /// <summary>
        /// Get a list of possible defence values
        /// </summary>
        public List<byte> Defence
        {
            get
            {
                return defence;
            }
        }
        /// <summary>
        /// Get and set the current attack for the hero
        /// </summary>
        public byte CurrentAttack
        {
            get
            {
                return currentAttack;
            }
            set
            {
                currentAttack = value;
            }
        }
        /// <summary>
        /// Get and set the current defence for the hero
        /// </summary>
        public byte CurrentDefence
        {
            get
            {
                return currentDefence;
            }
            set
            {
                currentDefence = value;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the Hero object
        /// </summary>
        public Hero(Type type)
        {
            switch (type)
            {
                case Type.KongFu:
                    this.hp = 120;
                    this.attack.Add(2);
                    this.defence.Add(5);
                    this.name = Enum.GetName(typeof(Type), type);
                    break;
                case Type.SuperDogDino:
                    this.hp = 70;
                    this.attack.Add(6);
                    this.attack.Add(7);
                    this.attack.Add(8);
                    this.defence.Add(2);
                    this.defence.Add(3);
                    this.defence.Add(4);
                    this.defence.Add(5);
                    this.defence.Add(6);
                    this.defence.Add(7);
                    this.defence.Add(8);
                    this.name = Enum.GetName(typeof(Type), type);
                    break;
                case Type.FastCarl:
                    this.hp = 90;
                    this.attack.Add(5);
                    this.attack.Add(2);
                    this.defence.Add(3);
                    this.name = Enum.GetName(typeof(Type), type);
                    break;
                case Type.VenomousGunner:
                    this.hp = 90;
                    this.attack.Add(1);
                    this.attack.Add(2);
                    this.attack.Add(3);
                    this.attack.Add(4);
                    this.attack.Add(5);
                    this.attack.Add(6);
                    this.attack.Add(7);
                    this.attack.Add(8);
                    this.attack.Add(9);
                    this.attack.Add(10);
                    this.attack.Add(11);
                    this.attack.Add(12);
                    this.attack.Add(13);
                    this.defence.Add(5);
                    this.name = Enum.GetName(typeof(Type), type);
                    break;
                case Type.MinimouseMikkel:
                    this.hp = 40;
                    this.attack.Add(9);
                    this.defence.Add(9);
                    this.name = Enum.GetName(typeof(Type), type);
                    break;
                case Type.CatTiger:
                    this.hp = 35;
                    this.attack.Add(3);
                    this.attack.Add(6);
                    this.defence.Add(4);
                    this.name = Enum.GetName(typeof(Type), type);
                    break;
                case Type.RubberGoat:
                    this.hp = 70;
                    this.attack.Add(6);
                    this.defence.Add(8);
                    this.name = Enum.GetName(typeof(Type), type);
                    break;
                case Type.MooseEgon:
                    this.hp = 90;
                    this.attack.Add(5);
                    this.attack.Add(6);
                    this.attack.Add(7);
                    this.attack.Add(8);
                    this.attack.Add(9);
                    this.attack.Add(10);
                    this.attack.Add(11);
                    this.defence.Add(4);
                    this.name = Enum.GetName(typeof(Type), type);
                    break;
            }
            alive = true;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Take damage
        /// </summary>
        /// <param name="damage">damage amount</param>
        /// <returns>This method return true or false depending on if the hero died, taking the damage</returns>
        public void TakeDamage(int damage)
        {
            int difference = currentDefence - damage;
            if (difference > 0)
            {
                difference = 0;
            }

            if (difference < 0)
            {
                difference = difference * -1;
            }

            hp = (byte)(hp - difference);
            if (hp <= 0)
            {
                alive = false;
            }
        }
        #endregion
    }
}
