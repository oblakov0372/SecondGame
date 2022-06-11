using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        List<Coin> coins = new List<Coin>();
        
        #region Platform
        Platform platform1 = new Platform(0,620,600);
        Platform platform2 = new Platform(0, 100);
        Platform platform3 = new Platform(250, 250);
        Platform platform4 = new Platform(600, 450);
        Platform platform5 = new Platform(650, 140,400);
        Platform platform6 = new Platform(950, 450);
        Platform platform7 = new Platform(1200, 620);
        Platform platform8 = new Platform(1400, 450);
        Platform platform9 = new Platform(1200, 300);
        #endregion
        #region Coin
        Coin coin1 = new Coin(290, 240);
        Coin coin2 = new Coin(320, 240);
        Coin coin3 = new Coin(350, 240);
        Coin coin4 = new Coin(640, 440);
        Coin coin5 = new Coin(670, 440);
        Coin coin6 = new Coin(700, 440);
        Coin coin7 = new Coin(1240, 290);
        Coin coin8 = new Coin(1270, 290);
        Coin coin9 = new Coin(1300, 290);
        Coin coin10 = new Coin(675, 130);
        Coin coin11 = new Coin(705, 130);
        Coin coin12 = new Coin(735, 130);
        Coin coin13 = new Coin(765, 130);
        Coin coin14 = new Coin(795, 130);
        Coin coin15 = new Coin(825, 130);
        Coin coin16 = new Coin(855, 130);
        Coin coin17 = new Coin(885, 130);
        Coin coin18 = new Coin(915, 130);
        Coin coin19 = new Coin(945, 130);
        Coin coin20 = new Coin(975, 130);
        Coin coin21 = new Coin(1005, 130);
        Coin coin22 = new Coin(255, 590);
        Coin coin23 = new Coin(285, 590);
        Coin coin24 = new Coin(315, 590);
        Coin coin25 = new Coin(345, 590);
        Coin coin26 = new Coin(375, 590);
        Coin coin27 = new Coin(405, 590);
        Coin coin28 = new Coin(435, 590);
        Coin coin29 = new Coin(465, 590);

        #endregion
        Person player = new Person();
        Enemy enemy = new Enemy(300,571);
        Enemy enemy2 = new Enemy(850, 91);
        Door door = new Door();
        Key key = new Key();
        Timer spawnCoinTimer = new Timer();
        Timer GameTimer = new Timer();

        Label score = new Label();
        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(1800,700);
            this.BackColor = Color.Black;
            this.Controls.Add(player);
            this.Controls.Add(door);
            this.Controls.Add(key);
            this.Controls.Add(enemy);
            this.Controls.Add(enemy2);
            #region Timer
            GameTimer.Interval = 20;
            GameTimer.Enabled = true;
            GameTimer.Tick += MainTimer;
            spawnCoinTimer.Interval = 5000;
            spawnCoinTimer.Tick += spawnCoinTimerTick;
            #endregion
            #region Score
            score.Location = new Point(0, 600);
            score.ForeColor = Color.White;
            score.BackColor = Color.Transparent;
            this.Controls.Add(score);
            #endregion           
            #region AddCoin
            this.Controls.Add(coin1); coins.Add(coin1);
            this.Controls.Add(coin2); coins.Add(coin2);
            this.Controls.Add(coin3); coins.Add(coin3);
            this.Controls.Add(coin4); coins.Add(coin4);
            this.Controls.Add(coin5); coins.Add(coin5);
            this.Controls.Add(coin6); coins.Add(coin6);
            this.Controls.Add(coin7); coins.Add(coin7);
            this.Controls.Add(coin8); coins.Add(coin8);
            this.Controls.Add(coin9); coins.Add(coin9);
            this.Controls.Add(coin10); coins.Add(coin10);
            this.Controls.Add(coin11); coins.Add(coin11);
            this.Controls.Add(coin12); coins.Add(coin12);
            this.Controls.Add(coin13); coins.Add(coin13);
            this.Controls.Add(coin14); coins.Add(coin14);
            this.Controls.Add(coin15); coins.Add(coin15);
            this.Controls.Add(coin16); coins.Add(coin16);
            this.Controls.Add(coin17); coins.Add(coin17);
            this.Controls.Add(coin18); coins.Add(coin18);
            this.Controls.Add(coin19); coins.Add(coin19);
            this.Controls.Add(coin20); coins.Add(coin20);
            this.Controls.Add(coin21); coins.Add(coin21);
            this.Controls.Add(coin22); coins.Add(coin22);
            this.Controls.Add(coin23); coins.Add(coin23);
            this.Controls.Add(coin24); coins.Add(coin24);
            this.Controls.Add(coin25); coins.Add(coin25);
            this.Controls.Add(coin26); coins.Add(coin26);
            this.Controls.Add(coin27); coins.Add(coin27);
            this.Controls.Add(coin28); coins.Add(coin28);
            this.Controls.Add(coin29); coins.Add(coin29);
            #endregion
            #region AddPlatform
            this.Controls.Add(platform1);
            this.Controls.Add(platform2);
            this.Controls.Add(platform3);
            this.Controls.Add(platform4);
            this.Controls.Add(platform5);
            this.Controls.Add(platform6);
            this.Controls.Add(platform7);
            this.Controls.Add(platform8);
            this.Controls.Add(platform9);
            #endregion
        }

        private void MainTimer(object sender, EventArgs e)
        {
            score.Text = $"Score: {player.scoreTxt}";
            player.Move();
            foreach (var coin in coins)
            {
                if(coin.Visible == false)
                {
                    spawnCoinTimer.Start();
                }
            }
            if (player.move == true)
            {
                enemy.Move(this);
                enemy2.Move(this);
            }
            player.TouchCoin(this);
            player.TouchPlatform(this);
            player.TouchEnemy(this,GameTimer);
            player.EnterTheDoor(key, door, GameTimer);
            player.Loss(this, GameTimer);
            if (player.gameOver == true)
                RestartGame();

        }

        private void spawnCoinTimerTick(object sender, EventArgs e)
        {
            foreach(var coin in coins)
            {
                coin.SpawnCoin(spawnCoinTimer);
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            player.KeyUpPerson(this, e);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            player.KeyDownPerson(this, e);
        }

        private void RestartGame()
        {
            Form1 newWindow = new Form1();
            newWindow.Show();
            this.Hide();
        }

        private void CloseGame(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}