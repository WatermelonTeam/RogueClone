namespace RogueClone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class MonsterFactory
    {
        private const int MaxMonsterCount = 6;
        private const int MonsterSpawnChance = 20;
        private static Random rand = new Random();

        private int level;
        private List<Monster> monsterList;

        public List<Monster> MonsterList
        {
            get
            {
                return this.monsterList;
            }
            private set
            {
                this.monsterList = value;
            }
        }

        public MonsterFactory(int dungeonLevel)
        {
            this.monsterList = new List<Monster>();
            this.level = dungeonLevel;
        }

        public Board SpawnMonstersOnBoard(Board board)
        {
            for (int i = 0; i < MaxMonsterCount; i++)
            {
                int check = MonsterFactory.rand.Next(0, 100);
                if (check < MonsterSpawnChance)
                {
                    int randomFloor = MonsterFactory.rand.Next(0, board.FreeFloorsPos.Count);
                    AddMonstereToBoard(new Monster("Stupid Monster", board.FloorsPos[randomFloor - 1], level, 100 + 50 * level, 10 + 5 * level, 0), board, randomFloor);
                }
            }
            return board;
        }

        private void AddMonstereToBoard(Monster monster, Board board, int randomFloor)
        {
            monsterList.Add(monster);
            board.PositionableObjects.Add(monster);
            board.FreeFloorsPos.RemoveAt(randomFloor);
        }
    }
}
