//met Using kan je een XNA codebibliotheer gebruiken in je class
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PyramidPanic
{
    //Dit is een toestands class (dus moet hij de interface toepassen)
    //Deze class belooft dan plechtig dat hij de methods uit de interface heeft
    public class ExplorerWalkUp : AnimatedSprite, IEntityState
    {
        //fields
        private Explorer explorer;
        private Vector2 velocity;

        //Constructor
        public ExplorerWalkUp(Explorer explorer)
            : base(explorer)
        {
            this.explorer = explorer;
            this.destinationRectangle = new Rectangle((int)this.explorer.Position.X,
                                                (int)this.explorer.Position.Y,
                                                32,
                                                32);
            this.velocity = new Vector2(0f, this.explorer.Speed);
            this.rotation = 199.5f;

        }

        public void Initialize()
        {
            this.destinationRectangle.X = (int)this.explorer.Position.X;
            this.destinationRectangle.Y = (int)this.explorer.Position.Y;
        }

        public new void Update(GameTime gameTime)
        {

            this.explorer.Position -= this.velocity;

            if (this.explorer.Position.Y < 20)
            {
                //Breng de explorer in de toestand walkdown
                this.explorer.Position -= this.velocity;
                this.explorer.State = this.explorer.IdleWalk;
                //Roteert de explorer verticaal zodat hij omhoog beweegt
                this.explorer.IdleWalk.Effect = SpriteEffects.FlipVertically;
                this.explorer.IdleWalk.Rotation = (float)Math.PI / -2;

            }

            if (Input.EdgeDetectKeyUp(Keys.Up))
            {
                this.explorer.State = this.explorer.Idle;
                this.explorer.Idle.Effect = SpriteEffects.FlipHorizontally;
                this.explorer.Idle.Rotation = (float)Math.PI / -2;
            }
            base.Update(gameTime);
        }
    }

}