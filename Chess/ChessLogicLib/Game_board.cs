using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PieceClassesLib;


// List of all methods

/*public void create_empty_board()
public void set_the_pieces_on_board()
public void print_board_pieces()
public bool are_there_pieces_on_the_road(int from_x, int from_y, int to_x, int to_y)
public bool general_move_conditions(int from_x, int from_y, int to_x, int to_y)
public bool is_move_possible(int from_x, int from_y, int to_x, int to_y)
public void add_attack_list_to_piece(int from_x, int from_y)
public void add_attack_list_to_all_pieces()
public void reset_attack_list_of_all_pieces()
public void print_attack_list_of_all_pieces()
public List<PieceAbstract> return_list_of_WorB_color_pieces(string color)
public List<Tuple<int, int>> attack_list_of_white_or_black(string color)
public Tuple<int, int> return_your_kings_position()
public void change_turn()
public void move_a_piece(int from_x, int from_y, int to_x, int to_y)
public PieceAbstract save_knocked_piece(int to_x, int to_y)
public void player_turn(int from_x, int from_y, int to_x, int to_y)
public string enemy_color()
public bool search_if_players_king_is_checked(List<Tuple<int, int>> enemy_attacklist)
public bool search_for_checkmate_by_enemy()
*/

namespace ChessLogicLib
{
    public class Game_board
    {
        public Square[,] board { get; set; } = new Square[8, 8];
        public string turn;
        public Game_board()
        {
            this.create_empty_board();
            this.set_the_pieces_on_board();
            this.turn = "white";
        }


        public void create_empty_board()
        {
            for (int pos_x = 0; pos_x < 8; pos_x++)
            {
                for (int pos_y = 0; pos_y < 8; pos_y++)
                {
                    PieceAbstract no_piece = new NoPiece(pos_x, pos_y, "No color");
                    Square square = new Square(pos_x, pos_y, no_piece);
                    board[pos_x, pos_y] = square;
                }
            }
        }

        public void set_the_pieces_on_board()
        {
            this.board[0, 0].piece = new Rook(0, 0, "white");
            this.board[7, 0].piece = new Rook(7, 0, "white");
            this.board[0, 7].piece = new Rook(0, 7, "black");
            this.board[7, 7].piece = new Rook(7, 7, "black");

            this.board[1, 0].piece = new Knight(1, 0, "white");
            this.board[6, 0].piece = new Knight(6, 0, "white");
            this.board[1, 7].piece = new Knight(1, 7, "black");
            this.board[6, 7].piece = new Knight(6, 7, "black");

            this.board[2, 0].piece = new Bishop(2, 0, "white");
            this.board[5, 0].piece = new Bishop(5, 0, "white");
            this.board[2, 7].piece = new Bishop(2, 7, "black");
            this.board[5, 7].piece = new Bishop(5, 7, "black");

            this.board[3, 0].piece = new Queen(3, 0, "white");
            this.board[3, 7].piece = new Queen(3, 7, "black");

            this.board[4, 0].piece = new King(4, 0, "white");
            this.board[4, 7].piece = new King(4, 7, "black");

            for (int i = 0; i < 8; i++)
            {
                this.board[i, 1].piece = new Pawn(i, 1, "white");
                this.board[i, 6].piece = new Pawn(i, 6, "black");
            }
        }

        /*posnum
        0             (whitepieces)
        1
        2
        3
        4
        5
        6
        7             (blackpieces)
            a   b   c   d  e   f    g   h poschar
            0   1   2   3  4   5    6   7*/


        //metoda do wypisania w konsoli figur, gdy nie ma GUI
        public void print_board_pieces()
        {
            if (this.board != null)
            {
                for (int pos_y = 0; pos_y < 8; pos_y++)
                {

                    for (int pos_x = 0; pos_x < 8; pos_x++)
                    {
                        Console.Write
                            (
                            this.board[pos_x, pos_y].pos_x.ToString() + ", "
                            + this.board[pos_x, pos_y].pos_y.ToString() + ", "
                            + this.board[pos_x, pos_y].piece.type + ", "
                            + this.board[pos_x, pos_y].piece.color + " "
                            + "      ");

                    }
                    Console.WriteLine();
                }

            }
        }

