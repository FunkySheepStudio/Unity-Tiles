using System.Collections.Generic;
using UnityEngine;

namespace FunkySheep.Tiles
{
    public class Utils
    {
        /// <summary>
        /// Position relative to the grid with the offset
        /// </summary>
        /// <param name="position">World position</param>
        /// <returns></returns>
        public static Vector2 RelativePosition(Vector2 position, float tileSize, Vector2 initialOffset)
        {
            Vector2 relativePosition = position - tileSize * initialOffset;
            return relativePosition;
        }

        /// <summary>
        /// Tile position in a given world position
        /// </summary>
        /// <param name="position">World position</param>
        /// <returns></returns>
        public static Vector2Int TilePosition(Vector2 position, float tileSize, Vector2 initialOffset)
        {
            Vector2 relativePosition = RelativePosition(position, tileSize, initialOffset);
            Vector2Int tilePosition = new Vector2Int(
              Mathf.FloorToInt(relativePosition.x / tileSize),
              Mathf.FloorToInt(relativePosition.y / tileSize)
            );

            return tilePosition;
        }

        /// <summary>
        /// Calculate the relative value position inside a tile
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public static Vector2 InsideTilePosition(Vector2 position, float tileSize, Vector2 initialOffset)
        {
            Vector2 relativePosition = RelativePosition(position, tileSize, initialOffset);
            Vector2Int tilePosition = TilePosition(position, tileSize, initialOffset);
            Vector2 insideTilePosition = relativePosition -
            new Vector2(
              tilePosition.x * tileSize,
              tilePosition.y * tileSize
            );

            insideTilePosition /= tileSize;

            return insideTilePosition;
        }

        /// <summary>
        /// Calculate the quarter position inside a tile 
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public static Vector2Int InsideTileQuarterPosition(Vector2 position, float tileSize, Vector2 initialOffset)
        {
            Vector2 insideTilePosition = InsideTilePosition(position, tileSize, initialOffset);
            Vector2Int insideTileQuarterPosition = Vector2Int.zero;

            if (insideTilePosition.x >= 0.5f)
            {
                insideTileQuarterPosition.x = 1;
            }
            else
            {
                insideTileQuarterPosition.x = -1;
            }

            if (insideTilePosition.y >= 0.5f)
            {
                insideTileQuarterPosition.y = 1;
            }
            else
            {
                insideTileQuarterPosition.y = -1;
            }

            return insideTileQuarterPosition;
        }

        /// <summary>
        /// Calculate the world offset givent the offset and the size of a tile
        /// </summary>
        /// <returns></returns>
        public static Vector2 WorldOffset(float tileSize, Vector2 initialOffset)
        {
            Vector2 worldOffset = initialOffset * tileSize;
            return worldOffset;
        }
    }
}
