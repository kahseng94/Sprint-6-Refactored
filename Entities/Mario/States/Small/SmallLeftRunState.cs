﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Sprites;
using Sprint5.Sprites.Entities.Mario;
using Sprint5.World.Sounds;

namespace Sprint5.Entities.Mario
{
    public class SmallLeftRunState : IMarioState
    {
        public string Name { get { return "Small"; } }

        private Mario mario;
        private ISprite sprite;

        public SmallLeftRunState(Mario mario)
        {
            this.mario = mario;
            sprite = MarioSpriteFactory.Instance.CreateSmallLeftRunSprite();

            mario.Bounds = new Rectangle(0, 0, 1, 1);
        }

        public void Left()
        {
            // Apply left force
            mario.ApplyForce(mario.Movement.IsOnGround(mario) ? Mario.GroundLeft : Mario.AirLeft);
        }

        public void Right()
        {
            mario.State = new SmallRightIdleState(mario);
        }

        public void Up()
        {
            SoundEffects.Instance.PlayJumpSmallSound();
            mario.State = new SmallLeftJumpState(mario);
        }

        public void Down()
        {
            mario.State = new SmallLeftIdleState(mario);
        }

        public void RightReleased()
        {
        }

        public void LeftReleased()
        {
            mario.State = new SmallLeftIdleState(mario);
        }

        public void DownReleased()
        {
        }

        public void UpReleased()
        {
        }

        public void Use()
        {
            mario.Run();
        }

        public void Walk()
        {
        }

        public void Run()
        {
        }

        public void ToBig()
        {
            mario.State = new BigLeftRunState(mario);
        }

        public void ToSmall()
        {
        }

        public void ToFire()
        {
            mario.State = new FireLeftRunState(mario);
        }

        public void CauseDamage()
        {
            SoundEffects.Instance.PlayMarioDieSound();
            mario.State = new SmallDeadState(mario);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location);
        }
    }
}
