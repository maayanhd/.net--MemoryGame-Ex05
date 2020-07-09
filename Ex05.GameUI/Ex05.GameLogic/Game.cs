using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Ex05.GameLogic
{
     public class Game
     {
          private const int k_HeightIndex = 0;
          private const int k_WidthIndex = 1;

          private readonly Player r_Player1 = null;
          private readonly Player r_Player2 = null;
          private readonly Cell[,] r_Board = null;

          private readonly List<Cell> r_AvailableCards = null;
          private readonly Dictionary<int, List<Location>> r_SeenCards = null;

          public event Action<PostGameInfo> GameEnded;

          public event Action<Cell> CardFlipped;
          
          public Game(int[] i_Measurements, List<int> i_Cards, string[] i_Names, Player.ePlayerType[] i_PlayerTypes)
          {
               r_Board = new Cell[i_Measurements[k_HeightIndex], i_Measurements[k_WidthIndex]];
               r_AvailableCards = new List<Cell>();
               r_Player1 = new Player(i_Names[0], i_PlayerTypes[0]);
               r_Player2 = new Player(i_Names[1], i_PlayerTypes[1]);
               r_SeenCards = new Dictionary<int, List<Location>>();

               initializeBoardAndAvailableCards(i_Cards);
          }

          private void initializeBoardAndAvailableCards(List<int> i_Cards)
          {
               int firstDimLength = r_Board.GetLength(k_HeightIndex);
               int secondDimLength = r_Board.GetLength(k_WidthIndex);
               Random randObj = new Random();

               for (int i = 0; i < firstDimLength; i++)
               {
                    for (int j = 0; j < secondDimLength; j++)
                    {
                         // Randomizing a card to put in the current location on the board 
                         int indexToAdd = randObj.Next(i_Cards.Count);

                         r_Board[i, j] = new Cell(i_Cards[indexToAdd], new Location(i, j));

                         // Updating boolean state indicates the card is flipped 
                         r_Board[i, j].IsFlipped = false;
                         i_Cards.RemoveAt(indexToAdd);

                         // Initializing available cards storage
                         this.AvailableCards.Add(r_Board[i, j]);
                    }
               }
          }

          public void UpdateAvailableCards(bool i_IsAMatch, params Cell[] i_PairOfCards)
          {
               // in case there's a match- we'll erase the matching pair from the storage
               if (i_IsAMatch == true)
               {
                    AvailableCards.Remove(i_PairOfCards[0]);
                    AvailableCards.Remove(i_PairOfCards[1]);
               }

               if (AvailableCards.Count == 0)
               {
                    onGameEnded();
               }
          }

          public void UpdateSeenCards(bool i_IsAMatch, params Cell[] i_PairOfCards)
          {
               if (i_IsAMatch == true)
               {
                    // In case there's a match we need to remove the elements that have been seen
                    SeenCards.Remove(i_PairOfCards[0].CellContent);
               }
               else
               {
                    addIfNotInSeenCards(i_PairOfCards[0]);
                    addIfNotInSeenCards(i_PairOfCards[1]);
               }
          }

          private void addIfNotInSeenCards(Cell i_CardToAdd)
          {
               if (SeenCards.TryGetValue(i_CardToAdd.CellContent, out List<Location> keyList))
               {
                    if (keyList.Contains(i_CardToAdd.Location) == false)
                    {
                         keyList.Add(i_CardToAdd.Location);
                    }
               }
               else
               {
                    SeenCards.Add(i_CardToAdd.CellContent, new List<Location>());
                    SeenCards[i_CardToAdd.CellContent].Add(i_CardToAdd.Location);
               }
          }

          public Cell GetCellByLocation(Location i_CardLocation)
          {
               return r_Board[i_CardLocation.Row, i_CardLocation.Col];
          }

          public bool IsThereAMatch(Player io_CurrentPlayer, params Cell[] i_Cards)
          {
               bool isAMatch = false;

               // Checking whether the player has found a pair of cards 
               if (i_Cards[0].CellContent.Equals(i_Cards[1].CellContent))
               {
                    isAMatch = true;
                    io_CurrentPlayer.Score++;
               }

               return isAMatch;
          }

          public bool IsTheGameEnded()
          {
               return AvailableCards.Count == 0;
          }

          public Player Player1
          {
               get
               {
                    return r_Player1;
               }
          }

          public Player Player2
          {
               get
               {
                    return r_Player2;
               }
          }

          public Cell[,] Board
          {
               get
               {
                    return r_Board;
               }
          }

          public List<Cell> AvailableCards
          {
               get
               {
                    return r_AvailableCards;
               }
          }

          private void onCardFlipped(Cell i_FlippedCard)
          {
               if(CardFlipped != null)
               {
                    CardFlipped.Invoke(i_FlippedCard);
               }
          }

          private void onGameEnded()
          {
               if (GameEnded != null)
               {
                    bool isaDraw = Player1.Score == Player2.Score;
                    Player winner = Player1.Score >= Player2.Score ? Player1 : Player2;

                    GameEnded.Invoke(new PostGameInfo(winner, isaDraw));
               }
          }

          internal Dictionary<int, List<Location>> SeenCards
          {
               get
               {
                    return r_SeenCards;
               }
          }

          public void FlipCard(Cell io_CardToFlip)
          {
               int i = io_CardToFlip.Location.Row,
                   j = io_CardToFlip.Location.Col;

               // Flipping Card by logic
               r_Board[i, j].IsFlipped = !r_Board[i, j].IsFlipped;

               onCardFlipped(r_Board[i, j]);
          }
     }
}
