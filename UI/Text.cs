using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MGVarolloUtils.UI
{
    public enum TextAlign { TopLeft, TopCenter, TopRight, Left, Center, Right, BottomLeft, BottomCenter, BottomRight }

    public class Text
    {
        public string text;
        public SpriteFont font;
        public TextAlign alignment;
        public float layerDepth;

        public Color color;
        public SpriteEffects spriteEffects;
        public TextEffect textEffect { get; private set; }

        public Transform transform;

        public Vector2 origin() =>
            alignment == TextAlign.TopLeft      ? new Vector2(0) :
            alignment == TextAlign.TopCenter    ? new Vector2(font.MeasureString(text).X / 2, 0) :
            alignment == TextAlign.TopRight     ? new Vector2(font.MeasureString(text).X, 0) :
            alignment == TextAlign.Left         ? new Vector2(0, font.MeasureString(text).Y / 2) :
            alignment == TextAlign.Center       ? new Vector2(font.MeasureString(text).X / 2, font.MeasureString(text).Y / 2) :
            alignment == TextAlign.Right        ? new Vector2(font.MeasureString(text).X, font.MeasureString(text).Y / 2) :
            alignment == TextAlign.BottomLeft   ? new Vector2(0, font.MeasureString(text).Y) :
            alignment == TextAlign.BottomCenter ? new Vector2(font.MeasureString(text).X / 2, font.MeasureString(text).Y) :
                                                  new Vector2(font.MeasureString(text).X, font.MeasureString(text).Y);

        public Text(SpriteFont font, string text, Vector2 position, Vector2 scale, Color color, float rotation = 0, TextAlign alignment = TextAlign.TopLeft, SpriteEffects effects = SpriteEffects.None, float layerDepth = 0)
        {
            this.text = text;
            this.font = font;
            this.alignment = alignment;
            this.layerDepth = layerDepth;

            this.color = color;
            this.spriteEffects = effects;

            transform = new Transform(position, rotation, scale);
        }

        #region Text Effects
        public void SetTextEffect(TextEffect effect)
        {
            textEffect = effect;
            textEffect.AsignText(this);
        }
        #endregion
        public void Draw(SpriteBatch spriteBatch)
        {
            if (textEffect != null) textEffect.Draw(spriteBatch);
            spriteBatch.DrawString(font, text, transform.position, color, transform.rotation, origin(), transform.scale, spriteEffects, layerDepth);
        }
    }
}
