using System;

namespace ZooManager
{
    public class Chick : Bird
    {
        public Chick(string name):base(name)
        {
            emoji = "🐥";
            species = "chick";
            this.name = name;
            reactionTime = new Random().Next(6, 11); // reaction time 6 (fast) to 10 (medium)
        }

        public override void Activate()
        {
            base.Activate();
            Console.WriteLine("I am a chick.");
            Hunt();
        }

        /* Note that our cat is currently not very clever about its hunting.
         * It will always try to attack "up" and will only seek "down" if there
         * is no mouse above it. This does not affect the cat's effectiveness
         * very much, since the overall logic here is "look around for a mouse and
         * attack the first one you see." This logic might be less sound once the
         * cat also has a predator to avoid, since the cat may not want to run in
         * to a square that sets it up to be attacked!
         */
        public override void Hunt()
        {
            if (Game.Seek(location.x, location.y, Direction.up, "cat"))
            {
                this.Retreat(Direction.down);
            }
            else if (Game.Seek(location.x, location.y, Direction.down, "cat"))
            {
                this.Retreat(Direction.up);
            }
            else if (Game.Seek(location.x, location.y, Direction.left, "cat"))
            {
                this.Retreat(Direction.right);
            }
            else if (Game.Seek(location.x, location.y, Direction.right, "cat"))
            {
                this.Retreat(Direction.left);
            }
        }
    }
}

