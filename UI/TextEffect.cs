using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MGVarolloUtils.UI
{
    /// <summary>
    /// A visual effect to a Text object
    /// </summary>
    public abstract class TextEffect
    {
        /// <summary>
        /// The Text this effect will be applied to
        /// </summary>
        protected Text text;

        /// <summary>
        /// Asigns the text reference
        /// </summary>
        /// <param name="text">The text this effect is applied to</param>
        public void AsignText(Text text) { this.text = text; }

        public abstract int Draw(SpriteBatch spriteBatch);
    }

    public class TextEffectShadow : TextEffect
    {
        /// <summary>
        /// The shadow offset
        /// </summary>
        public Vector2 offset;

        /// <summary>
        /// The shadow color
        /// </summary>
        public Color color;

        /// <summary>
        /// Constructs a TextEffectShadow with the reference text, the offset and the color
        /// </summary>
        /// <param name="text">The referenced text</param>
        /// <param name="offset">The shadow offset</param>
        /// <param name="color">The shadow color</param>
        public TextEffectShadow(Text text, Vector2 offset, Color color)
        {
            this.offset = offset;
            this.color = color;
        }

        /// <summary>
        /// Constructs a TextEffectShadow with the reference text and the offset
        /// </summary>
        /// <param name="text">The referenced text</param>
        /// <param name="offset">The shadow offset</param>
        public TextEffectShadow(Text text, Vector2 offset)
        {
            this.offset = offset;
            color = Color.Black;
        }

        /// <summary>
        /// Constructs a TextEffectShadow with the reference text and the color
        /// </summary>
        /// <param name="text">The referenced text</param>
        /// <param name="color">The shadow color</param>
        public TextEffectShadow(Text text, Color color)
        {
            offset = new Vector2(5, 5);
            this.color = color;
        }

        /// <summary>
        /// Constructs a TextEffectShadow with the reference text
        /// </summary>
        public TextEffectShadow(Text text)
        {
            offset = new Vector2(5, 5);
            color = Color.Black;
        }

        /// <summary>
        /// Constructs a TextEffectShadow with the offset and the color
        /// </summary>
        /// <param name="offset">The shadow offset</param>
        /// <param name="color">The shadow color</param>
        public TextEffectShadow(Vector2 offset, Color color)
        {
            text = null;
            this.offset = offset;
            this.color = color;
        }

        /// <summary>
        /// Constructs a TextEffectShadow
        /// </summary>
        public TextEffectShadow()
        {
            text = null;
            offset = new Vector2(5, 5);
            color = Color.Black;
        }

        /// <summary>
        /// Draws the effect
        /// </summary>
        /// <returns>Returns -1 if the texture is not drawn or 1 if it is</returns>
        public override int Draw(SpriteBatch spriteBatch)
        {
            if (text == null) return -1;

            Vector2 position = text.transform.position + offset;
            spriteBatch.DrawString(text.font, text.text, position, color, text.transform.rotation, text.origin(), text.transform.scale, text.spriteEffects, text.layerDepth);

            return 1;
        }
    }
}