        public bool are_there_pieces_on_the_road(int from_x, int from_y, int to_x, int to_y)
        {
            List<Tuple<int, int>> squares_on_path = this.board[from_x, from_y].piece.squares_coordinates_on_move_path(to_x, to_y);
            if (squares_on_path.Count() > 0)
            {
                foreach (var pair_of_coord in squares_on_path)
                {
                    if (this.board[pair_of_coord.Item1, pair_of_coord.Item2].piece.type != "NoPiece") return true;
                }
            }
            return false;
        }
        public bool general_move_conditions(int from_x, int from_y, int to_x, int to_y)
        {
            // jesli rusza sie na pole na ktorym jest, fail
            if (from_x == to_x && from_y == to_y)
            {
                //Console.WriteLine("Moves to the spot it is already on. Move cancelled." + from_x + " " + from_y + " to " + to_x + " " + to_y);
                return false;
            }
            // jesli rusza sie poza plansze, fail
            if (to_y < 0 || to_y > 7 || to_x < 0 || to_x > 7)
            {
                //Console.WriteLine("// jesli rusza sie poza plansze, fail" + from_x + " " + from_y + " to " + to_x + " " + to_y);
                return false;
            }
            // jesli ma na drodze inne figury, fail
            if (this.are_there_pieces_on_the_road(from_x, from_y, to_x, to_y))
            {
                //Console.WriteLine("jesli ma na drodze inne figury, fail" + from_x + " " + from_y + " to " + to_x + " " + to_y);
                return false;
            }
            // jesli gracz zbija swoje wlasne figury, fail
            if (this.board[from_x, from_y].piece.color == this.board[to_x, to_y].piece.color)
            {
                //Console.WriteLine(" jesli gracz zbija swoje wlasne figury, fail" + from_x + " " + from_y + " to " + to_x + " " + to_y);
                return false;
            }
            //jesli ruszasz nie swoja figure, fail
            // narazie warunek wystepuje w move_a_piece bo gdy przenosisz tutaj wystepuje problem - psuja sie listy pol atakowanych przez kolor przeciwnika
            // if (this.board[from_x, from_y].piece.color != this.turn) return false;
            return true;
        }

        /// <summary>
        ///  Pawn is a special piece since it is the only piece that moves forward without being able to
        ///  attack forward, and attacks diagonally without being able to move diagonally. This method 
        ///  is created  to avoid differentiating between piece attack and movement for each piece 
        ///  since the distinction only applies to pawns.
        /// </summary>
        /// <param name="from_x"></param>
        /// <param name="from_y"></param>
        /// <param name="to_x"></param>
        /// <param name="to_y"></param>
        /// <param name="pawn"></param>
        /// <returns></returns>
        public bool special_pawn_rule(int to_x, int to_y, Pawn pawn)
        {

            if (pawn.is_moving_forward(to_x, to_y))
            {
                if (this.board[to_x, to_y].piece.type == "NoPiece") return true;
                return false;
            }
            else if (pawn.is_moving_diagonally(to_x, to_y))
            {
                if (this.board[to_x, to_y].piece.color == enemy_color()) return true;
                return false;
            }
            else return false;
        }

