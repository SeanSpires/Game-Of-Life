namespace GameOfLife
{
    public class Life
    {
        private World world { get; set; }

        public void start(int height, int width)
        {
            world = new World(height, width);
            while (true)
            {
                // TODO add delay to tick
                world.Tick();
            }
        }
    }
}