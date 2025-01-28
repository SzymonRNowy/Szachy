using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using PieceClassesLib;

namespace ChessLogicLib
{
    public class Square
    {
        public int pos_x { get; set; }
        public int pos_y { get; set; }
        public PieceAbstract piece { get; set; }

        public Square (int posx,int posy, PieceAbstract piece)
        {
            this.pos_x = posx;
            this.pos_y = posy;
            this.piece = piece;
        }

    }
}