        public bool is_move_possible(int from_x, int from_y, int to_x, int to_y)
        {
            bool piece_move_conditions = this.board[from_x, from_y].piece.piece_move_conditions(to_x, to_y);
            bool general_move_conditions = this.general_move_conditions(from_x, from_y, to_x, to_y);
            PieceAbstract moved_piece = this.board[from_x, from_y].piece;
            if (moved_piece is Pawn pawn)
            {
                if (special_pawn_rule(to_x,to_y,pawn) == false) return false;
            }
            return (piece_move_conditions && general_move_conditions);
        }

 
        public void add_attack_list_to_piece(int from_x, int from_y)
        {
            for (int to_x = 0; to_x < 8; to_x++)
            {
                for (int to_y = 0; to_y < 8; to_y++)
                {
                    if (is_move_possible(from_x, from_y, to_x, to_y))
                    {
                        this.board[from_x, from_y].piece.add_to_attack_list(to_x, to_y);
                    }
                }
            }
        }
        public void add_attack_list_to_all_pieces()
        {

            for (int pos_x = 0; pos_x < 8; pos_x++)
            {
                for (int pos_y = 0; pos_y < 8; pos_y++)
                {
                    add_attack_list_to_piece(pos_x, pos_y);
                }
            }
        }

        public void reset_attack_list_of_all_pieces()
        {
            for (int pos_x = 0; pos_x < 8; pos_x++)
            {
                for (int pos_y = 0; pos_y < 8; pos_y++)
                {
                    this.board[pos_x, pos_y].piece.attacklist.Clear();
                    this.add_attack_list_to_piece(pos_x, pos_y);
                }
            }
        }

        public void print_attack_list_of_all_pieces()
        {
            for (int pos_x = 0; pos_x < 8; pos_x++)
            {
                for (int pos_y = 0; pos_y < 8; pos_y++)
                {
                    Console.WriteLine("Lista z " + pos_x + " " + pos_y + " " + this.board[pos_x, pos_y].piece.type + " " +
                          this.board[pos_x, pos_y].piece.color);
                    Console.WriteLine(string.Join(",", this.board[pos_x, pos_y].piece.attacklist));
                }
            }
        }

        public List<PieceAbstract> return_list_of_WorB_color_pieces(string color)
        {
            List<PieceAbstract> list = new List<PieceAbstract>();

            for (int pos_x = 0; pos_x < 8; pos_x++)
            {
                for (int pos_y = 0; pos_y < 8; pos_y++)
                {
                    if (this.board[pos_x, pos_y].piece.color == color)
                    {
                        list.Add(this.board[pos_x, pos_y].piece);
                    }
                }
            }
            return list;
        }

        public List<Tuple<int, int>> attack_list_of_white_or_black(string color)
        {
            List<Tuple<int, int>> all_attack_list = new List<Tuple<int, int>>();

            for (int pos_x = 0; pos_x < 8; pos_x++)
            {
                for (int pos_y = 0; pos_y < 8; pos_y++)
                {
                    if (this.board[pos_x, pos_y].piece.color == color)
                    {
                        List<Tuple<int, int>> piece_attack = this.board[pos_x, pos_y].piece.attacklist;
                        all_attack_list.AddRange(piece_attack);
                    }
                }
            }
            all_attack_list = all_attack_list.Distinct().ToList();
            all_attack_list.Sort();
            return all_attack_list;
        }

        public Tuple<int, int> return_your_kings_position()
        {
            for (int pos_x = 0; pos_x < 8; pos_x++)
            {
                for (int pos_y = 0; pos_y < 8; pos_y++)
                {
                    if (this.board[pos_x, pos_y].piece.type == "King" && this.board[pos_x, pos_y].piece.color == this.turn)
                    {
                        Tuple<int, int> pos = new Tuple<int, int>(pos_x, pos_y);
                        return pos;
                    }
                }
            }
            return null;
        }

        public void change_turn()
        {
            if (this.turn == "white") this.turn = "black";
            else if (this.turn == "black") this.turn = "white";
        }

