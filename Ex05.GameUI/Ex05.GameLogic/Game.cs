using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace B20_Ex02
{
    public class Game
    {
        private const int k_HeightIndex = 0;
        private const int k_WidthIndex = 1;

        private Player m_Player1 = null;
        private Player m_Player2 = null;
        private Cell[,] m_Board = null;

        private List<Cell> m_AvailableCards = null;
        private Dictionary<int, List<Location>> m_SeenCards = null;

        public Game(int[] i_Measurements, List<int> io_Cards, string[] i_Names, Player.ePlayerType[] i_PlayerTypes)
        {
            m_Board = new Cell[i_Measurements[k_HeightIndex], i_Measurements[k_WidthIndex]];
            AvailableCards = new List<Cell>();
            m_Player1 = new Player(i_Names[0], i_PlayerTypes[0]);
            m_Player2 = new Player(i_Names[1], i_PlayerTypes[1]);
            m_SeenCards = new Dictionary<int, List<Location>>();

            initializeBoardAndAvailableCards(io_Cards);
        }

        private void initializeBoardAndAvailableCards(List<int> io_Cards)
        {
            int firstDimLength = m_Board.GetLength(k_HeightIndex);
            int secondDimLength = m_Board.GetLength(k_WidthIndex);
            Random randObj = new Random();

            for (int i = 0; i < firstDimLength; i++)
            {
                for (int j = 0; j < secondDimLength; j++)
                {
                    // Randomizing a card to put in the current location on the board 
                    int indexToAdd = randObj.Next(io_Cards.Count);

                    m_Board[i, j] = new Cell(io_Cards[indexToAdd], new Location(i, j));

                    // Updating boolean state indicates the card is flipped 
                    m_Board[i, j].IsFlipped = false;
                    io_Cards.RemoveAt(indexToAdd);
                    
                    // Initializing available cards storage
                    this.AvailableCards.Add(m_Board[i, j]);
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
        }

        public void UpdateSeenCards(bool i_IsAMatch, params Cell[] i_PairOfCards)
        {
            if (i_IsAMatch == true)
            {
                // In case there's a match we need to remove the elements tha't have been seen
                SeenCards.Remove(i_PairOfCards[0].CellContent);
            }
            else
            {
                AddIfNotInSeenCards(i_PairOfCards[0]);
                AddIfNotInSeenCards(i_PairOfCards[1]);
            }
        }

        public void AddIfNotInSeenCards(Cell i_CardToAdd)
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

        public bool IsLocationInRange(Location i_LocationToCheck)
        {
            bool rowInRange = i_LocationToCheck.Row < m_Board.GetLength(k_HeightIndex) && i_LocationToCheck.Row >= 0;
            bool colInRange = i_LocationToCheck.Col < m_Board.GetLength(k_WidthIndex) && i_LocationToCheck.Col >= 0;
            return rowInRange && colInRange;
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
                return m_Player1;
            }

            set
            {
                m_Player1 = value;
            }
        }

        public Player Player2
        {
            get
            {
                return m_Player2;
            }

            set
            {
                m_Player2 = value;
            }
        }

        public Cell[,] Board
        {
            get
            {
                return m_Board;
            }

            set
            {
                m_Board = value;
            }
        }

        public List<Cell> AvailableCards
        {
            get
            {
                return m_AvailableCards;
            }

            set
            {
                m_AvailableCards = value;
            }
        }

        public Dictionary<int, List<Location>> SeenCards
        {
            get
            {
                return m_SeenCards;
            }

            set
            {
                m_SeenCards = value;
            }
        }

        public void FlipCard(Cell io_CardToFlip)
        {
             int i = io_CardToFlip.Location.Row,
                 j = io_CardToFlip.Location.Col;

            // Flipping Card by logic
            m_Board[i, j].IsFlipped = !m_Board[i, j].IsFlipped;
        }
    }
}
