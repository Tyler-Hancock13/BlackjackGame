using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlackjackInfo;

namespace BlackjackV2
{
    public partial class Blackjack : Form
    {
        public Blackjack()
        {
            InitializeComponent();
        }

        Game game = new Game();

        private void Form1_Load(object sender, EventArgs e)
        {
            btnHit.Enabled = false;
            btnStay.Enabled = false;
        }

        private void ShowHand(PictureBox thePanel, Hand theHand)
        {
            thePanel.Controls.Clear();
            Card aCard;
            PictureBox aPic;
            for (int i = 0; i < theHand.Count; i++)
            {
                aCard = theHand[i];
                string path = @"C:\College\OOP\Project\BlackjackV2\BlackjackV2\images\" + aCard.FaceValue.ToString() + aCard.Suit.ToString() + ".jpg";
                aPic = new PictureBox()
                {
                    Image = Image.FromFile(path),
                    Text = aCard.FaceValue.ToString(),
                    Width = 71,
                    Height = 100,
                    Left = 75 * i
                };

                thePanel.Controls.Add(aPic);
            }
        }

        private void ShowScore()
        {
            lblPlayerScore.Text = $"Player score: {game.player.hand.currentSum}";
            lblDealerScore.Text = $"Dealer score: {game.dealer.hand.currentSum}";
        }

        private void ResetGame()
        {
            game.player.hand.currentSum = 0;
            game.dealer.hand.currentSum = 0;
            btnNewGame.Enabled = true;
            btnHit.Enabled = false;
            btnStay.Enabled = false;
            Player.Image = null;
            Player.Refresh();
            Dealer.Image = null;
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            ShowHand(Player, game.Setup());
            ShowHand(Dealer, game.DealerStartingHand());
            btnNewGame.Enabled = false;
            btnHit.Enabled = true;
            btnStay.Enabled = true;
            ShowScore();
            if(game.player.hand.currentSum == 21)
            {
                MessageBox.Show("You got blackjack! You Win!");
            }
            game.CheckForBlackjack();
        }

        private void btnHit_Click(object sender, EventArgs e)
        {
            ShowHand(Player, game.PlayerHit());
            ShowScore();

            if(game.player.hand.currentSum > 21)
            {
                MessageBox.Show("You busted. Dealer Wins.");
                ResetGame();
            }
            
        }

        private void btnStay_Click(object sender, EventArgs e)
        {
            while(game.dealer.hand.currentSum < 16)
            {
                ShowHand(Dealer, game.DealerHit());
                ShowScore();

            }

            if (game.dealer.hand.currentSum > 21)
            {
                MessageBox.Show("Dealer busted. You win.");
                ResetGame();
            }
            else if (game.dealer.hand.currentSum > game.player.hand.currentSum)
            {
                MessageBox.Show("Dealer wins.");
                ResetGame();
            }
            else
            {
                MessageBox.Show("You win!");
                ResetGame();
            }

        }
    }
}