        public void move_a_piece(int from_x, int from_y, int to_x, int to_y)
        {
            char fromstring = (char)(from_x + 65);
            char tostring = (char)(to_x + 65); 

            Console.WriteLine("Moved piece " + this.board[from_x, from_y].piece.type + ", " + this.board[from_x, from_y].piece.color + " from " + fromstring  +
            from_y + " to " + tostring + to_y + ".");

            this.board[from_x, from_y].piece.pos_x = to_x;
            this.board[from_x, from_y].piece.pos_y = to_y;
            this.board[to_x, to_y].piece = this.board[from_x, from_y].piece;
            this.board[from_x, from_y].piece = new NoPiece(from_x, from_y, "No color");
        }

        public PieceAbstract save_knocked_piece(int to_x, int to_y)
        {
            PieceAbstract saved = this.board[to_x, to_y].piece;
            return saved;
        }

        public bool player_turn(int from_x, int from_y, int to_x, int to_y)
        {
            if ((is_move_possible(from_x, from_y, to_x, to_y) && this.board[from_x, from_y].piece.color == this.turn))
            {
                PieceAbstract knocked_piece = save_knocked_piece(to_x, to_y);
                this.move_a_piece(from_x, from_y, to_x, to_y);
                this.reset_attack_list_of_all_pieces();
                if (this.search_if_players_king_is_checked(this.attack_list_of_white_or_black(this.enemy_color())) == true)
                {
                    this.move_a_piece(to_x, to_y, from_x, from_y);
                    this.board[to_x, to_y].piece = knocked_piece;
                    this.reset_attack_list_of_all_pieces();
                    Console.WriteLine("You cannot make this move since it exposes your king to attack.");
                    return false;
                }
                else
                {                
                    this.change_turn();
                    return true;
                }

            }
            //kolor != turn
            if (this.board[from_x, from_y].piece.color == enemy_color())
            {
                Console.WriteLine("You cant use your opponents pieces.");
            }
            else if(this.board[from_x, from_y].piece.color == "No color")
            {
                Console.WriteLine("You cannot move empty squares.");    
            }
            else
            {
                Console.WriteLine("" + from_x + " " + from_y + " " + to_x + " " + to_y );
                Console.WriteLine("Move according to chess rules");
            }           
            return false;
        }

        public string enemy_color()
        {
            if (this.turn == "white") return "black";
            if (this.turn == "black") return "white";
            return "turn set wrong";
        }
        public bool search_if_players_king_is_checked(List<Tuple<int, int>> enemy_attacklist)
        {
            Tuple<int, int> king_pos = this.return_your_kings_position();
            foreach (Tuple<int, int> position in enemy_attacklist)
            {
                if ((position.Item1 == king_pos.Item1) && (position.Item2 == king_pos.Item2)) return true;
            }
            return false;
        }
        public bool search_for_checkmate_by_enemy()
        {
            for (int from_x = 0; from_x < 8; from_x++)
            {
                for (int from_y = 0; from_y < 8; from_y++)
                {
                    if (this.board[from_x, from_y].piece != null && this.board[from_x, from_y].piece.color == this.turn)
                    {
                        var attackListCopy = new List<Tuple<int, int>>(this.board[from_x, from_y].piece.attacklist);

                        foreach (var targetPosition in attackListCopy)
                        {
                            int to_x = targetPosition.Item1;
                            int to_y = targetPosition.Item2;

                            PieceAbstract capturedPiece = save_knocked_piece(to_x, to_y);

                            //to stop console writing by player_turn method temporarily
                            var originalOut = Console.Out;
                            Console.SetOut(TextWriter.Null);

                            if (player_turn(from_x, from_y, to_x, to_y))
                            {
                                this.change_turn(); 
                                this.move_a_piece(to_x, to_y, from_x, from_y);
                                this.board[to_x, to_y].piece = capturedPiece;
                                reset_attack_list_of_all_pieces();
                                Console.SetOut(originalOut);
                                return false;
                            }
                            Console.SetOut(originalOut);
                        }
                    }
                }
            }
            Console.WriteLine("CHECKMATE!!!!!");
            return true;
        }
    }
}