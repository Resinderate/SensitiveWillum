using Microsoft.Xna.Framework;
using GDLibrary;
using GDLibrary.Managers;
using System.Collections.Generic;

namespace SensitiveWillum
{
    public class UIManager : DrawableGameComponent
    {
        //three hearts.
        //three modular anm. spr. with full / empty states.
        //when you update lives, update these.
        private ModularAnimatedSprite heartOne;
        private ModularAnimatedSprite heartTwo;
        private ModularAnimatedSprite heartThree;
        //amount of stars. Star x 0
        private Sprite coin;
        private Sprite coinX;
        private ModularAnimatedSprite coinNumber;
        

        //key y/n
        private ModularAnimatedSprite key;

        private float depth;



        public UIManager(Main game)
            : base(game)
        {
            this.depth = 0.05f;

            List<AnimatedTextureData> heartAni = new List<AnimatedTextureData>();
            heartAni.Add((AnimatedTextureData)SpriteManager.GAME.TEXTUREMANAGER.Get("heartFull"));
            heartAni.Add((AnimatedTextureData)SpriteManager.GAME.TEXTUREMANAGER.Get("heartEmpty"));

            List<AnimatedTextureData> keyAni = new List<AnimatedTextureData>();
            keyAni.Add((AnimatedTextureData)SpriteManager.GAME.TEXTUREMANAGER.Get("keyEmpty"));
            keyAni.Add((AnimatedTextureData)SpriteManager.GAME.TEXTUREMANAGER.Get("keyFull"));

            List<AnimatedTextureData> coinNumberAni = new List<AnimatedTextureData>();
            coinNumberAni.Add((AnimatedTextureData)SpriteManager.GAME.TEXTUREMANAGER.Get("coinZero"));
            coinNumberAni.Add((AnimatedTextureData)SpriteManager.GAME.TEXTUREMANAGER.Get("coinOne"));
            coinNumberAni.Add((AnimatedTextureData)SpriteManager.GAME.TEXTUREMANAGER.Get("coinTwo"));
            coinNumberAni.Add((AnimatedTextureData)SpriteManager.GAME.TEXTUREMANAGER.Get("coinThree"));

            this.heartOne = new ModularAnimatedSprite("heartOne",
                heartAni,
                new SpritePresentationInfo(heartAni[0].FRAMESOURCES[0], depth),
                new SpritePositionInfo(new Vector2(5, 5), heartAni[0].FRAMEWIDTH, heartAni[0].FRAMEHEIGHT),
                10);

            this.heartTwo= new ModularAnimatedSprite("heartTwo",
                heartAni,
                new SpritePresentationInfo(heartAni[0].FRAMESOURCES[0], depth),
                new SpritePositionInfo(new Vector2(63, 5), heartAni[0].FRAMEWIDTH, heartAni[0].FRAMEHEIGHT),
                10);

            this.heartThree = new ModularAnimatedSprite("heartThree",
                heartAni,
                new SpritePresentationInfo(heartAni[0].FRAMESOURCES[0], depth),
                new SpritePositionInfo(new Vector2(121, 5), heartAni[0].FRAMEWIDTH, heartAni[0].FRAMEHEIGHT),
                10);

            this.coin = new Sprite("coin",
                SpriteManager.GAME.TEXTUREMANAGER.Get("hud_spritesheet"),
                new SpritePresentationInfo(new Rectangle(55, 0, 47, 47), depth),
                new SpritePositionInfo(new Vector2(5, 55), 47, 47));

            this.coinX = new Sprite("coinX",
                SpriteManager.GAME.TEXTUREMANAGER.Get("hud_spritesheet"),
                new SpritePresentationInfo(new Rectangle(0, 239, 30, 28), depth),
                new SpritePositionInfo(new Vector2(60, 65), 30, 28));

            this.coinNumber = new ModularAnimatedSprite("coinNumber",
                coinNumberAni,
                new SpritePresentationInfo(coinNumberAni[0].FRAMESOURCES[0], depth),
                new SpritePositionInfo(new Vector2(95, 60), coinNumberAni[0].FRAMEWIDTH, coinNumberAni[0].FRAMEHEIGHT),
                10);
                

            this.key = new ModularAnimatedSprite("key",
                keyAni,
                new SpritePresentationInfo(keyAni[0].FRAMESOURCES[0], depth),
                new SpritePositionInfo(new Vector2(10, 112), keyAni[0].FRAMEWIDTH, keyAni[0].FRAMEHEIGHT),
                10);
        }

