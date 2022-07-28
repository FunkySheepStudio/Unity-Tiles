using System.Collections.Generic;
using UnityEngine;

namespace FunkySheep.Tiles
{
    [AddComponentMenu("FunkySheep/Tiles/Tiles Manager")]
    public class Manager : MonoBehaviour
    {
        public Tile initialTile;
        public FunkySheep.Types.Vector2 initialOffset;
        public FunkySheep.Types.Float tileSize;
        public List<Tile> tiles = new List<Tile>();

        public Tile Add(Vector2Int position)
        {
            Tile tile = this.Get(position);
            if (tile == null)
            {
                tile = new Tile(position);
                tiles.Add(tile);
            }

            if (tiles.Count == 1)
            {
                initialTile = tile;
            }

            return tile;
        }

        public Tile Get(Vector2Int position)
        {
            return tiles.Find(tile => tile.position == position);
        }

        public bool Exist(Vector2Int position)
        {
            Tile tile = this.Get(position);
            if (tile == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Position relative to the grid with the offset
        /// </summary>
        /// <param name="position">World position</param>
        /// <returns></returns>
        public Vector2 RelativePosition(Vector2 position)
        {
            return Utils.RelativePosition(position, tileSize.value, initialOffset.value);
        }

        /// <summary>
        /// Tile position in a given world position
        /// </summary>
        /// <param name="position">World position</param>
        /// <returns></returns>
        public Vector2Int TilePosition(Vector2 position)
        {
            return Utils.TilePosition(position, tileSize.value, initialOffset.value);
        }

        /// <summary>
        /// Calculate the relative value position inside a tile
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public Vector2 InsideTilePosition(Vector2 position)
        {
            return Utils.InsideTilePosition(position, tileSize.value, initialOffset.value);
        }

        /// <summary>
        /// Calculate the quarter position inside a tile 
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public Vector2Int InsideTileQuarterPosition(Vector2 position)
        {
            return Utils.InsideTileQuarterPosition(position, tileSize.value, initialOffset.value);
        }

        /// <summary>
        /// Calculate the world offset givent the offset and the size of a tile
        /// </summary>
        /// <returns></returns>
        public Vector2 WorldOffset()
        {
            return Utils.WorldOffset(tileSize.value, initialOffset.value);
        }
    }
}
