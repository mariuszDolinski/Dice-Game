using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice_Game
{
    internal class MenuUtils
    {
        private Game _game;
        public MenuUtils(Game game) 
        {
            _game = game;
        }

        public void MenuEventsInitialize(Main main)
        {
            main.nowaGraToolStripMenuItem.Click += NowaGraToolStripMenuItem_Click;
            main.ToolStripMenuItemAddPlayer1.Click += AddPlayer01ToolStripMenuItem_Click;
            main.ToolStripMenuItemAddPlayer2.Click += AddPlayer02ToolStripMenuItem_Click;
            main.ToolStripMenuItemAddPlayer3.Click += AddPlayer03ToolStripMenuItem_Click;
            main.ToolStripMenuItemAddPlayer4.Click += AddPlayer04ToolStripMenuItem_Click;
        }

        private void NowaGraToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            _game.NewGameButtonClicked();
        }

        private void AddPlayer01ToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            _game.ShowPlayerTextBox(0);
        }
        private void AddPlayer02ToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            _game.ShowPlayerTextBox(1);
        }
        private void AddPlayer03ToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            _game.ShowPlayerTextBox(2);
        }
        private void AddPlayer04ToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            _game.ShowPlayerTextBox(3);
        }
    }
}
