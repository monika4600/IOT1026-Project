namespace MinotaurLabyrinth
{
   public class ChamberOfShadows : Room
   {
      static ChamberOfShadows()
      {
        RoomFactory.Instance.Register(RoomType.ChamberOfShadows, () => new ChamberOfShadows());  
      }    
               
      public override RoomType Type { get; } = RoomType.ChamberOfShadows;

      public override void Activate(Hero hero, Map map)
      {
        if (IsActive)
        {
          ConsoleHelper.WriteLine("As you enter the chamber, the door slams shut behind you, engulfing the room in complete darkness.", ConsoleColor.DarkGray);
          
          if (hero.HasTorch)
          {
             ConsoleHelper.WriteLine("Luckily, you have a torch, and you quickly light it, illuminating the chamber.", ConsoleColor.Yellow);
          }
          else
          {
            ConsoleHelper.WriteLine("Without a torch, you are left stranded in the pitch-black darkness.", ConsoleColor.DarkRed);            
          }
        }
      }

      public override DisplayDetails Display()
      {
        return new DisplayDetails("C", ConsoleColor.Gray);        
      }

      public override bool DisplaySense(Hero hero, int heroDistance)
      {
        if (heroDistance == 0)
        {
            ConsoleHelper.WriteLine("You are standing in the Chamber of Shadows. The darkness engulfs you.",  ConsoleColor.DarkGray);
            return true;
        }
        else if (heroDistance == 1)
        {
            ConsoleHelper.WriteLine("You sense a chilling presence nearby. The shadows seem to wishper.", ConsoleColor.DarkGray);
            return true;
        }
        else if (heroDistance <= 3)
        {
            ConsoleHelper.WriteLine("You feel the presence of darkness in the distance. It's getting closer.", ConsoleColor.DarkGray);
            return true;
        }
        return false; //Return true if a message was displayed; otherwise, false
      }  
    }
}