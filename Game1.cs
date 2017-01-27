using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongsketBall
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		//Textures
		Texture2D court;
		Texture2D ball;
		Texture2D hoop;
		Texture2D backboard;
		Texture2D net;
		Texture2D hands;


		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			// TODO: Add your initialization logic here
			graphics.PreferredBackBufferHeight = 1048;
			graphics.PreferredBackBufferWidth = 1600;
			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>

		private Vector2 origin;
		private Vector2 screenpos;
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);
			court = Content.Load<Texture2D>("court");
			hoop = Content.Load<Texture2D>("hoop");
			backboard = Content.Load<Texture2D>("backboard");
			net = Content.Load<Texture2D>("net");
			ball = Content.Load<Texture2D>("ball");
			hands = Content.Load<Texture2D>("hands");

			Viewport viewport = graphics.GraphicsDevice.Viewport;
			origin.X = hoop.Width / 2;
			origin.Y = hoop.Height / 2;
			screenpos.X = 115;
			screenpos.Y = 525;
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// game-specific content.
		/// </summary>
		protected override void UnloadContent()
		{
			// TODO: Unload any non ContentManager content here
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		private float RotationAngle;
		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			// TODO: Add your update logic here
			// The time since Update was called last.
			//float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

			// TODO: Add your game logic here.
			//RotationAngle += elapsed;
			float circle = MathHelper.Pi * 2;
			RotationAngle = -1.57079633f % circle;

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.White);

			spriteBatch.Begin();
			spriteBatch.Draw(court, new Vector2(0, 0));
			spriteBatch.Draw(hoop, screenpos, null, Color.White, RotationAngle, origin, 1.0f, SpriteEffects.None, 0f);
			spriteBatch.Draw(ball, new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2));
			spriteBatch.Draw(hands, new Vector2(Mouse.GetState().X,Mouse.GetState().Y));
			spriteBatch.End();

			

			base.Draw(gameTime);
		}
	}
}
