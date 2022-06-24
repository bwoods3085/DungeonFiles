namespace DungeonLibrary
{
    public class Character
    {
        //Fields
        private int _maxLife;
        private int _life;  
        private string _name;
        private int _hitChance;
        private int _shield;

        //Properties

        public int MaxLife
        {
            get { return _maxLife; }
            set { _maxLife = value; }
        }
        public int Life
        {
            get { return _life; }
            set
            {
                if (value <= MaxLife)
                {
                    _life = value;
                }
                else
                {
                    _life = MaxLife;
                }//End Else

            }//End set
        }//End prop

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int HitChance
        {
            get { return _hitChance; }
            set { _hitChance = value; }
        }
        public int Shield   
        {
            get { return _shield; }
            set { _shield = value; }
        }

        //Ctors
        public Character(int life, int maxLife, string name, int hitChance, int shield)
        {
            Life = life;
            MaxLife = maxLife;
            Name = name;
            HitChance = hitChance;
            Shield = shield;
        }
        public override string ToString()
        {
            return string.Format("<======<({0})>======>\n" +
                "Life: {1} of {2}\nHit Chance: {3}%\n" +
                "Shield: {4}", Name, Life, MaxLife, HitChance, Shield);

        }

        public virtual int CalcShield()
        {
            return Shield;
        }
        public virtual int CalcHitChance()
        {
            return HitChance;
        }
        public virtual int CalcDamage()
        {
            return 0;
        }




    }//End Class
}//End namespace