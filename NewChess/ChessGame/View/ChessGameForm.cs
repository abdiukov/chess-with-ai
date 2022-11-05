using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGame.View
{
    public abstract class ChessGameForm : Form
    {
        public virtual Task ShowNewForm(Form page)
        {
            // Show new page
            page.Show();

            // Hide current page
            Hide();

            return Task.CompletedTask;
        }
    }
}
