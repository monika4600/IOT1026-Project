using MinotaurLabyrinth;

namespace MinotaurLabyrinthTest
{
    [TestClass]
    public class RoomTests
    {
        [TestMethod]
        public void PitRoomTest()
        {
            RandomNumberGenerator.SetSeed(1);

            Pit pitRoom = new Pit();
            Hero hero = new Hero();
            Map map = new Map(1, 1);

            pitRoom.Activate(hero, map);
            Assert.AreEqual(pitRoom.IsActive, false);
            Assert.AreEqual(hero.IsAlive, true);

            hero.HasSword = true;
            pitRoom.Activate(hero, map);
            //hero should not die because pitroom is inactive here
            Assert.AreEqual(hero.IsAlive, true);

            pitRoom newPitRoom = new pitRoom();
            newPitRoom.Activate(hero, map);
            Assert.AreAqual(hero.IsAlive, false);            
        }

        [TestMethod]
        public void ChamberOfShadowsTest()
        {
            ChamberOfShadows chamber = new ChamberOfShadows();
            Hero hero = new Hero();
            Map map = new Map(1, 1);

            chamber.Activate(hero, map);   
            Assert.AreEqual(chamber.IsActive, false);
            Assert.AreEqual(hero.HasTorch, true);

            chamber.Activate(hero, map);
            Assert.AreEqual(hero.HasTorch, true);
        }
    }

    [TestClass]
    public class MonsterTests
    {
        [TestMethod]
        public void MinotaurTest()
       {
            Hero hero = new Hero();
            Minotaur minotaur = new Minotaur();
            Map map = new Map(4, 4);
            hero.HasSword = true;
            Assert.AreEqual(hero.HasSword, true);

            minotaur.Activate(hero, map);
            //Charge moves the hero 1 room east and 2 rooms north
            //-1 is off the map so hero position should be (0, 2);
            Assert.AreEqual(hero.Location, new Location(0, 2));
            Assert.AreEqual(hero.HasSword, false);

            minotaur.Activate(hero, map);
            Assert.AreEqual(hero.Location, new Location(0,3));

            hero.Location = new Location(3, 1);
            minotaur.Activate(hero, map);
            Assert.AreEqual(hero.Location, new Location(2, 3));
        }
    }
}
