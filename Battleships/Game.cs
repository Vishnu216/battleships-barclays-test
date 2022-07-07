using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleships
{
    // Imagine a game of battleships.
    //   The player has to guess the location of the opponent's 'ships' on a 10x10 grid
    //   Ships are one unit wide and 2-4 units long, they may be placed vertically or horizontally
    //   The player asks if a given co-ordinate is a hit or a miss
    //   Once all cells representing a ship are hit - that ship is sunk.
    public class Game
    {
        // ships: each string represents a ship in the form first co-ordinate, last co-ordinate
        //   e.g. "3:2,3:5" is a 4 cell ship horizontally across the 4th row from the 3rd to the 6th column
        // guesses: each string represents the co-ordinate of a guess
        //   e.g. "7:0" - misses the ship above, "3:3" hits it.
        // returns: the number of ships sunk by the set of guesses

        private static readonly List<List<string>> _ships = new List<List<string>>();

        /// <summary>
        /// The battle ship game
        /// </summary>
        /// <param name="ships">Coordinates of ships passed as a collection (eg: ["3:2,3:5", "4:2,4:5"])</param>
        /// <param name="guesses">Collection of coordinates of ship to be sunk eg: ["3:4","7:3"]</param>
        /// <returns>Count of sunk ships</returns>
        public static int Play(string[] ships, string[] guesses)
        {
            SetShipCellCollection(ships);
            return GetSunkShipCount(guesses);
        }

        /// <summary>
        /// Sets the ships collection 
        /// </summary>
        /// <param name="ships">Coordinates of ships passed as a collection (eg: ["3:2,3:5", "4:2,4:5"])</param>
        /// <exception cref="InvalidOperationException"></exception>
        private static void SetShipCellCollection(string[] ships)
        {
            foreach (var ship in ships)
            {
                var coordinates = ship.Split(',');
                var firstCoordinates = coordinates[0].Split(':');
                var secondCoordinates = coordinates[1].Split(':');
                var tempShip = new List<string>();
                if (firstCoordinates[0] == secondCoordinates[0]) //horizontal ship
                {
                    var shipHead = Convert.ToInt32(firstCoordinates[1]);
                    var shipFoot = Convert.ToInt32(secondCoordinates[1]);
                    var currentShipPosition = firstCoordinates[0];
                    while (shipHead <= shipFoot)
                    {
                        tempShip.Add($"{currentShipPosition}:{shipHead}");
                        shipHead++;
                    }
                }
                else if (firstCoordinates[1] == secondCoordinates[1]) //vertical ship
                {
                    var shipHead = Convert.ToInt32(firstCoordinates[0]);
                    var shipFoot = Convert.ToInt32(secondCoordinates[0]);
                    var currentShipPosition = firstCoordinates[1];
                    while (shipHead <= shipFoot)
                    {
                        tempShip.Add($"{shipHead}:{currentShipPosition}");
                        shipHead++;
                    }
                }
                else
                {
                    throw new InvalidOperationException("No diagonal ships are allowed");
                }
                if (tempShip.Any())
                {
                    _ships.Add(tempShip);
                }
            }
        }

        /// <summary>
        /// Gets the sunk ship count based on the player guesses
        /// </summary>
        /// <param name="guesses">Collection of coordinates of ship to be sunk eg: ["3:4","7:3"]</param>
        /// <returns>The number of ships sunk</returns>
        private static int GetSunkShipCount(string[] guesses) =>
            _ships.Count(ship => ship.All(shipCell => guesses.Contains(shipCell)));
    }
}
