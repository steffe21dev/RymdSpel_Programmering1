using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RymdSpel
{
    class Player
    {
        public Vector2 pos { get; set; }
        public Rectangle rec { get; set; }
        public int hp = 100;


        public Player(Vector2 pos, Rectangle rec, int hp)
        {
            this.pos = pos;
            this.rec = rec;
            this.hp = hp;
        }


        public void UpdateRectangle()
        {
            //Säger att rektangelns nya position ska vara vid Vector2 positionen både på x och y led, 64x64 är rektangelns storlek
            rec = new Rectangle((int)pos.X, (int)pos.Y, 64, 64);
        }


    }
}