        public void updateHearts(int lives)
        {
            if (lives == 3)
            {
                if(heartOne.CURRENTANIMATION != 0)
                    heartOne.changeAnimation(0);
                if (heartTwo.CURRENTANIMATION != 0)
                    heartTwo.changeAnimation(0);
                if (heartThree.CURRENTANIMATION != 0)
                    heartThree.changeAnimation(0);
            }
            else if(lives == 2)
            {
                if (heartOne.CURRENTANIMATION != 0)
                    heartOne.changeAnimation(0);
                if (heartTwo.CURRENTANIMATION != 0)
                    heartTwo.changeAnimation(0);
                if (heartThree.CURRENTANIMATION != 1)
                    heartThree.changeAnimation(1);
            }
            else if (lives == 1)
            {
                if (heartOne.CURRENTANIMATION != 0)
                    heartOne.changeAnimation(0);
                if (heartTwo.CURRENTANIMATION != 1)
                    heartTwo.changeAnimation(1);
                if (heartThree.CURRENTANIMATION != 1)
                    heartThree.changeAnimation(1);
            }
            else if (lives == 0)
            {
                if (heartOne.CURRENTANIMATION != 1)
                    heartOne.changeAnimation(1);
                if (heartTwo.CURRENTANIMATION != 1)
                    heartTwo.changeAnimation(1);
                if (heartThree.CURRENTANIMATION != 1)
                    heartThree.changeAnimation(1);
            }
        }

        public void updateKey(bool hasKey)
        {
            if (hasKey)
            {
                if(key.CURRENTANIMATION != 1)
                    key.changeAnimation(1);
            }
            else
            {
                if (key.CURRENTANIMATION != 0)
                    key.changeAnimation(0);
            }
        }

        public void updateCoins(int coins)
        {
            if (coins == 0)
            {
                if (coinNumber.CURRENTANIMATION != 0)
                    coinNumber.changeAnimation(0);
            }
            else if (coins == 1)
            {
                if (coinNumber.CURRENTANIMATION != 1)
                    coinNumber.changeAnimation(1);
            }
            else if (coins == 2)
            {
                if (coinNumber.CURRENTANIMATION != 2)
                    coinNumber.changeAnimation(2);
            }
            else if (coins == 3)
            {
                if (coinNumber.CURRENTANIMATION != 3)
                    coinNumber.changeAnimation(3);
            }
        }

        public override void Update(GameTime gameTime)
        {
            updateHearts(SpriteManager.GAME.PLAYER.HEALTH);
            updateKey(SpriteManager.GAME.PLAYER.HASKEY);
            updateCoins(SpriteManager.GAME.PLAYER.COINS);

            heartOne.Update(gameTime);
            heartTwo.Update(gameTime);
            heartThree.Update(gameTime);
            coin.Update(gameTime);
            coinX.Update(gameTime);
            coinNumber.Update(gameTime);
            key.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteManager.GAME.SPRITEBATCH.Begin();
            heartOne.Draw(gameTime);
            heartTwo.Draw(gameTime);
            heartThree.Draw(gameTime);
            coin.Draw(gameTime);
            coinX.Draw(gameTime);
            coinNumber.Draw(gameTime);
            key.Draw(gameTime);
            SpriteManager.GAME.SPRITEBATCH.End();
            //base.Draw(gameTime);
        }
    }
}
