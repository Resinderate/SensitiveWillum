//File for taking in a 2D array of ints, and then using some sort of indexing. Turn that into a list of bodies in the game.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using GDLibrary;
using GDLibrary.Managers;
using GDLibrary.Utilities;

namespace SensitiveWillum
{
    class LevelBuilder
    {
        private static float backDepth = 0.3f;
        private static float frontDepth = 0.1f;

        public static List<Block>[] buildLevelStructure(int[,] tiles, TextureManager textureManager, int tileWidth, int tileHeight)
        {
            //really going to return a list of objects in the game, mainly stuff to be used with collision detection.
            List<Block> collidables = new List<Block>();
            List<Block> nonCollidables = new List<Block>();
            List<Block> exits = new List<Block>();
            List<Block> springs = new List<Block>();
            List<Block> spikes = new List<Block>();
            List<Block> coins = new List<Block>();
            List<Block> key = new List<Block>();
            

            int numRows = tiles.GetLength(0);
            int numCols = tiles.GetLength(1);

            for (int rowIndex = 0; rowIndex < numRows; rowIndex++)
            {
                for (int colIndex = 0; colIndex < numCols; colIndex++)
                {
                    if (tiles[rowIndex, colIndex] == 0)
                    {
                        //nothing
                    }
                    else if (tiles[rowIndex, colIndex] == 1)
                    {
                        //make an earth tile - Middle.
                        collidables.Add(new Block("earthmid " + rowIndex + "." + colIndex, 
                                                textureManager.Get("tiles_spritesheet"),
                                        new SpritePresentationInfo(new Rectangle(576, 864, tileWidth, tileHeight), backDepth),
                                        new SpritePositionInfo(new Vector2(tileWidth * colIndex, tileHeight * rowIndex), tileWidth, tileHeight)));
                    }
                    else if (tiles[rowIndex, colIndex] == 2)
                    {
                        collidables.Add(new Block("grassmid " + rowIndex + "." + colIndex,
                                                textureManager.Get("tiles_spritesheet"),
                                        new SpritePresentationInfo(new Rectangle(504, 576, tileWidth, tileHeight), backDepth),
                                        new SpritePositionInfo(new Vector2(tileWidth * colIndex, tileHeight * rowIndex), tileWidth, tileHeight)));
                    }
                    else if (tiles[rowIndex, colIndex] == 3)
                    {
                        collidables.Add(new Block("grassleft " + rowIndex + "." + colIndex,
                                                textureManager.Get("tiles_spritesheet"),
                                        new SpritePresentationInfo(new Rectangle(504, 648, tileWidth, tileHeight), backDepth),
                                        new SpritePositionInfo(new Vector2(tileWidth * colIndex, tileHeight * rowIndex), tileWidth, tileHeight)));
                    }
                    else if (tiles[rowIndex, colIndex] == 4)
                    {
                        collidables.Add(new Block("grassright " + rowIndex + "." + colIndex,
                                                textureManager.Get("tiles_spritesheet"),
                                        new SpritePresentationInfo(new Rectangle(504, 504, tileWidth, tileHeight), backDepth),
                                        new SpritePositionInfo(new Vector2(tileWidth * colIndex, tileHeight * rowIndex), tileWidth, tileHeight)));
                    }
                    else if (tiles[rowIndex, colIndex] == 5)
                    {
                        collidables.Add(new Block("grasssingle " + rowIndex + "." + colIndex,
                                                textureManager.Get("tiles_spritesheet"),
                                        new SpritePresentationInfo(new Rectangle(648, 0, tileWidth, tileHeight), backDepth),
                                        new SpritePositionInfo(new Vector2(tileWidth * colIndex, tileHeight * rowIndex), tileWidth, tileHeight)));
                    }
                    else if (tiles[rowIndex, colIndex] == 6)
                    {
                        collidables.Add(new Block("bridgelogs " + rowIndex + "." + colIndex,
                                                textureManager.Get("tiles_spritesheet"),
                                        new SpritePresentationInfo(new Rectangle(288, 720, tileWidth, tileHeight), backDepth),
                                        new SpritePositionInfo(new Vector2(tileWidth * colIndex, tileHeight * rowIndex), tileWidth, tileHeight)));
                    }
                    else if (tiles[rowIndex, colIndex] == 7)
                    {
                        collidables.Add(new Block("watertop " + rowIndex + "." + colIndex,
                                                textureManager.Get("tiles_spritesheet"),
                                        new SpritePresentationInfo(new Rectangle(432, 576, tileWidth, tileHeight), backDepth),
                                        new SpritePositionInfo(new Vector2(tileWidth * colIndex, tileHeight * rowIndex), tileWidth, tileHeight)));
                    }
                    else if (tiles[rowIndex, colIndex] == 8)
                    {
                        collidables.Add(new Block("waterfull " + rowIndex + "." + colIndex,
                                                textureManager.Get("tiles_spritesheet"),
                                        new SpritePresentationInfo(new Rectangle(504, 216, tileWidth, tileHeight), backDepth),
                                        new SpritePositionInfo(new Vector2(tileWidth * colIndex, tileHeight * rowIndex), tileWidth, tileHeight)));
                    }
                        
                    else if (tiles[rowIndex, colIndex] == 10)
                    {
                        nonCollidables.Add(new Block("fence " + rowIndex + "." + colIndex,
                                                textureManager.Get("tiles_spritesheet"),
                                        new SpritePresentationInfo(new Rectangle(648, 144, tileWidth, tileHeight), frontDepth),
                                        new SpritePositionInfo(new Vector2(tileWidth * colIndex, tileHeight * rowIndex), tileWidth, tileHeight)));
                    }
                    else if (tiles[rowIndex, colIndex] == 11)
                    {
                        nonCollidables.Add(new Block("fencebroken " + rowIndex + "." + colIndex,
                                                textureManager.Get("tiles_spritesheet"),
                                        new SpritePresentationInfo(new Rectangle(648, 72, tileWidth, tileHeight), frontDepth),
                                        new SpritePositionInfo(new Vector2(tileWidth * colIndex, tileHeight * rowIndex), tileWidth, tileHeight)));
                    }
                    else if (tiles[rowIndex, colIndex] == 12)
                    {
                        springs.Add(new Block("spring " + rowIndex + "." + colIndex,
                                                textureManager.Get("items_spritesheet"),
                                        new SpritePresentationInfo(new Rectangle(432, 216, tileWidth, tileHeight), backDepth),
                                        new SpritePositionInfo(new Vector2(tileWidth * colIndex, tileHeight * rowIndex), tileWidth, tileHeight)));
                    }
                    else if (tiles[rowIndex, colIndex] == 13)
                    {
                        spikes.Add(new Block("spikes " + rowIndex + "." + colIndex,
                                                textureManager.Get("items_spritesheet"),
                                        new SpritePresentationInfo(new Rectangle(347, 0, tileWidth, tileHeight), backDepth),
                                        new SpritePositionInfo(new Vector2(tileWidth * colIndex, tileHeight * rowIndex), tileWidth, tileHeight)));
                    }
                    else if (tiles[rowIndex, colIndex] == 20)
                    {
                        nonCollidables.Add(new Block("exitsign " + rowIndex + "." + colIndex,
                                                textureManager.Get("tiles_spritesheet"),
                                        new SpritePresentationInfo(new Rectangle(288, 360, tileWidth, tileHeight), frontDepth),
                                        new SpritePositionInfo(new Vector2(tileWidth * colIndex, tileHeight * rowIndex), tileWidth, tileHeight)));
                    }
                    else if (tiles[rowIndex, colIndex] == 21)
                    {
                        nonCollidables.Add(new Block("signleft " + rowIndex + "." + colIndex,
                                                textureManager.Get("tiles_spritesheet"),
                                        new SpritePresentationInfo(new Rectangle(288, 288, tileWidth, tileHeight), frontDepth),
                                        new SpritePositionInfo(new Vector2(tileWidth * colIndex, tileHeight * rowIndex), tileWidth, tileHeight)));
                    }
                    else if (tiles[rowIndex, colIndex] == 30)
                    {
                        nonCollidables.Add(new Block("plant " + rowIndex + "." + colIndex,
                                                textureManager.Get("items_spritesheet"),
                                        new SpritePresentationInfo(new Rectangle(0, 363, tileWidth, tileHeight), frontDepth),
                                        new SpritePositionInfo(new Vector2(tileWidth * colIndex, tileHeight * rowIndex), tileWidth, tileHeight)));
                    }
                    else if (tiles[rowIndex, colIndex] == 40)
                    {
                        key.Add(new Block("key " + rowIndex + "." + colIndex,
                                                textureManager.Get("items_spritesheet"),
                                        new SpritePresentationInfo(new Rectangle(72, 363, tileWidth, tileHeight), backDepth),
                                        new SpritePositionInfo(new Vector2(tileWidth * colIndex, tileHeight * rowIndex), tileWidth, tileHeight)));
                    }
                    else if (tiles[rowIndex, colIndex] == 41)
                    {
                        coins.Add(new Block("coin " + rowIndex + "." + colIndex,
                                                textureManager.Get("items_spritesheet"),
                                        new SpritePresentationInfo(new Rectangle(288, 360, tileWidth, tileHeight), backDepth),
                                        new SpritePositionInfo(new Vector2(tileWidth * colIndex, tileHeight * rowIndex), tileWidth, tileHeight)));
                    }
                    else if (tiles[rowIndex, colIndex] == 98)
                    {
                        exits.Add(new Block("doormid " + rowIndex + "." + colIndex,
                                                textureManager.Get("tiles_spritesheet"),
                                        new SpritePresentationInfo(new Rectangle(648, 432, tileWidth, tileHeight), backDepth),
                                        new SpritePositionInfo(new Vector2(tileWidth * colIndex, tileHeight * rowIndex), tileWidth, tileHeight)));
                    }
                    else if (tiles[rowIndex, colIndex] == 99)
                    {
                        exits.Add(new Block("doortop " + rowIndex + "." + colIndex,
                                                textureManager.Get("tiles_spritesheet"),
                                        new SpritePresentationInfo(new Rectangle(648, 360, tileWidth, tileHeight), backDepth),
                                        new SpritePositionInfo(new Vector2(tileWidth * colIndex, tileHeight * rowIndex), tileWidth, tileHeight)));
                    }
                }
            }
            List<Block>[] blocks = new List<Block>[7];
            blocks[0] = collidables;
            blocks[1] = nonCollidables;
            blocks[2] = exits;
            blocks[3] = springs;
            blocks[4] = spikes;
            blocks[5] = key;
            blocks[6] = coins;

            return blocks;
        }
    }
}
