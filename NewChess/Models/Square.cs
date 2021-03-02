using System.Drawing;
namespace Models
{
    public class Square
    {
        private static Image background;
        //public Piece piece;

        public Square()
        {
            if (background == null)
            {
                Image background = Image.FromFile("image.jpg");
            }
        }

    }
}
