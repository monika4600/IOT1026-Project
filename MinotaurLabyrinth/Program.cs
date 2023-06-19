namespace MinotaurLabyrinth
{
    static class Program
    {
        static void Main()
        {
            ConsoleHelper.Write("Do you want to play a small, medium, or large game? ", ConsoleColor.White);

            // Default game setting in the event user does not input a proper size.
            Size mapSize = Console.ReadLine() switch
            {
                "small" => Size.Small,
                "large" => Size.Large,
                _ => Size.Medium // Make a medium game if input is "medium" or anything else
            };

            RoomFactory.Instance.Register(RoomType.ChamberOfShadows, () => new ChamberOfShadows());

            LabyrinthGame game = new(mapSize, Guid.NewGuid().GetHashCode());

            ProceduralGenerator.Initialize(game.Map);
            
            game.Run();
        }
    }
}
