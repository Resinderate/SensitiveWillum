using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GDLibrary;
using Microsoft.Xna.Framework;

namespace SensitiveWillum
{
    public class Block : Sprite
    {
        public Block(string name, TextureData textureData,
                    SpritePresentationInfo spritePresentationInfo,
                        SpritePositionInfo spritePositionInfo) :
            base(name, textureData, spritePresentationInfo, spritePositionInfo)
        {

        }

        public override void Update(GameTime gameTime)
        {
            //Any Block specific updates here.
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
