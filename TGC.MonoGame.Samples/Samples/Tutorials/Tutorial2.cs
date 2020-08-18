﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TGC.MonoGame.Samples.Cameras;
using TGC.MonoGame.Samples.Geometries;
using TGC.MonoGame.Samples.Viewer;

namespace TGC.MonoGame.Samples.Samples.Tutorials
{
    /// <summary>
    /// Tutorial 2:
    /// Shows how to create a colored 3D box and display it on the screen.
    /// Author: René Juan Rico Mendoza.
    /// </summary>
    public class Tutorial2 : TGCSample
    {
        ///<inheritdoc/>
        public Tutorial2(TGCViewer game) : base(game)
        {
            Category = TGCSampleCategory.Tutorials;
            Name = "Tutorial 2";
            Description = "Shows the Creation of a 3D Box with one color per vertex and can be moved using the keyboard arrows.";
        }

        private StaticCamera Camera { get; set; }
        private BoxPrimitive Box { get; set; }

        ///<inheritdoc/>
        public override void Initialize()
        {
            Game.Background = Color.CornflowerBlue;
            Camera = new StaticCamera(GraphicsDevice.Viewport.AspectRatio, MathHelper.PiOver4, 1, 500,
                new Vector3(0, 20, 60), Vector3.Zero);
            Box = new BoxPrimitive(GraphicsDevice, new Vector3(25, 25, 25), Vector3.Zero, Color.Black, Color.Red, Color.Yellow,
                Color.Green, Color.Blue, Color.Magenta, Color.White, Color.Cyan);

            base.Initialize();
        }

        ///<inheritdoc/>
        public override void Update(GameTime gameTime)
        {
            // Press Directional Keys to rotate cube
            if (Game.CurrentKeyboardState.IsKeyDown(Keys.Up)) Camera.WorldMatrix *= Matrix.CreateRotationX(-0.05f);

            if (Game.CurrentKeyboardState.IsKeyDown(Keys.Down)) Camera.WorldMatrix *= Matrix.CreateRotationX(0.05f);

            if (Game.CurrentKeyboardState.IsKeyDown(Keys.Left)) Camera.WorldMatrix *= Matrix.CreateRotationY(-0.05f);

            if (Game.CurrentKeyboardState.IsKeyDown(Keys.Right)) Camera.WorldMatrix *= Matrix.CreateRotationY(0.05f);

            base.Update(gameTime);
        }

        ///<inheritdoc/>
        public override void Draw(GameTime gameTime)
        {
            Game.Background = Color.CornflowerBlue;

            Game.GraphicsDevice.DepthStencilState = DepthStencilState.Default;

            AxisLines.Draw(GraphicsDevice, Camera);

            Box.Draw(GraphicsDevice, Camera);

            base.Draw(gameTime);
        }
    }
}