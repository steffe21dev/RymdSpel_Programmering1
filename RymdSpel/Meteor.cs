using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RymdSpel
{
    class Meteor
    {
        public Vector2 pos { get; set; }
        public Rectangle rec { get; set; }
        public int hp = 3;


        public Meteor(Vector2 pos, Rectangle rec)
        {
            this.pos = pos;
            this.rec = rec;
        }

        public void UpdateRectangle()
        {
            //Säger att rektangelns nya position ska vara vid Vector2 positionen både på x och y led, 64x64 är rektangelns storlek
            rec = new Rectangle((int)pos.X, (int)pos.Y, 128, 128);
        }

    }
}
