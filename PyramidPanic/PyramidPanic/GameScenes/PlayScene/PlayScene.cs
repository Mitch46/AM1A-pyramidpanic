﻿// Met using kan je een XNA codebibliotheek toevoegen en gebruiken in je class
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
    public class PlayScene : IState
    {
        //Fields van de class PlayScene
        private PyramidPanic game;
        private Beetle beetle, beetle1;
        private Scorpion scorpion, scorpion1;
        private Explorer explorer;
        private Block blok;
        private Block blokhor;
        private Block blokvert;
        private Block door;
        private Block wall1;
        private Block wall2;

        // Constructor van de StartScene-class krijgt een object game mee van het type PyramidPanic
        public PlayScene(PyramidPanic game)
        {
            this.game = game;
            this.Initialize();
        }

        // Initialize methode. Deze methode initialiseert (geeft startwaarden aan variabelen).
        // Void wil zeggen dat er niets teruggegeven wordt.
        public void Initialize()
        {
            this.LoadContent();
        }

        // LoadContent methode. Deze methode maakt nieuwe objecten aan van de verschillende
        // classes.
        public void LoadContent()
        {
            this.beetle = new Beetle(this.game, new Vector2(100f, 300f));
            this.beetle1 = new Beetle(this.game, new Vector2(400f, 100f));
            this.scorpion = new Scorpion(this.game, new Vector2(300f, 188f));
            this.scorpion1 = new Scorpion(this.game, new Vector2(188f, 300f));
            this.explorer = new Explorer(this.game, new Vector2(304f, 240f));
            this.blok = new Block(this.game, @"Block\Block", new Vector2(0f, 0f));
            this.blokhor = new Block(this.game, @"Block\Block_hor", new Vector2(50f, 0f));
            this.blokvert = new Block(this.game, @"Block\Block_vert", new Vector2(100f, 0f));
            this.door = new Block(this.game, @"Block\Door", new Vector2(150f, 0f));
            this.wall1 = new Block(this.game, @"Block\Wall1", new Vector2(200f, 0f));
            this.wall2 = new Block(this.game, @"Block\Wall2", new Vector2(250f, 0f));
        }

        // Update methode. Deze methode wordt normaal 60 maal per seconde aangeroepen.
        // en update alle variabelen, methods enz.......
        public void Update(GameTime gameTime)
        {
            if (Input.EdgeDetectKeyDown(Keys.B))
            {
                this.game.IState = this.game.StartScene;
            }
            this.beetle.Update(gameTime);
            this.beetle1.Update(gameTime);
            this.scorpion.Update(gameTime);
            this.scorpion1.Update(gameTime);
            this.explorer.Update(gameTime);
        }

        // Draw methode. Deze methode wordt normaal 60 maal per seconde aangeroepen en
        // tekent de textures op het canvas
        public void Draw(GameTime gameTime)
        {
            this.game.GraphicsDevice.Clear(Color.Pink);
            this.beetle.Draw(gameTime);
            this.beetle1.Draw(gameTime);
            this.scorpion.Draw(gameTime);
            this.scorpion1.Draw(gameTime);
            this.explorer.Draw(gameTime);
            this.blok.Draw(gameTime);
            this.blokhor.Draw(gameTime);
            this.blokvert.Draw(gameTime);
            this.door.Draw(gameTime);
            this.wall1.Draw(gameTime);
            this.wall2.Draw(gameTime);

        }
    }
}
