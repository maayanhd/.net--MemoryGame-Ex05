using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using System.Threading;

namespace Ex05.GameLogic
{
     public class Player
     {
          private readonly string r_Name;
          private readonly ePlayerType r_ETypeOfPlayer;
          private int m_Score;

          public enum ePlayerType
          {
               Human,
               Computer
          }

          public Player(string i_PlayerName, ePlayerType i_ETypeOfPlayer)
          {
               r_Name = i_PlayerName;
               r_ETypeOfPlayer = i_ETypeOfPlayer;
               m_Score = 0;
          }

          public int Score
          {
               get
               {
                    return m_Score;
               }

               set
               {
                    m_Score = value;
               }
          }

          public string Name
          {
               get
               {
                    return r_Name;
               }
          }

          public bool IsComputer()
          {
              return this.r_ETypeOfPlayer == ePlayerType.Computer;
          }

          public ePlayerType EPlayerType
          {
               get
               {
                    return r_ETypeOfPlayer;
               }
          }

          public Cell[] ComputerMove(Game i_CurrentGame)
          {
               Location?[] chosenLocation = new Location?[2];
               Cell[] resultMove = new Cell[2];

               // Slowing down "thinking process" of the computer in order to see its turn details
               Thread.Sleep(2000);

               // Checks whether we encountered 2 equal available cards
               foreach (List<Location> item in i_CurrentGame.SeenCards.Values)
               {
                    if (item.Count == 2)
                    {
                        chosenLocation[0] = item[0];
                        chosenLocation[1] = item[1];
                        break;
                    }
               }

               // Chooses 1 random card, and check whether we encountered available card that equals to the first chosen card 
               if(chosenLocation[0].HasValue == false)
               {
                    chosenLocation[0] = RandomizeAvailableLocation(i_CurrentGame.AvailableCards);
                    resultMove[0] = i_CurrentGame.Board[chosenLocation[0].Value.Row, chosenLocation[0].Value.Col];
                    chosenLocation[0] = resultMove[0].Location;
                    
                    // and check if we saw available card that equals to the first 
                    if(i_CurrentGame.SeenCards.TryGetValue(resultMove[0].CellContent, out List<Location> seenMatches) && resultMove[0].Location.Equals(seenMatches[0]) == false) 
                    {
                            chosenLocation[1] = seenMatches[0];
                    }
                    else 
                    {
                        // chose the second card randomly as well
                        chosenLocation[1] = RandomizeAvailableLocation(i_CurrentGame.AvailableCards);
                        while(chosenLocation[0].Equals(chosenLocation[1]))
                        {
                            chosenLocation[1] = RandomizeAvailableLocation(i_CurrentGame.AvailableCards);
                        }
                    }
               }

               resultMove[0] = i_CurrentGame.Board[chosenLocation[0].Value.Row, chosenLocation[0].Value.Col];
               resultMove[1] = i_CurrentGame.Board[chosenLocation[1].Value.Row, chosenLocation[1].Value.Col];
                
               return resultMove;
          }

          public Location RandomizeAvailableLocation(List<Cell> i_AvailableCards)
          {
              Random randomObj = new Random();
              int randomIndex = randomObj.Next(i_AvailableCards.Count);

              return i_AvailableCards[randomIndex].Location;
          }
     }
}