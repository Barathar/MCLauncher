using MCLauncher.Utility;
using System.Drawing;

namespace MCLauncher.Data
{
    public class Player
    {
        public string Name { get; set; }
        [SkipProperty]
        public Image Image { get; set; } = Properties.Resources._default;
    }
}
